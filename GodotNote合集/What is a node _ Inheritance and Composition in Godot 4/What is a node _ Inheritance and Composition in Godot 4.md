### What is a node? Inheritance and Composition in Godot 4 
https://www.youtube.com/watch?v=w7eSSpiJv2U  

#### 1 . HIGH LEVEL
![picture 0](images/5343a362dd64c36832f21bd99a7cec4a64343d5647b9528c2d1357c352d4eb8d.png)  

In Unity, you have gameObjects which one game object can have a whole bunch of scripts.  

And in godot, you're going tp have nodes which only get one script per node.  

I've heard people use the phrase a composition versus inheritance . Idon't think that's very accurate, tho. Because I think Godot and Unity both have concepts they just implement them differently.  

Maybe this is a dumb analogy, Unity is kind of like a MOBA, you have these game objects that are large and powerful, they have a whole bunch of scripts attached and they do a large portion of work. Godot on the other hand is kind of like a real-time strategy, you don't have these super powerful nodes with a whole bunch of scripts attached, but you do have these formations of nodes that you put together and these do a lot of the work for you.   

#### 2 . 把节点删了，脚本还在
（1）  
这个节点（改名为Player）需要一个脚本  
![picture 1](images/bcebf5e62e9fda25a1118658723d3ca29c99be7ee8ef838c586100332960182d.png)  
![picture 2](images/8a1d1df0a9c9230d25819d5dfab3035ad5df9fbc59fac9786bacc11e5f7ad95c.png)  
创建好脚本后，把node删除。  
![picture 3](images/6a002a619209eed41bf0a8be647adc5b7acd19a00f135430441b729b24b9ef48.png)  

（2）  
这时你想新建一个节点，输入myPlayer
![picture 4](images/9a92a4ebac8c2731258f4fe577ea37a797c3a0ab0888922bf4542a0687dbfed3.png)  
You will notice that there is this class I just created. But not only does this class exist here, but everything leading up to it.  

![picture 5](images/8050f5727e8739d272cfd28a87dcaa0e685f3b72866061e64aa8bf8ce89c6c02.png)  
But I can actually extend the script and make a new one.   
![picture 8](images/1934a2f8295917075bff3a3d7e4d3f6148b6c1513327e58c65595c1abd9cd9d0.png)  

【注意：  
![picture 6](images/1f82cfb7d6b470d121b011053a2e42e3eb909bfffe158aafceb172c6044b51c1.png)  
![picture 7](images/35d86f324bc64526d6ff3a7b71ae43fda23d49c229abc64b00d74ad16dee7366.png)  
】  

#### 3 . 可以改变节点的type
![picture 9](images/b5ec09a2a37ce214fd470132b3d334eaecdd16ac25136e82c7948ba2d2248ae7.png)  

#### 4 . node分类
I ended up separating this into four categories : Node2D, Node3D, Control node, and everything else that doesn't fall into the other three . 
![picture 11](images/ae6dc7cf24400a2098dfb7e3b863fca519a8d68b67bb762aa5fb09494d752d63.png)  

![picture 10](images/007ffbcf7b827f52a962d6a18ccd9cf06faf45baeec1244f151ca3460818e9a5.png)  

![picture 12](images/dd0a6dda7327f4419b50ee6c612d80893c5b08fc153be03a8de90a5dbbd1ba19.png)  
Let's talk about the three base nodes and how they work and how they interact.  
Control node specifically are used for menus whereas node2D and node3D aren't .  

#### 5 . node2D下面也可能可以放control node。  
![picture 13](images/79203b580176b733992d367aeea8e92ab175572ba2a2c8c2da6325857395bed8.png)  
How is this neing moved around, if the control node is not derived from a node2D.  
You are able to use 2D nodes with control nodes, 但是缩放那些可能会有点奇怪.  
缩放node2D或是staticBody2D或是colorRect都是不太相同的。  