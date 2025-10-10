### Godot Beginner Tutorial(三)
#### 1. Enemy  
（1）since this enemy doesn't need to collide with anything, we can just go ahead and use a Node2D as the base. Let's also add an animatedSprite2D.   
![picture 1](images/59410133d969a170f7fc2e9f64bba1eacbc81206fb1cb28997c77beca38ab9cc.png)  
![picture 0](images/9ee69da5130758c412e8c808181ea3bba576f6673f80fb8b1a40651609a6d536.png)  
第一行：the enemy kind of waking up  
第二行：an aggressive idle animation  
第三行：enemy takes damage  
![picture 2](images/93b2e3bc9466a60faaa13a0a90472bbdf743545a7d083aa8fcecf335604f6b63.png)  

(2)挪到这里  
![picture 3](images/42f97472ecd179c5388abe807cf53b90ee42e46d9bfe3731d96e68527017bc7e.png)  
![picture 4](images/2674683cd002ed24ebc9f1e69eabb04d494859d713a9541697dc16dd178177fc.png)  

（3）Because we made our Killzone into a reusable scene, we can simply use it for our enemy as well.   
![picture 5](images/0efc40262c83a5de9ba298184f9f4125afedfca16920b71a213f4022935442b2.png)  
![picture 6](images/c011b7e4aa3bf32435c861abffc436f1f39b999e23b35b21084ed9eb84b2ef4e.png)  
![picture 7](images/271a4c11a5a372e3668bec70e0b83cb70ef1e703dafbca55fbe3ebceb625e669.png)  

![picture 8](images/0b41ed4a692afe6973cdc0a0f3e6fa8fdbe7c21cb2f24212ff90318b3001e7e5.png)  
hold "alt" to scale uniformly.  

![picture 9](images/5f3b136b9d85ba1e462872a8b3a02264818f95f7a64c501fdac549ecf93c4f93.png)  
改名并保存。   
![picture 10](images/158287314537f687df252c3bee146003e9905d7f0f02cd21b04b507fbeb464db.png)  

(4)Let's make our enemy move back and forth.   
We could of course do this using an animation player just we did for our platforms.   
However, I think it would be cooler to make a script that moves our enemy to the right until we get close to a wall in which it changes direction and starts moving left. This way we can simply drag and drop the enemy between any two walls in our game and our script will do the rest.  

So let's start by making our enemy move to the right.  

【基础知识】  
delta is the amount of time that has gone by since the last frame. If we are drawning many frames per second, delta gets really small.    
![picture 11](images/5c20b225773873f6a758a33612d17166016afd000d3725559b31dc84021c25c9.png)  

If we lag out a bit and are not drawing as many frames, delta becomes bigger.  
![picture 12](images/587918b76f898d04a062882b02ecd29395d0461e5230cd94ce2e611499294d29.png)  
Because of this we can use Delta to compensate for variations in frame rate.   

If we have a high frame rate, we want to only move our enemy a little each frame, and if we have a low frame rate we want to move it a lot.   

In other words we can multiply our movement by delta to make it independent of the frame rate.  

所以这样，this speed won't change from system to system.  

```py
extends Node2D

const SPEED = 60

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	position.x += SPEED * delta # moving 60 pixels per second
```

(5) Check if the enemy gets close to a wall. For this we'll use a new type of node, the raycast node. Raycasts are invisible rays that we can shoot out to detect collisions. 

所以在Slime下新建node：RayCast2D。  
![picture 14](images/8e98d3f63236899c307911ef512929aba7ab46ca57bae40cfff7c332dc3e42f6.png)  

In our script, we can reference these nodes just like we did with our timer. we simply select them both, click and drag and hold down Ctrl while releasing. As you can see, this creates two vaiables.   
![picture 15](images/2db72db3cc4d848ece74d5a601751fc5f06fbf23470e7c277996ba024bc56727.png)  

slime.gd 代码：  
```py
extends Node2D

const SPEED = 60

var direction = 1

@onready var ray_cast_left: RayCast2D = $RayCastLeft
@onready var ray_cast_right: RayCast2D = $RayCastRight

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	# every frame, before we move our slime, 
	# we will go ahead and check if we're currently colliding
	# to the right or the the left.   
	if ray_cast_right.is_colliding():
		direction = -1
	if ray_cast_left.is_colliding():
		direction = 1
	position.x += direction * SPEED * delta # moving 60 pixels per second
```
(6) Luckily, if we go inspect our animated Sprite here. Under offset, we have this flip property which will simply flip the Sprite.   

不要勾选：   
![picture 16](images/202d33f7262d11ba695b14a48ec0e7042f9eb555230f592f7fcf4515b67b1019.png)  

AnimatedSprite2D把它拽到代码中(ctrl的情况下)  
slime.gd代码：  
```py
extends Node2D

const SPEED = 60

var direction = 1

@onready var ray_cast_left: RayCast2D = $RayCastLeft
@onready var ray_cast_right: RayCast2D = $RayCastRight
@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	# every frame, before we move our slime, 
	# we will go ahead and check if we're currently colliding
	# to the right or the the left.   
	if ray_cast_right.is_colliding():
		direction = -1
		animated_sprite.flip_h = true
	elif ray_cast_left.is_colliding():
		direction = 1
		animated_sprite.flip_h = false
		
	position.x += direction * SPEED * delta # moving 60 pixels per second
```

#### 2 . Dying 2.0  
(1) Let's start by adding a slow motion effect when we die. We can do this by changing the time scale of the entire game.  

So, inside of our Kill Zone, we'll open up the script here.  

killzone.gd代码：  
```py
extends Area2D

@onready var timer: Timer = $Timer

func _on_body_entered(body: Node2D) -> void:
	print("You died!")
	Engine.time_scale = 0.5  # go at half speed
	timer.start()


func _on_timer_timeout() -> void:
	# then when our timer runs out, let's set this back to default. 
	# because otherwise we will actually still be slowed down when our scene reloads
	Engine.time_scale = 1.0
	get_tree().reload_current_scene()
```

(2)Notice that it also twice as long before the game restarts, because everything in our game slows down including our timer. But I think it could be even cooler if we remove the player's collider to make him simply fall off map.  

To do this, we need a reference to the player, we actually already have this here.  

这个`body` refers to the body that entered the area, and since the only thing that enters the kill zone is our player. `body` is our player.  
![picture 17](images/5b47f0c8b47339e43b5dfae3118a5eece21169084599589da31b2db013754e24.png)  

#### 3 . Player 2.0  
（1）  
So far we've been using the character movement template pretty much as is.  
We need to modify it in order to add animation to our player as well as change the key bindings that we use to move. 

![picture 18](images/170aff1c6c4f915c4581fc30926db1b6b1d898078116e05080289e2a366043f2.png)  
There's also a variable here that defines the gravity based on our project settings. By default this is a value of 980.  

`_physics_process()` is very similar to the `_process()` function we used for our enemy. However while process is great for a lot of things. There is one part of the game engine that really struggles with not knowing how many times per second it is going to be run, that is the physics engine. Physics in general need to update at fixed intervals to avoid janky behaviour. Luckily `_physics_process()` solves this problem, because it runs at a fixed rate, 60 times per second by default. This is independent of your game's actual frame rate and helps physics run smoothly. We use it for anything that involves the physics engine like moving something that should collide with its environment such as a player character.  
![picture 19](images/707037a689ad36fdba14815c4769cb76de122839204fb3e557d2ff22334b0f3a.png)  

(2)  
解释player.gd代码：  
```py
extends CharacterBody2D

const SPEED = 130.0
const JUMP_VELOCITY = -300.0

func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta
# yaya: this means: if the player is not standing on a surface, we add gravity

	# Handle jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = JUMP_VELOCITY
# yaya: this means: if we press the space bar, and, the player is on the surface,
# we jump.

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction := Input.get_axis("ui_left", "ui_right")
	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()

# yaya: this means:  And then we get the direction we need to move in based on what arrow keys are pressed 
# and move accordingly.  
```

(3) Let's start by rebinding some input keys. For this godot uses an Action system. We create actions for anything we want to do in the game.   
jump is an action.  
so it's move_left or move_right.  
We can then bind keys to these actions.  
![picture 21](images/6799f449ba79395f453d2bdde7e363c02e965e8a9b674edb72c8d1f5de05faa9.png)  
![picture 23](images/8c7254782e7f48117aa92ecd38f6eaaea629ddbd065b8619c13e6cbde162faa0.png)  
回车键相当于按"+ Add"键。  
![picture 24](images/c92096bd55061dae4a5b7443b2d9437aedd0aa4cf36c731f659a80d198a7c1e0.png)  

By default, godot uses some built-in actions that are meant for navigating UI. This is why it says things like `ui_accept` here. Let's replace these with our own actions instead.  
![picture 25](images/1c31844b4817fa1b1eafa38ab515d20e23fe576c5dea91bced5b4634280d56df.png)  
![picture 26](images/54dfcdf2268fb88823b89e64392ad437ff9f4aec27d4b8c7347f4fffdd34ece4.png)  

（4）The next thing we need to do is to update our player Graphics to face the direction we are moving and to play the right animation.  

Let's start by flipping our Sprite based on direction.  

【1】边按ctrl 边在player.gd代码中 拽入 AnimatedSprite2D组件。  

【2】  
![picture 27](images/bd37448c34d333ef458fde6a9e5fb089a59ec874fb8ddfbbccf0ff7e48088b9e.png)  
![picture 28](images/65d7bf15ad5cccf366337843830d73f89bee28b6e52fe3794a1926cacb614dfa.png)  

jump只添加这一帧。  
![picture 29](images/90b1830526610cc76e2958453fac3512aec534efcb20f9fb2f8312190c9c47a3.png)  

player.gd代码：  
```py
extends CharacterBody2D

const SPEED = 130.0
const JUMP_VELOCITY = -300.0

@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D

func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta
# yaya: this means: if the player is not standing on a surface, we add gravity

	# Handle jump.
	if Input.is_action_just_pressed("jump") and is_on_floor():
		velocity.y = JUMP_VELOCITY
# yaya: this means: if we press the space bar, and, the player is on the surface,
# we jump.

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction := Input.get_axis("move_left", "move_right")
	# yaya: if we don't press any buttons, direction will be zero, 
	# if we press move_right,direction will be one
	# if we press move_left, direction becomes minus one.  
	
	# Flip the Sprite
	if direction > 0:
		animated_sprite.flip_h = false
	elif direction < 0:
		animated_sprite.flip_h = true
	
	# Play animations
	if is_on_floor():
		if direction == 0:
			animated_sprite.play("idle")
		else:
			animated_sprite.play("run")
	else:
		animated_sprite.play("jump")
	
	# Apply movement
	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
#yaya said: this line probably means: slow down until stop
	move_and_slide()

# yaya: this means:  And then we get the direction we need to move in based on what arrow keys are pressed 
# and move accordingly.  
```

#### 4 . Text
There are multiple ways of working with text in godot. As part of a larger Ui or as an integrated part of the game world. For this game I decided to try making the text part of our world.  

In Godot, a text node is called a label. So let's add one.   

As you can see, the text looks really blurry. That's because since we're using pixel art, we actually zoomed in really really far, which makes the otherwise smooth text appear blurry.   
![picture 30](images/a6a5d4ae830cb3d0836406708facae8a2db0fe5fbad5a41cf328ec6b56e1e36f.png)  

原因：可能是摄像头的靠近：  
![picture 0](images/3699d63590e7d842ea42a8342df16fcdd5a980274175f5d407d4dcf650766e65.png)  

其他补充：  
![picture 1](images/04d323320f7feb40ff3633ecbc647435f7550c9c29486d100c1d311f8cf41e47.png)  
![picture 2](images/1027658890211f1b10309c2849d63da4178b25752ab7babe7d326335cc9b73e4.png)  

So we can fix this by using a pixelated font with hard edges to match our style.   
![picture 31](images/86b8171369326e0e6192cc93910677541d419100d778af756519084bb9a7cf7d.png)  


![picture 32](images/971ea275c13ced26745b8475773e1eacd1f7dfd7d7094a020901148e6226dcdc.png)  
Note that we have to use multiples of eight in order for the text to appear crisp, so you can see if I change this to nine, it becomes blurry again.  
16, 24, 32 and so on都可以。  
【鸦补充】：可能原始字体就是以8为基础分辨率的。  
![picture 3](images/e456fa9bddd12779a93345d7dcca2a0372bb3931c33676cb19af049395e3975e.png)  


也可以给字体改一下颜色。  

新建一个node，把那些label都放在底下。  
![picture 33](images/3cdf717e42f07de6d507017a47da31e92fc722acb7a4dfe1e62434343ee91c05.png)  
![picture 34](images/d86838cd539ebb16cddc45f6c8fddcbdbab3280844f5b548ed144847d5881330.png)  

Just like with Sprites, because the player character has a greater Z-index. It will draw on top.  

#### 5 . Score  
To create a score or coin counter for our game, we need two things.   
A script that keeps track of our current score,  
and a label to display it.   

(1) 新加一个节点。  
![picture 35](images/0a1450b126e4c9ddcaa23ce12f13a7a577e6bb833b40cd377a254d50ecea1a98.png)  
![picture 36](images/ddfc8a69fb3074002a963e39ccd5f0f210634a66ea64344074e282296a5f25f0.png)  
然后把它改名成GameManager。  
The reason why we are using a regular node and not a node 2D is because we don't need our game manager to have a transform. In other words, a position, rotation and scale.  

为节点添加脚本。脚本名字不要用大写字母。  
![picture 37](images/c0f422b398e39ccda6321d9919aa0f6179de4cdee59937da71d69f5381e0fceb.png)  

（2）  
So far in our code we've only used the build-in functions of Godot and some that we made with signals. In this case here, we want to create our own function that adds a point to our score and displace it.   

game_manager.gd脚本：  
```py
extends Node

var score = 0

func add_point():
	score += 1
	print(score)
```
(3)对coin脚本引用GameManager：  
![picture 38](images/1f7f83311b94e4342ce75daa94550d473919ac7f65118b2fdff60a22fb8b48b1.png)  
if we just click and drag while holding down ctrl. We get this really weird-looking path. `"../../GameManager"`  

Because the GameManager is higher up in the tree than the coins and it's generally bad practice to use paths like this that try to access nodes at the same level or higher in the tree.  
![picture 39](images/299f54ec4572fa89a4d0c328ae30560aba4a1a4611525c0783b4d940f3cb2b4a.png)  

Luckily because our GameManager is one-of a kind and we are sure that there will always be only one GameManager, we can solve this by marking it as unique.  
![picture 40](images/a44de1130e83f0530807dc6c6ffeb549579d3d7e9d08bcb114501e994dbd7cd4.png)  

现在再拽就是这样的：  
![picture 41](images/2a496df272d729d9a394d4ac9d927fb857caaf6fb14009cff7b67dbd2b2d4496.png)  

（4）新加个label。  
![picture 45](images/b1baacb06da599c6c8793e4f392dd7884d4e9b5499c59c2deb300b8e3b5bc39c.png)  
![picture 44](images/17f129955134643b6f5494b00af597da63c1c5c80622d73cf393f708d4d8f3de.png)  
autoWrap是自动换行的意思。  

把它的字体替换成这个：  
![picture 48](images/847eb4f4b475815a5254cf88db8b6c90336a7c0b7394c0304950c00adf1bddb4.png)  
![picture 46](images/20415f56b8229a765a68f6ac88615c104083735417b458cc95726cd07b9603bd.png)  
![picture 47](images/a41b31e365697fea6041ad98044287cb2aa290c1cc1119f0b7d5e34a2a85269f.png)  

（5）把这个label重命名，并拽到GameManager底下。  
![picture 49](images/540fb949670418880f42eb98dfeee972cb638749fcdc28baeb17e184eba783cc.png)  

（5）coin.gd的代码这样写会报错。  
![picture 50](images/b2086c097e48c078262d76a92a14986e5ed4ae6a008a816d50f00a4da2d54cd0.png)  
coin.gd正确的版本：  
```py
extends Node

var score = 0
@onready var score_label: Label = $ScoreLabel

func add_point():
	score += 1
	score_label.text = "You collected " + str(score) + " coins."
```