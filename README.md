# BitSharp
BitSharp is a **interpreter** that can run code out of images !
It scan *every pixel* to interprete a command, and can interprete **arguments** !
The first line of pixels is used to store **instructions** like *printing*, *set title*, etc...
The arguments are in the *Y axis*

## Instructions
*Red* (255, 0, 0) : Print specified argument to the console.
*Yellow* (255, 255, 0) : Wait user to press a key and close
*Green-blue* (0, 255, 128) : Wait user to press a key
*Cyan* (0, 255, 255) : Change the title of the console with specified arguments
*Green* (0, 255, 0) : Immediately terminate the program
*Magenta* (255, 0, 255) : Wait for specified amount of time (in seconds)

##String Arguments
Characters are colors too, the list is below
Colors are in RGB format

###Letters
*A* : (255, 0, 0)
*B* : (255, 255, 0)
*C* : (0, 255, 0)
*D* : (0, 255, 255)
*E* : (255, 0, 255)
*F* : (128, 255, 0)
*G* : (0, 255, 128)
*H* : (0, 128, 0)
*I* : (0, 0, 128)
*J* : (128, 255, 128)
*K* : (0, 128, 128)
*L* : (128, 128, 255)
*M* : (150, 0, 0)
*N* : (177, 0, 0)
*O* : (0, 150, 0)
*P* : (0, 0, 150)
*Q* : (255, 150, 0)
*R* : (150, 150, 0)
*S* : (0, 150, 255)
*T* : (150, 150, 150)
*U* : (255, 150, 255)
*V* : (180, 0, 0)
*W* : (180, 180, 0)
*X* : (0, 180, 0)
*Y* : (0, 0, 180)
*Z* : (180, 180, 180)
*Space* : (0, 0, 0)

###Numbers
The numbers colors code are more easy !
Just (50, number beetween 0 and 9, 0)
Exemple : *5* = (50, 5, 0)
Another Exemple : *15* = (50, 1, 0) and below (50, 5, 0)

##Hello World
A *Hello World Exemple* is in **Bin/Debug/hello_world.png**