# Sockets - msgclient and msgserver

In this project, your msgclient and msgserver will communicate via sockets
and pass a message back and forth.

## Client-Server

Create a client-server pair where the client sends a message to the server.
The server repeats back the message to the client. You may assume that neither the
message to the server nor the response will be longer than 128 bytes.
Therefore, you may create a static memory buffer. (e.g. `char buffer[128];`)
and then pass this memory address into send or recv.  Because these messages
are so short, you may assume that the full message is sent or received in
every send or recv call.

As a simplifying assumption, both the client and the server should ensure the message is
null terminated.

The only allowable program output on the server side will be the messag sent from client. The only allowable program output on the client side will be printing the message sent from the server. If you use debug messages during development, make sure you turn them off in the code you submit.  Extra output to the screen will result in points lost
during grading.

Your msgserver must not terminate after sending its response; rather,
it should prepare to serve another request.  Your programs should support IPv4. You may
also support IPv6 if you like but it is not a requirement.

## Readme

Throughout your development you should be keeping notes about what you are doing
for your development.  We encourage you to update your readme.md file as your project
develops, so that it can serve as a log of your work. Please use basic markdown tagging to 
make your document easier to read. This will be submitted and constitutes a portion of your grade.

## Submitted Files

You will upload a single .zip file called pr1-project.zip to the project in e-LEarning. In
the zip file will be three files:
- msgclient.c
- msgserver.c
- MyReadme.md

**Submitting any other files or files with the wrong names will result in a grading penalty.**

**NOTES FOR PROJECT**
SERVER CODE:

I first did not understand the Beej's guide for a simple stream server so I did a bunch of research including looking up youtube videos on what 
"get_in_addr..." does and how it works. Skipping halfway through this video "how pointers work" (https://www.youtube.com/watch?v=DplxIq0mc_Y) it taught me that it was pointing got the addr and helped me further understand. 
After watching the video I realized that majority of my code needed to be in a while loop (1 always true) running over top all of the if statements. 

At first, we had a return 0 and a exit(exit_failure) at the end of our if statements, but we realizeed that we only needed the exit_failure. The exit function gives us a way to exit the program and terminate, with the return the program would continue to execute when encountering errors.
We chose to do a while loop so it listen and accept new connections. The if statements we implimented helped us along the way while trouble shooting errors we had when we initially were ddesigning and exploring options for our code.

I also looked up https://www.simplilearn.com/tutorials/c-tutorial/format-specifiers-in-c on how to do the %s & %d (Lines: 122, 62) in certain printf scenerio's according to whether a int or a string is being used in the print function.

CLIENT CODE:

We borrowed the AF_INET from Beej when setting up our server addresses, this also seemed to be standard procedure with the included libraries that came with our files. Then we had to assign a port number. Next we had to get the hosts name to the server and connect it with the cooresponding IP, for this we used the hostent to contain the IP. Both the client and server have a similar socket set up, so we just stuck with the same structure. We found out that we could use the buffer in an array to make for easy termination and act as our null terminator. This would help prevent overflows, by using the '\0' as our terminator. This was used on both siddes of the code to proccess and print the servers response. 
