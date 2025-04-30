#include <errno.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <getopt.h>
#include <netdb.h>
#include <netinet/in.h>
#include <unistd.h>
#include <mqueue.h>
#include <sys/mman.h>
#include <fcntl.h>
#include <semaphore.h>

#define MSG_QUEUE "/shm_server_queue"
#define SHM_NAME "/shm_file_transfer"
#define SEM_NAME "/shm_semaphore"

#define MAX_MSG 256
#define SHM_SIZE 4096

// handle data transfer 
typedef struct {

    int total_size;
    int sent_size;

    char buffer[SHM_SIZE];
} shm_data_t;


#define BUFSIZE 512

// Variables for reading input filenames
#define MAX_LENGTH 64
char files[5][MAX_LENGTH];
char buffer[MAX_LENGTH];
char* filename = "filelist.txt";

#define USAGE                                                \
  "usage:\n"                                                 \
  "  shm_client [options]\n"                                 \
  "options:\n"                                               \
  "  -n                  Number of files to transfer\n"      \
  "  -h                  Show this help message\n"

/* OPTIONS DESCRIPTOR ====================================================== */
static struct option gLongOptions[] = { {"help", no_argument, NULL, 'h'},
                                       {NULL, 0, NULL, 0} };

int readFilenames();

/* Main ========================================================= */
int main(int argc, char** argv) {
    int option_char = 0;
    int num_files = 20;

    setbuf(stdout, NULL);

    /* Parse and set command line arguments */
    while ((option_char =
        getopt_long(argc, argv, "xn:", gLongOptions, NULL)) != -1) {
        switch (option_char) {
        case 'n': // num files
            num_files = atoi(optarg);
            break;
        case 'h':  // help
            fprintf(stdout, "%s", USAGE);
            exit(0);
            break;
        default:
            fprintf(stderr, "%s", USAGE);
            exit(1);
        }
    }

    // Read in the names of the files to transfer
    readFilenames();

    /* This section will let you verify that you can loop through the list of files the appropriate number of times.
     *  You can modify this to call your code to request a file "num_files" times
     */
    fprintf(stdout, "Num files: %d\n", num_files);
    
    for (int y = 0; y < num_files; y++) {
        printf("%d - ", y);
        printf("%s", files[y % 5]);
    }

// given code already^ not sure if we need

struct mq_attr attr;
    attr.mq_flags = 0;
    attr.mq_maxmsg = 10; 
    attr.mq_msgsize = 256;    
    attr.mq_msgs = 0;

 // creating the shared mem
    mqd_t mq = mq_open(MSG_QUEUE, O_CREAT | O_RDWR, 0644, &attr);
    if (mq == -1) 
    {
        perror("mq_open");
        return 1;
    }


    printf("Message queue created");

    // open shared memory region
    char sharedMem[64];

snprintf(sharedMem, sizeof(sharedMem), "/shm_client_%d", getpid());

char sem[64];

snprintf(sem, sizeof(sem), "/sem_client_%d", getpid());


int shm_fd = shm_open(sharedMem, O_CREAT | O_RDWR, 0644);

ftruncate(shm_fd, sizeof(shm_data_t));

    if (shm_fd == -1) 
    {
        perror("shm_open");
        exit(1);
    }

    shm_data_t* shm_ptr = mmap(NULL, sizeof(shm_data_t), PROT_READ | PROT_WRITE, MAP_SHARED, shm_fd, 0);

    if (shm_ptr == MAP_FAILED) 
    {
        perror("mmap");
        exit(1);
    }

    // open semaphore
    sem_t* sem = sem_open(SEM_NAME, O_RDWR);

    if (sem == SEM_FAILED) 
    {
        sem = sem_open(SEM_NAME, O_CREAT, 0644, 1);

        if (sem == SEM_FAILED) 
        {

            perror("sem_open");
            exit(1);
        }
    }

// send file requests to server
for (int x = 0; x < num_files; x++) 
{
    printf("Requesting file: %s\n", files[x % 5]);

    if (mq_send(mq, files[x % 5], strlen(files[x % 5]), 0) == -1)
     {

        perror("mq_send");
        exit(1);
     }

    // receive file and save it locally
    sem_wait(sem);

    FILE* file = fopen(files[x % 5], "w");

    sem_post(sem);
    continue;

int total_written = 0;


do {
    sem_wait(sem); // wait for server to write chunk

    // checking for file
    if (strncmp((*shm_ptr).buffer, "File not found.", strlen("File not found.")) == 0)
    {
        printf("File not found on server: %s\n", files[x % 5]);
        break;
    }

    fwrite((*shm_ptr).buffer, 1, (*shm_ptr).sent_size, file);

    total_written += (*shm_ptr).sent_size;

    sem_post(sem); // let server proceed

} while (total_written < (*shm_ptr).total_size);

fclose(file);
munmap(shm_ptr, sizeof(shm_data_t));
close(shm_fd);
shm_unlink(sharedMem);
sem_close(sem);
sem_unlink(sem);

}

return 0;

}

// given code already:
// Read in the filenames to transfer
int readFilenames() 
{

    int count = 0;
    FILE* fp = fopen(filename, "r");

    if (fp == NULL)
    {
        return 1;
    }

    while (fgets(buffer, MAX_LENGTH, fp))
    {
        strcpy(files[count], buffer);
        count++;
    }

    fclose(fp);

    return 0;
}

//posix referneces
//https://www.geeksforgeeks.org/posix-shared-memory-api/
//https://www.softprayog.in/programming/interprocess-communication-using-posix-shared-memory-in-linux
//https://gist.github.com/juniorprincewang/16cb7e8f9fd51dc5857b00580dab9b38
// https://pubs.opengroup.org/onlinepubs/9699919799/functions/shm_open.html
