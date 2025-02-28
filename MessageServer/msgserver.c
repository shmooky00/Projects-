#include <errno.h>
#include <netinet/in.h>
#include <sys/types.h>
#include <unistd.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/socket.h>
#include <getopt.h>
#include <netdb.h>

#define BUFSIZE 256

#define USAGE                                                        \
  "usage:\n"                                                         \
  "  msgserver [options]\n"                                         \
  "options:\n"                                                       \
  "  -p                  Port (Default: 10823)\n"                    \
  "  -m                  Maximum pending connections (default: 5)\n" \
  "  -h                  Show this help message\n"

/* OPTIONS DESCRIPTOR ====================================================== */
static struct option gLongOptions[] = {
    {"help", no_argument, NULL, 'h'},
    {"port", required_argument, NULL, 'p'},
    {"maxnpending", required_argument, NULL, 'm'},
    {NULL, 0, NULL, 0}};

int main(int argc, char **argv) {
  int maxnpending = 5;
  int option_char;
  int portno = 10823; /* port to listen on */

  // Parse and set command line arguments
  while ((option_char =
              getopt_long(argc, argv, "hx:m:p:", gLongOptions, NULL)) != -1) {
    switch (option_char) {
      case 'm':  // server
        maxnpending = atoi(optarg);
        break;
      case 'p':  // listen-port
        portno = atoi(optarg);
        break;
      case 'h':  // help
        fprintf(stdout, "%s ", USAGE);
        exit(0);
        break;
      default:
        fprintf(stderr, "%s ", USAGE);
        exit(1);
    }
  }

  setbuf(stdout, NULL);  // disable buffering

  if ((portno < 1025) || (portno > 65535)) {
    fprintf(stderr, "%s @ %d: invalid port number (%d)\n", __FILE__, __LINE__,
            portno);
    exit(1);
  }
  if (maxnpending < 1) {
    fprintf(stderr, "%s @ %d: invalid pending count (%d)\n", __FILE__, __LINE__,
            maxnpending);
    exit(1);
  }

  // Socket Code Here ////////////////////////////////////////////


 int serverSocket, createSocket, valueRead;

 struct sockaddr_in serverAddr, clientAddr;

 socklen_t addrLen = sizeof(clientAddr);

serverAddr.sin_family = AF_INET; 

 char buffer[BUFSIZE];

/////////

  if ((serverSocket = socket(AF_INET, SOCK_STREAM, 0)) < 0)
  {

    printf("Socket did not work correctly. \n");
   
    exit(EXIT_FAILURE);
 
  }

//set server address
  serverAddr.sin_family = AF_INET;

  serverAddr.sin_port = htons(portno);
  
  serverAddr.sin_addr.s_addr = INADDR_ANY;


//we must bind the socket to an access port 
  if (bind (serverSocket, (struct sockaddr *)& serverAddr, sizeof(serverAddr)) < 0) 
    {

    printf("Bind failed. \n");
      
    exit(EXIT_FAILURE);
      
    }

///////

  if (listen(serverSocket, maxnpending) < 0) 
    {

    printf("Listen failed. \n");
    
    exit(EXIT_FAILURE);

    }

//////////

  //like the string I found 
  printf("Server is listening right now. On port: %d...\n", portno);

 while (1) 
    {

    createSocket = accept(serverSocket, (struct sockaddr *)&clientAddr, &addrLen); 

    if (createSocket < 0) 
    {

    printf("Accept failed. \n");

    continue;
  }


///////

    valueRead = read(createSocket, &buffer, BUFSIZE -1);

    if (valueRead < 0)
    {

      printf("Read did not work. \n");

      continue;
      
    }

buffer[valueRead] = '\0'; //null terminator 

//I was looking up how to print a new line with "\n" and it suggested if I was using a string that I should throw in %s before notating a string specifically...
    printf("Message recieved: %s\n", buffer);

    const char *response = "Message was receieved.";

    if(send(createSocket, response, strlen(response), 0) < 0 )
    {

      printf("Send failed");
      
      continue;
    }

    close(createSocket);
  }

 close (serverSocket);

 return 0;
}
