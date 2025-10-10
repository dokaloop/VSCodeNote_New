###  Finite State Machine  Tutorial
A Better Way to Code Your Characters in Unity | Finite State Machine | Tutorial  
https://www.youtube.com/watch?v=RQd44qSaqww  

I use State Machines for the player character in every game that I make and I do that so that I can avoid a mess of a bunch of checks like this：  
![picture 0](images/cc5619b810408a273da46c383a067f343039745c81a5cb672880fda7be645606.png)  

#### 1 .   
With a state machine, each state is self-contained, which means that you're left with smaller, more manageable scripts, with direct control of what states can switch to what states.
![picture 1](images/14c534f0031a81d4fb7fa5ae6e29f16a99e0679723d7050ba9e2672d9da4bd3b.png)  
This youtuber wanted to have a high amount of enemy variety but he wanted to create a way to make it as easy as possible to creat a high variety.

在这个视频我们会设置3个states：  
（1）idle  
（2）chase  
（3）attack  

unique combinations：  
![picture 2](images/72a2583f4cc161cda432178642833884dc418c7094711406ceedf3cb058e73a7.png)  
