### How to program in Godot - GDScript Tutorial
[TOC]  

reference mannual：  
![picture 0](images/9d0988ea367eb05ad8e72b111b2d489ea4eceedc4ac8099d8d6875f6ce89f70d.png)  

#### 1 . 创建项目
Let's begin by making a script and adding some code to print a message .  
To do that, we need a test scene, so add in a node, rename it to Main.  
![picture 1](images/24842b7a96cfccae861b754612aa81dbf25673ddd0dab4afd8016bbba7295c7b.png)  
然后ctrl+s把它保存成scene。  
再创建一个脚本。  
![picture 2](images/eb55158520b7c0ee8ded1087dcc1a5f0c44b7e3ae903fea64b78088eb3f8ce1a.png)  

#### 2 . Syntax
（1）  
GD script similar to a language like python uses indentation to determine the structure of your code. This means that you use tabs to tell GD script where your code belongs.  
![picture 3](images/af0ee8dd8a38c4e6d59ac434a5802e352235c938443459109ac298cad16963fc.png)  
In our example here, I'm using a tab to tell godot that our print line belongs to the ready function.  
![picture 4](images/e72909a679c42f27cf13d3d0334d927d10a2798c837e32e79496aaa2f98fec9c.png)  
If I delete this TAB, I get an error.  

（2）Also GD script is case sensitive, so if I write 'print' with a capital P, I will also get an error.   
![picture 5](images/10b64efad42d4264bff6b43e49e46791efb818d8849629a016d5cd42fa6d9669.png)  

#### 3 . Modifying nodes 1.0
(1)  
【1】add a new node:  
![picture 6](images/ee3e516e4ce15d346962542d94c255a0801a717a88432d4822e40fe5780b4026.png)

【2】  
调整anchor，center on the screen：  
![picture 7](images/dcf3a4e5459387bd6a0f1123e991df5b28b371ae4776e85d3a6ff9e19a363934.png)  

按住**alt键**调整大小：  
![picture 8](images/f44e657bc4ce26982fbc3d306c6054588eadd86178892eca399f9ad019b37340.png)  

【3】输入文字居中  
![picture 9](images/9f9410c98a12b6be9f8c46c7a5278bdda7bdd9cb38ad2bd894d728ca433a9a98.png)  
![picture 10](images/28ac5dd5f89d127117a7074e3244e0f28388ce821bb7147466d85b4188224664.png)  

【4】Change the text property  
Now to edit the text of this label through script, we need two things. We need a reference to the label and we need to access the property in this label that we want to change. In this case, the text.  
If we hover over text, we can see the name of the property through script, which is text with a non capital T.   
![picture 11](images/c085d8a4aa0226bb18c7271447ca1102d59cb4025e92eaabb1855105890475ae.png)  

不加ctrl直接拽。  
![picture 12](images/ba048ab573927eef808ca8b39086b8e9330d86df89d78db0d7f7e915a7dcaf16.png)  

![picture 13](images/625349e3561046c3fbf7b24d17e9a2bccc070497ff62f39181f6da762eefd589.png)  

【5】Change the color of the text  
In fact there's a property called **modulate** which allows us to tint Sprites and UI elements.  
![picture 14](images/fabb5a40a1a664179ca61d1c3e6c7580352f3cc4231f8cd831b3d93f86eaee18.png)  

![picture 16](images/e5dfd3ca0207e8b71b8052dd0fdcc61420ab14bc59e622b4a3f965805dd2f6cb.png)  

![picture 15](images/02f36e0a28c90e3d1dfcc00ca1fef75f64a1100693830c0237ba12ea1eca98be.png)  

#### 4 . Input  
(1)  
Let's say we want to turn this label red, when we press the space bar.  
To do this, we first need to set up an input action.  

Project -> Project Settings -> Input Map  
Here we can add actions. Actions allow us to bind keys to something that we want to happen.   
![picture 17](images/e3cbbfbd604c2242f3d95aa990880b5d56b2209bfa3bcf2701df32df0e19f907.png)  

`_input()` just like `_ready()`, this is one of the built-in functions of godot, but instead of being called at the start of the game, it runs every time the game receives any input. Such as when we press a button. `event` is what we call the information about what triggered the function. Was it a movement of the mouse or the Press of a key?  

We need to check if the event that triggered the input was our action being pressed.

main.gd代码：  
```py
extends Node

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	$Label.text = "Hello, world!"
	$Label.modulate = Color.GREEN
	
func _input(event):
	if event.is_action_pressed("my_action"):
		$Label.modulate = Color.RED
		
	if event.is_action_released("my_action"):
		$Label.modulate = Color.GREEN
```

#### 5 . Variables 1.0  
![picture 18](images/7edad73106325a094b2777a495bc017325a9538743d9bc77ee2e19dcbc459555.png)  

#### 6 .  If-statements

```py
if x==y and y>z: 
    # code here

if x==y or y>z:
    #code here
```

#### 7 . comments
![picture 19](images/1121d4b907aa2624c2d4fd8426a9fefb9b581ba00c63588c248a359535e18296.png)  
![picture 20](images/bcd09666d7fb62db652b500ceaae42b7995b1f0bcb9b0758688beee6ffa2ffc7.png)  

just remember that you can't have a completely empty function, we need to add the **pass** keyword to avoid an error.   

#### 8 . Variables 2.0  
Some parts of our game will expect a specific type of data and we will get an error if we try to use another type without converting.  
Converting from one type to another is called `casting` .  
代码：  
```py
extends Node

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	var number = 42
	var text = "Meaning of life: " + str(number) 
	print(text)
	
	var pi = 3.14
	print(int(pi))
	
	var position = Vector3( 3, -10, 5)
	position.x += 2
	print(position)
```
输出：  
```
Meaning of life: 42
3
(5, -10, 5)
```
Now by default gdscript is what we called dynamically typed. This means we don't define what type of data a variable can hold when we declare it.    
This makes it fast to create variables and flexible, because we can reassign data of another type at will.  
However it is also more prone to error and less performant than static typing.   
![picture 21](images/3ea74791a009f49c5c13679072447d35504890c64486b8020deff7d41f41ff65.png)  

Luckily GD script allows us to statically type any variables we want. We can pick and choose totally based on preference .   

To statically type a variable, we simply add the type when declaring it.    

```py
extends Node

# so now this variable will always stay integer
var damage: int = 15

# We can even have godot automatically determine the data type.
# This is called invert typing and the result is exactly the same.
# damage2 is a static int.  
# this also means that the variable cannot change to another type.
var damage2 := 15

# will allow us to set it using the inspector
@export var damage3 := 15
	
const GRAVITY = -9.81
```

#### 9 . Functions  
![picture 22](images/2743e67e006b411e5870d930d989f39e37c06c2168bf907b51598df46647f9a7.png)  
So far we've been using some of godot's built-in functions like `_ready()` and `_input()`. Notice how these are prefixed with an underscore. This is to show that they are not activated or called by us. But by the engine itself.  

![picture 23](images/104007542f5a3080252882caf698557e2d0beda98d5f5d85f06ec5f0b32f24bb.png)  
输入输出都规定类型。  

#### 10 . Random numbers
![picture 24](images/b5fc6f8d9eff2f379d585c3e248f061a92e122e433ea988aadf1874935dde25d.png)  
![picture 25](images/1289b46a4329b31d968b9e02681bd591ad235ae4e77492ed9101d196d749706c.png)  
randi-->random integer  
randf-->random float   

#### 11 . Documentation
选中方法，边按ctrl边点击方法。  
![picture 26](images/ad857b94cc9dde7790ab468d9c4eaf1aac9168aab44aecec3e1c0a8b45de86ac.png)  
也可以用于class。  

#### 12 . Arrays  

```py
extends Node

func _ready():
	var items = ["Potion", 3, 6]
	
	var items2: Array[String] = ["Potion", "Feather", "Stolen harp"]

```

![picture 27](images/806af0db769fc8c3a04c5759eee10c56e498bd986fa1edffe8c7268304977dff.png)  

#### 13 . Loops  
![picture 28](images/d4c9ce8ad69a9f8f7aec63d537322d768a1df3a62c234d047de911194ffa7d2a.png)  

![picture 29](images/bf05bcbc1049fe7c9515f8e505083f32b9727636e4435c5897c3315b3517a083.png)  

![picture 30](images/e192e231b31008bea060057025b59413690be3f4abbd1d1cea0e74ee37fbbc75.png)  

#### 14 . Dictionaries
![picture 31](images/c688f83a28e897cbd359f8f399c1f5cbabbd8a426794d93906e80e224e2c300b.png)  

![picture 32](images/7616f78ea9bb8e2a34de1a80d9d1bf7203612872965b163d4f4e42dcc546aafe.png)  

#### 15 . Enums
![picture 33](images/921e3b30b7a53624f8be6159b8bd67c46271fc5a7d058b98c4dfc1dcfc1b6ffe.png)  

有用的用法：  
![picture 34](images/c0f66d4bf5852820bcda15c54f4106bfa0664831f6b7bad509464be062ca804c.png)  

What is actually happening behind the scenes here is that Godot is creating a constant for each state in our enum.  

#### 16 . Match
Match is the Godot equivalent of the switch statement from other languages and allows us to execute different code depending on the value of a variable. In this case, here we use a match statement to add some code for the different values of our enum .   
![picture 35](images/a2d305032e3247c67a0687a05eff2a4b045a8248f19009bdf998b420c41d5787.png)  

#### 17 . Modifying nodes 2.0
(1)  
![picture 36](images/f80ff2be7cb8232161f6fbd12482f01aa75247e5e78a907a7d65484333a52e95.png)  
直接拽的话，create a path。  
![picture 37](images/927e3938be1422a4a463d80f078cb0cff9ffcb4d77b773b3f5bb8a87146054a2.png)  
Hold down ctrl键 while releasing . This automatically creates a variable with the name of the node and the correct path.  

As you can see, it uses the `onready` keyword, this is because godot has a very strict order in which nodes are created.  

If we open the game and try to find the weapon node before it exists, we will get an error. `onready` simply make sure that godot waits until all child nodes have been created. So we don't get any issues.  

A quick note: the dollar sign here is actually just shorthand for using the `get_node` function.  
![picture 38](images/456f82cd9ba80e0646ab071ed25a8e272555cc38b9107aadaaa6ff7aafd20fa4.png)  

(2) You might have noticed that the path is relative. Our script is on the main node, so it starts right after that node. We can print the absolute path through script.  

![picture 39](images/259b4afba2334422860b28311c90d444ae67ff87273c73696dd8253790f9d17c.png)  
![picture 40](images/399c3068df067b832f25fe3ba85b4b88a89f5dd4046ed2982df393c3784c9201.png)  

Now paths are great for many things, but sometimes they can be a bit inflexible. They break if we rename any of the nodes in the path. And it's best to only use paths when the node we want to access is a child of the node we're working on.  

Luckily we can also use the export keyword to reference other nodes.  
![picture 41](images/cf6edbf352583a7a4d68d1597b0adc347a080db8017ec67cec5d25f93e4b20be.png)  
![picture 42](images/32e53ac75c2d920c5e82725b03664ac8d3c361d4bccbbe2d9d0e8e8d00f38e10.png)  
也可以直接拽。  
![picture 43](images/c078618b0421bea8094d45bc2dff9fa378ef7cbb7498d020675256489e86cb1f.png)  

![picture 44](images/55a3cdf890cd7c59dc09aa44733838dbe1b8be302650df7db2e02da7b9b75e2a.png)  
这样就规定了类型只能是Sprite2D。
Sprite2D inherits form node2D.  

#### 18 . Signals 
Signals are messages that nodes can send to each other, we use them to notify that a certain event occurred.   

(1)    
点击绿色按钮：  
![picture 45](images/bd4d861bf0de9468df91d7ac1dbaa27427c788fc9b8176459ae5dab94fe420fc.png)  
会看到：  
![picture 46](images/a6cfac1f52df61e13cb690adc8c7038ee123643b06fa5dbc9f1d6ce011ea2f3a.png)  

We can connect as many functions as we want to a signal, they will all be called when it gets emitted.  
This is really cool, because it allows us to link together nodes in a way where they don't have to be aware of each other.    

Button has no idea which functions are connected to the signal. It just tells it to emit. This makes signals great for seperating different parts of our game or decoupling.  

(2)  
Say we're playing a character that can level up by getting enough XP. Whenever we level up. There are probably many game systems that need to update. The UI, our player stats, perhaps we have spells or achievements that unlock. Updating all of these from player can quickly become a mess. Instead we create a leveled up signal that all these systems can connect to. Then all we need to do is have the palyer emit the signal when we level up.   
![picture 47](images/a8df8cf68361f6dd4995cd381882e6ac5e07f89c3e23c8610d4bedf2a1f71eb4.png)  

![picture 48](images/a3bad970f22a410b439ac790bd80e41c4573b01b0258aed53576c569cf06c25f.png)  
Set it to AutoStart, this will count down from one and when it reaches zero. It emits a signal called `timeout` .   
![picture 49](images/61f0a907e5970b1fbd34a1c10f0f0e599f3907070850481461cbf79d0a35ee62.png)   

![picture 51](images/2acfe601bb884bffff48f9ce1ed781f1b65781a0795bccee88a02c42f09154d3.png)  
![picture 50](images/a966363dc4b94d9f2c1a09b0599c41e8cf48091938d09b34d543dc2156abc45a.png)  

We can also connect signals through code. I'll disconect the signal in the editor.  
![picture 52](images/4e6136615f97e30a55ceeb62574542c2cfba4246b728b6a2595f033af0bf4060.png)  
![picture 54](images/12bd89af8730e2e806c81d9dccd1996e139412bb3d56e490882e0a1ab4a61d73.png)  
![picture 55](images/b6636e1363218fe5c33e41f1da000c76501867e002ebc813cc61de9ed0c48060.png)  

可以写入parameter  
![picture 56](images/4cab73e9f9fbe8d1ca912e1c04f7efefdaa6012ff53c88827194ab700a590881.png)  

#### 19 . Get / set
getters and setters allow us to add code for when a variable is changed. This means that we can do things like clamp a value within a certain range or emit a signal letting other parts of our code know that the variable changed.   
![picture 57](images/6dc91c12a23e30d47187b6bb02736373094437b0f137adc9f306ef6541887310.png)  

![picture 58](images/4e61e3babec75098b820276e4435b96deb52afcb4a199cea7b14bd943e85c09a.png)  
![picture 59](images/6657f035c9a18bad060977ab9f20d8484888c31e9b3546725cb98b39cf253f7c.png)  

#### 20 . Classes 
GD script is an object oriented programming language. This means we generally structure our code inside of contained objects that interact with each other.   

We primarily do this using classes. For now, try to think of a classes as a blueprint.   

All the built-in nodes in godot are classes.   

If we add a Sprite node. We're instancing the Sprite class.   
![picture 60](images/3306d43b12731292d2963c86fc57f1bda956ffef55c5a58524578afd20a6b688.png)  
![picture 61](images/ae64624b3f3041133f7db9318d19484a8e28b6aa4d8a9ed6356a2cace5ab5761.png)  
在这个节点之上加一个脚本。  

Now to make it more clear that our script is a class that defines a character. Let's set the class name to `Character` .  
![picture 62](images/240ac8b7997843ba7c76f4102fa8f435be8b142154d290fb6753cde4f58add4e.png)  
![picture 63](images/4d4817211f7e83aa44b3679f92409c2f0cdeebf5f87e4e93d4a9d2bde31b0024.png)  

![picture 65](images/ee2c82ee6a6e7e95d456cb1beb820cc8e8343961f7ed39e99121dd196d80b827.png)  


![picture 64](images/681d3dece48bfb886911a878f59240f2c5706f0b56093f9fe47ebe89809905fa.png)  

#### 21 . Inner classes  
These are classes that exist inside of another class, you mostly use these for bundling together variables and maybe add a function or two. They can be a good alternative to dictionaries, because they are sometimes a bit more safe to use.   
![picture 66](images/4aeb3550054e7dbaceaac4de69af3265ab3d1e8d4334af3839bec761d16730fa.png)  
This is called being type safe.   

#### 22 . Inheritance
![picture 67](images/efee3e98652969e3c414384a9cbd01f38847b40a09490f91701fedcd46ea5be7.png)  
Notice how our script `extends Node`  
So our script derives from the Node class, this means that all the functions and variables of the Node class are also available in our class.   
Godot actually has a very nice way of visualizing this. When adding a new node, we can see all the nodes available to us.  
![picture 68](images/634dcefe68dbce8e41e7400641a43c8072450387bc59d71507e7644c611dc48e.png)  
But some of these are organized under other nodes. That's because these nodes inherit from the top ones. For example both AnimatedSprite2D and Camera2D inherit form Node2D.   
![picture 69](images/ac6652387fc6bc50afa2987461097f38e2dcb7cac53ae4f7341b50292e7bd7e2.png)  
This is because Node2D is a base class for all things that exist in 2D space. So since both a camera and a sprite needs a position in our world, they both inherit from it. And even cooler we can actually find our character class on this list as well.    
![picture 70](images/d066ed3c3df2bdaca2ec0c5bed5a74de9af428b223457dd3bcadd08330836252.png)  
That's because when we create a character class, we're essentially defining a new node type.   

#### 23 . Composition 
Even though godot uses inheritance for its nodes. There are often better ways to structure your code. Godot actually leans itself really well to another way called `composition`.    
看这个视频：  
![picture 71](images/af29ab7069d4fdbf6c8db392eb84aea2f288a9ecf6b34b517798351c8614783b.png)  

#### 24 . Call down, signal up
When writing GD script, there are of course many best practices that we can choose to adhere to. One that is particularly important is call down and signal up. Which we use as a rule of thumb when communicating between nodes.  
Every scene in Godot is a tree of nodes, and the beginning of the tree is called the root node, which is the highest in the hierarchy . When looking at two nodes, where one is right above the other, we say that they have a parent child relationship. And the child might also have a child and so on.  

Call down , signal up means that nodes are fine to call functions on the nodes below them in the hierarchy but not vice versa.   

Instead, nodes below should use signals to communicate that something has happened.  
![picture 72](images/6db2ef81d8f11f008adb97cd8ce58397d3165d2ea12e7cb7ca855a2abbd0c3ee.png)  
The nodes above can then connect to these signals as they choose and act accordingly.  
Think of it like real life, parents are allowed to tell their children what to do, but children shouldn't directly command their parents to do things, instead, children signal their needs to the parents and the parents decide the next step.   

But what if we need to communicate between two nodes that are on the same level. You guess that these are called siblings. well here the common parent is in charge of connecting the signal from one sibling to the function on the other. This is most often done in the ready function right at the beginning.   
![picture 73](images/64f42f3d765552a992b27aae3bdbd3a1a93906f96e2421e53b535c810e01e5fb.png)  

详细可以看这篇文章：  
https://kidscancode.org/godot_recipes/4.x/basics/node_communication/  

#### 25 . Style 
During this video, I've tried my best to adhere to the official GD script style guide. These are the conventions we use for naming and order to keep our code elegant and readable for others.  
链接：  
https://docs.godotengine.org/en/stable/tutorials/scripting/gdscript/gdscript_styleguide.html