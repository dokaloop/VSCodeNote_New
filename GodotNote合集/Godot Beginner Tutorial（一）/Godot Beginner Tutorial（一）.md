### Godot Beginner Tutorial(一)
视频标题：How to make a Video Game - Godot Beginner Tutorial --Brackeys  

#### 1 .   
As for programming, Godot uses its own scripting language called GD script. It's pretty fast and easy to use but still quite powerful.  

Assets:  
sprites, models, textures, sounds   

Importing Assets into Godot is extremely simple.  

#### 2 . 
To make anything in godot we use nodes.    
If you want to make a player character, we do so by putting together a bunch of node.  
Nodes come in many types, some display an image, others play a sound or add physics.  
We can even extend existing nodes to build more powerful ones.  
In its essence, making a game in Godot is combining and extending nodes to get the result we're looking for.  

But building everything in one big world with nodes for the player, enemies, UI and a bunch of levels all in one place would quickly become completely unmanageable and confusing.  Instead, we use scenes, scenes allow us to bundle together nodes into **reusable** packages.  
![picture 0](images/ed7aac2c559a51b31ab93dcec8d05ef606a9237cb9e0ee08b4c1f5156751a0e1.png)  

A scene can be a character, a weapon, a menu. They can be as small as a single collectible coin or an entire level.  
![picture 1](images/f6d7e7f695c1b804119e4c818f6d5c40666771ab2d9237d5c9d38782e8f12714.png)  

Scenes make it really easy to focus on building one part of our game at a time and slowly combining them to make our game larger and larger. This because we can put scenes inside of other scenes which is called nesting 

#### 3 . 
As you can see, all the nodes and scenes on our game start to resemble a tree like structure, called the SCENE TREE.  
![picture 2](images/f7698f555ef48a50e792b88bab94c4deb3a1efd47af949c7038594a17ef5c940.png)  
We call the node at the very beginning of the tree, the root.    

#### 4 . 
【一】Game Scene  
（1）因为是个2D游戏，所以我们选择2D Scene。    
![picture 3](images/4804c39afeb28b6e0fba651426343f06b540f073b011eea897f3627efe5d9cdd.png)  
（2）然后rename它变成Game。  
![picture 4](images/be5b9fa4edbf11527a1adbcd0054484a4937ead87e5ad43b5919874e2b82880b.png)  
（3）
现在有三个文件夹Assets，Scenes，Scripts。  
然后把现在的场景保存在Scenes文件夹。  

【二】Player Scene  
（1）新建一个场景。然后添加节点，并且搜索：CharacterBody2D   
（2）添加该节点后，选中该节点并ctrl+a，快捷方式添加节点。  
![picture 5](images/553a49cf5ffad3063794405a8ffdaa79335aedeb6dd72aeee7daf35097985bd1.png)  

（3）Add animation to player  
![picture 6](images/580509d567b125915aa8ea85c4d5a8a8d888355d3a29083c4caa4645d4a86fd6.png)  

![picture 7](images/e247c40efe0878620e724ccee954715b8dff36ea943ba921179084970d133de2.png)  

![picture 8](images/e19da1ece8469d28b6389e0595a50bd5174bd21bf548966814d95e307d6002fc.png)  

（4）Sprite sheet is a very efficient way of working with lots of Sprites such as when doing animation, otherwise we would have to create an image for each single frame which would quickly become an unmanageable amount of files.   

Now, to start adding these frames in, we first need to configure the grid here. Currently it's set to 4x4.  
![picture 9](images/ea7d34cc1997e3817f63802fe5c00bcfc5b7b22e71f3e110865b7bd9fbd1787d.png)  
然后把它改成8x8，就可以看到白色方格线变密集。  
![picture 10](images/887f725f96394344b7693d4e932d2301bd0aa426dda51db3119c9350ac44ce24.png)  

（5）选中这4个frame。  
![picture 11](images/7da52a349661f91f044b51e97c8b5d5bd89c32635d21b2a5bf00966c74c1027b.png)  
然后点击【Add Frames】按钮。  

（6）选中游戏物体，按住f键可以center our character。  
(鸦猜：可能是focus这个单词)    

#### 5 .  
(1)  
![picture 12](images/4124200dbff5c79f63882b9bce48d333515ef81c7e3513cdf3e1ca28335ffee4.png)  
Our character looks weirdly blurry, that's because we're working with pixel art, which requires really hard edges. By default Godot is going to try to do some texture smoothing to make textures look better, but applied to pixel art, that is definitely not the case, so let's simply disable this.   

所以：  
Project--> Project Settings --> Rendering --> Textures  
![picture 13](images/3bca20bb47170a9d28a8ee52053c40edb7e8fb24dada94862d61f8e8b6bfa85e.png)  

(2)  
![picture 14](images/0c9a0778bd2efc64dd3b1a007cf0cc606e6ce656ebe8dbdac629a4cac9685f0e.png)  

(3) 然后把character移动到粉线之上。  
![picture 19](images/83a3ac58c1828757f46860c15c23560648b9d5fee99b79afb2138eb70b1e2688.png)  

#### 6 .   
（1）把鼠标放在这个黄色的警示标签之上。会看到这样的提示。    
![picture 16](images/08c2a4f71bf01d9bb0d32c9e8d1f8e2a936b0974d798630602320f6e8b553036.png)  
This is because a character body 2D is a physics node and whenever we're working with physics , we need to define a shape that the physics engine can work with. So let's add a new node.  
![picture 17](images/a46660bfa668441de152f5afa93dd838c551c92ae88db4f7deaa17a967e5e84a.png)  

![picture 18](images/09526ce934b705c723fc84ec1e20fb3d90a490eadcb19e8b192d697db419dd8e.png)  
把它碰撞体调整到这个大小和这个位置：  
![picture 20](images/7cec0040cae741ea1e8e95ecd6a0f36a104ecfefb73b03442c98ca4625e508c3.png)  
解释： Colliders rarely need to be very precise and it's a good rule of thumb to make them a bit smaller than the graphics if you need to. Having colliders that are too large is simply going to be frustrating when playing.  

(4) 把这个scene的top node 改名为Player。并ctrl+s保存这个scene。  

（5）切换到Game scene，把Player scene 拽到这个界面。  
![picture 21](images/c2f00af86d82b3b6cec285143651a0a6938155539e83095820a6ce6d7cd821be.png)  

#### 7 .  
(1)Game Scene下新加节点：  
![picture 22](images/a4c16b4d04b7454922c9a281db9793db9434fbf621d18c7196459af5b521cef9.png)  

（2）原来的太大了：  
![picture 23](images/108126a8e1d878cbec014c64d0c0a1bcc6e87c1ae567f25ee7399466d44b9c14.png)  
让我们改成4x4：  
![picture 24](images/7876624d785f79850636c52e8293bba76a6d6e5cb22f10cb52cdbcbfe4f4a129.png)  
再把camera拽到正好focus on the player。  

（3）然后让我们运行一下：  
![picture 25](images/d10157a584d83c917bd669a13fab49d6830fa67fb5cf5036cbf88eaf62268b60.png)  

#### 8 .  
We need to add a script that allows us to move around.  

(1)按这个按钮   
![picture 26](images/a2917afcbcf2a6e4a5f1b99200c6db49fe80e2fe05684adaa1ef450cb105d52e.png)  
![picture 27](images/b7bb7a9b894ffb95dd82dc37cc3c2b8836994b72ef00477b735f2c0f787b8a51.png)  
![picture 28](images/680a6a6df721e8be9bdcca4c41d6d3290834e7e0d0a66337a2fd1545721d8724.png)  

（2）切换回2D场景添加地面。  
![picture 29](images/61a2b7161e7243512f6f396003ab663e99bdebf7724368f5a3e5fe94a4592d63.png)   
![picture 31](images/9baac6321ae53c674de3c76d196a178570262c7461caa1945c0a8663d69629cc.png)  
![picture 30](images/85844e630688e7727e3d6149c90262bf8886a3eacb68707fec959204ec7c3786.png)  
The world boundary is a type of collider, that is perfect for stuff like world boundaries, because it's going to extend infinitely on the horizontal axis here.  
![picture 32](images/19e77ba4f04f1eeca0dc1298a60711045d92acb41838cd0f3fc6c2ff6cb014ac.png)  
如果旋转成这样就会在垂直方向无线延伸。  

可以移动它的位置：  
![picture 33](images/ba32a00153644f9b62ef2001576221fb921499b5a19f634742c00e49fad621ca.png)  

（3）改一下这两个数值。  
![picture 34](images/4fd346ea9d44f2853fc667f46359d478b50f1180e2eb841ceba81140611237c4.png)  

#### 9 . Worldbuilding 1.0  
（1）把这个删了，让我们来建真正的地面。  
![picture 35](images/36500458cc9251df235794279aad60d98556e666f70cb3c954c11d5d41cf9cdb.png)  

添加这个：   
![picture 36](images/af398e0c36f68ffc3f32a5f02cddc60d82fb5a19cee1f3a03b9cad8471ff27fd.png)  

（2）The most common way to create in 2d is by using tiles. In other words, we build our game World by drawing different tiles onto a grid.  
The tile assets we used to paint are normally packed together into one big image, just like our player was. This is called the tileset.  

So the tile set is a collection of tiles that we can use to paint from and the **tilemap** that we just created is the node we use to paint these tiles into our world.  
![picture 38](images/0ecafc12833fb3732ad865e9e25682a636438fdc7640566a6902f1d4c45611e6.png)  

（3）  
![picture 39](images/1d8bf630e552a440a5a39daedd88554431d0545d773aed06f20e8443f28a82bb.png)  

在最底下的视窗可以看到两个tab。  
![picture 40](images/855d92d40d658da8f08a41038f7137afb0d63a844bbd296399e3c071b02e63bb.png)  

![picture 41](images/85924d9ad85bd4651bcf499494ac618c555892ad55622bdcc2c3cc9cacccc3ab.png)  

![picture 42](images/29aef8a2d172d7fbb8849e48a3498dd7d3ebe9bf2344d9ff79927512d1e19ef0.png)  
选yes。  

用橡皮擦擦掉这一块：  
![picture 43](images/5586c3bcf51549790ef7bcef6fad2a1e39ff4debb901b480b00c0bc20864dc84.png)  
![picture 45](images/874f8b78c1bdf4d313b34cc64a58060d2a2c2210ff2ff763f7c6e716c257958d.png)  
按住shift键把它画成一整个：  
![picture 44](images/4d8f36e29c9231704375d863e6d9814d101c869ca4566bf03af17c1e5d3f5c58.png)  

（4）选中这个开始画。  
![picture 46](images/c39735ddc179e7feef9b1e89475254d6a1587506dc78f35cc97fbc592f93e233.png)  

可以选中多个，一起画：  
![picture 47](images/89d210cfdc9283c953064f75f3ed0d3cfc10ebaac46acc3cced5568e094681f8.png)  
![picture 48](images/9572bc9c80d2324a5b181536165ed2f469e4ade274ec499e33adc5cfa3e88f68.png)  

select mode可以选中国一整块，将一整块移动。  
![picture 49](images/5652775fbd4f87ef18bac9d63e56ab4e18cc8fc97282f675a5c70daaf8311c18.png)  

![picture 51](images/dae7a90e597119f00e31c76f574e0aa194a99a7d169959040fdde4841179c254.png)  

（5）为了让角色不会掉出去。  
![picture 52](images/24e92af38f1258bbee11cc1aab97c0ce6252c7f97b7acd82c511997a470d5981.png)  

底部切换到：  
![picture 53](images/9098efaf649a3e334437e1fbbd4df0bd1937f51405ae9f24ee39330c454c4abc.png)  
We need to choose what tiles belong to the physics layer, because we don't want to collide with everything in our tilemap. The trees and bushes we just want to pass right through.  
![picture 54](images/8ce3a55bf85024b44e440c68ad911c0775d1d10bb1c652580a3ecbb891db86bf.png)  

这里可以清除添加的物理。  
![picture 55](images/5a8ab3c08f5f580a2e3cc6df36866707aab73223d75a270a708cf60dc2588d4d.png)  

![picture 56](images/21b55d0418d0a65f3ea395299c423cd10484403708c1b39df0f2ae4c9d0c2f16.png)  
回归画笔模式。  
![picture 57](images/a05baca235bfef1b77b0ce9211ae5996c7781495adeaae2a8a8a64828be54d7c.png)  

（6）
There are also some tiles that we do want physics on, but where we need the collider to only be on part of the tile such as our bridge here.  

![picture 58](images/86fc86cfea474f0d29e126c42af46d819653882d7a7e4997c68dfe22f716b9ae.png)  
We can even add and remove points by clicking and right clicking.   

![picture 59](images/69112230557a9b2dfb2a35850fd3db35c1a11ae6b9b3d05832d4ea2e6f47aa00.png)  
上一个的范围会直接覆盖到下一个的范围。所以不要瞎点。  

（7）Making it (Camera2D) a child of the player means that it will just automatically follow the player node.  
![picture 60](images/ff01f74940af830a70c80c498c31c6b34f686a7b4b09d955461f3bd5c4e0d7a4.png)  

We can even turn on position smoothing to really smooth out our camera follow.  
![picture 61](images/5bf95d3b435fba098236b13317fa90b91d7b6e30307ca6aae438217dcb2a214a.png)  
