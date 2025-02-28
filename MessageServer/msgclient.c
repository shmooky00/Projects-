#include <unistd.h>
#include <errno.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/socket.h>
#include <sys/types.h>
#include <getopt.h>
#include <netdb.h>
#include <netinet/in.h>

// A buffer large enough to contain the longest allowed string
#define BUFSIZE 256

#define USAGE                                                          \
  "usage:\n"                                                           \
  "  msgclient [options]\n"                                           \
  "options:\n"                                                         \
  "  -s                  Server (Default: localhost)\n"                \
  "  -p                  Port (Default: 10823)\n"                      \
  "  -m                  Message to send to server (Default: \"Welcome " \
  "Back!.\")\n"                                                       \
  "  -h                  Show this help message\n"

/* OPTIONS DESCRIPTOR ====================================================== */
static struct option gLongOptions[] = {
    {"server", required_argument, NULL, 's'},
    {"port", required_argument, NULL, 'p'},
    {"message", required_argument, NULL, 'm'},
    {"help", no_argument, NULL, 'h'},
    {NULL, 0, NULL, 0}};

/* Main ========================================================= */
int main(int argc, char **argv) {
  unsigned short portno = 10823;
  int option_char = 0;
  char *message = "Welcome Back!";
  char *hostname = "localhost";

  // Parse and set command line arguments
  while ((option_char =
              getopt_long(argc, argv, "p:s:m:hx", gLongOptions, NULL)) != -1) {
    switch (option_char) {
      default:
        fprintf(stderr, "%s", USAGE);
        exit(1);
      case 's':  // server
        hostname = optarg;
        break;
      case 'p':  // listen-port
        portno = atoi(optarg);
        break;
      case 'h':  // help
        fprintf(stdout, "%s", USAGE);
        exit(0);
        break;
      case 'm':  // message
        message = optarg;
        break;
    }
  }

  setbuf(stdout, NULL);  // disable buffering

  if ((portno < 1025) || (portno > 65535)) {
    fprintf(stderr, "%s @ %d: invalid port number (%d)\n", __FILE__, __LINE__,
            portno);
    exit(1);
  }

  if (NULL == message) {
    fprintf(stderr, "%s @ %d: invalid message\n", __FILE__, __LINE__);
    exit(1);
  }

  if (NULL == hostname) {
    fprintf(stderr, "%s @ %d: invalid host name\n", __FILE__, __LINE__);
    exit(1);
  }

  /* Socket Code Here *///////////////////////////////////////////

  int clientSocket;

  struct sockaddr_in serverAddr;

  char buffer[BUFSIZE];

  if ((clientSocket = socket(AF_INET, SOCK_STREAM, 0)) < 0)
  {

    printf("Socket creation did not work.");
    
    exit(EXIT_FAILURE);
  }

//we must set the server address
serverAddr.sin_family = AF_INET; 
serverAddr.sin_port = htons(portno);


//we then must get the servers ip
struct hostent *server = gethostbyname(hostname);
if (server == NULL)
{

  fprintf(stderr, "No such host was found");

  exit(EXIT_FAILURE);
  
}

memcpy(&serverAddr.sin_addr.s_addr, server->h_addr_list[0], server->h_length);

////////////

if (connect(clientSocket, (struct sockaddr *)&serverAddr, sizeof(serverAddr)) < 0)
{
  printf("Connection Failed....");
  
  exit(EXIT_FAILURE);

}

/////////

if(send(clientSocket, message, strlen(message), 0) < 0)
{
  printf("Send failed");

  exit(EXIT_FAILURE);
  
}

//////////

int valueRead = read(clientSocket, buffer, BUFSIZE - 1);
  if(valueRead < 0)
  {
    printf("Read Failed");
    
    exit(EXIT_FAILURE);

  }

  buffer[valueRead] = '\0';

  printf("Server response: %s\n", buffer);

  close(clientSocket)

}
