### Godot Beginner Tutorial(二)
#### 1 . Platforms
（Some that move, and some that don't）  
(1) So whenever we are creating a new element of our game, we begin by making a new scene. And for the root node here, I'm going to hit 'add' and search for the AnimatableBody2D. This is a physics body that we use whenever we want to animate a node and still have it collide properly with other nodes in its path which is perfect for moving platforms that should still collide properly with our player.  

(2)  
![picture 0](images/4fe483febee717eb3a8bd64549d5044307fcb8f44e41aed02f06d8443f2e79db.png)  
![picture 1](images/f39e70a908af76fe69eb20ebe601f9a896f7db82ecfe7be0d94eecd7029dc4c1.png)  
![picture 2](images/7994285fc4173aaabb4db482f329b3a010f3d6291429abc52a146b80dee5e90c.png)  

(3)  
![picture 3](images/6a9068cb4ca0d86d72fd0cb5849ef5f85b9773d9322f2259194ddbc30a9e3ff4.png)  
![picture 4](images/a57b5f2553a76c1b8cb82f36e721be70741a7c09b73497a65f6423b12dd25a99.png)  
![picture 5](images/4da32bca37504b22e0b651f1e48c3b8d48ed16ad5a78e25888e7a3fafd2e38f9.png)  
![picture 6](images/dab829becff59e4df3e76b10aa798d430c00bea10e22ed733b3214fb214c2512.png)  

(4)但是现在我们不能jump onto the platform from underneath.  
To fix this we turn it into a one-way platform.  
![picture 7](images/66b60edd96654b29c97e3dc6d1b0d12fd3a294b13d3d34d495a93ff7bfc7f33c.png)  

(5)但是现在 the player is currently passing behind the platform, this is because the platform is currently after the player in the tree. This means that each frame the player is drawn first and then the platform is drawn on top. We could just move the player in the tree, but I don't want to depend on that. Instead, we fix the draw order by changing the Z-index of the player.  
![picture 8](images/badea2245b338c29fbf5e15f0d2c4f229269ee896655a0b5d6cb24924edfda21.png)  
By default, all visible nodes have a Z-index of zero. Because they all have the same index, they are drawn according to their order in the tree.   

(6)   
【1】We might want some platforms to move around to increase difficulty, so let's use animation to do that.   
![picture 9](images/888bfd2c995acab8fb739329e7513d62c878d45da6313639f223f980e53fbf9f.png)  
【2】  
![picture 10](images/b7a91bf6561f2a3fdac90bfc24d12e2cf78c2f4d1eb84f26f503fd6dc0b95209.png)  
【3】  
![picture 12](images/82397ad3c6a6d045f357c95844562ba84f90065f0ce9d48ad819b88308ec0dd6.png)  
![picture 11](images/2bb9d2f40a43e1716e568233151a58402ccd510c84917cc9ec8553ad59f40d72.png)  

按住shift按照一个axis把它移动到这里。  
![picture 13](images/9118e2cba74e5aecb0b0923425b798f88a73bdbbc2c45e9335cc95778974af12.png)  
![picture 14](images/8c4bb1586a5804131c8012315cabe3a0aecf024b1887c1787189c0b7ea2f2709.png)  
![picture 15](images/b27fc2483602d87dae20fb7ebca81356d2e90e27ea95fe50dcc06db29d681f89.png)  

【4】如同ping pong一样来回摆动。  
![picture 16](images/103801ad874364fb578943ebc7528ca2df556683bcfb95842558938ab508fc15.png)  

【5】如果觉得时间太短，可以改这里的数值。  
![picture 17](images/bb7639cfac1cf69b358422f11d85bbef6bffedc10cbab3cd6a176b5302d2b8da.png)  
再把last key frame拽过来。  
![picture 18](images/82eb73dfecf6aa622bc1ed91b9208121148b067ed8bd5ae3816b24875d95cf53.png)  

【6】  
![picture 19](images/79c43a7395d4e31192c2f3d86345d6f411629a7b7d50842d2bea5b27323f155c.png)  

#### 2 . Pickups  
（1）新建一个scene，添加根节点Area2D。  
This is a type of node that we use whenever we don't want to collide with other objects. But instead we just want to define an area in which we can detect collisions. So we simply use this to detect if another body enters, such as the player character.   
![picture 20](images/04f0aee999d0ba181239348d4a3b3e068304e13b564a11cf2e7e279574f4652a.png)  
![picture 21](images/2bcc0b4bd0535811a6671fb8ba487245760f407c47b4aa82bd5d0985a33e7076.png)  
![picture 22](images/fe5c9d5402ed1aea2d81a5be86642230b444a380b7093d400081f56480eddded.png)  
![picture 23](images/94e250dbdca51459aef11f6fb27ed7dab92d6fbbc4f6ef85f9e33a2a5db8c1e7.png)  
![picture 24](images/35af6218526f9abc4be643783f0885bc2181d1ea689a08cc42dc9553c498943a.png)  

![picture 25](images/2bf6968b4995966eb5525b21cebcde995687f273fa11bc08039dd36176413e22.png)  

（2）You can always use ctrl+D to duplicate.  
![picture 27](images/5cad8f43b68296b60ff23073dd527a6bf72eb8c67de35ecd67b67bba898b8601.png)  
(3)  
![picture 26](images/e810fabee2deda57cde6fa4b13c4eb8809a5f9052c28a06dabc44f27c5474840.png)  

(4)Script  
![picture 28](images/5a33d542c17e337060dc91f77f41c9e1456a271187c17597027dc3ba51fcab5f.png)  
- **pass** keyword which means do nothing.  
- the ready function is called right when our node enters the scene tree, which is just at the start of the game. So we can put code here that we want to happen immediately.  

We only want to do something once our player enters the coin area.  
and for this we use a signal,  
Signals allow us to trigger code based on events that happen in our game.  
Godot has many built-in signals we can use.  

If we select our Area2D node(名字：Coin)，and go to the node tab.   

We can see all the signals on this node. We want to use the body_entered signal, which is triggered whenever a physics body enters the area.  

To connect it, we simply double click it and hit connet.  

![picture 29](images/6d74c97388ac7e3bc8950662898fd1b1dfd67a42f435e05748b16acb2fe081c8.png)  
This green arrow shows that this is triggered by a signal, so let's here try writing a print function.  
![picture 30](images/0ae3fb9d541cf7868d2ff07e5a5b993d97d979ed817e239a92d4e433fa67b885.png)  

（5）但是这样做，如果当其他游戏物体，比如平台碰到金币时，也会触发这个print函数。  

To change this we can either use code to check what body enters the area, or we can simply put our player on a separate physics layer.   

把player的layer从1改成2。  
![picture 31](images/d07ef87e2c4a11c5f4d8eb1ebcf1ca87c61bca1d8bff9f09e6cef9d3f9bbf54d.png)  

In our coin, we can also go under Collision, we can actually have the coin itself stay on layer1, we don't need a separate layer for that yet, but we want to make sure that it only detects colliders in layer2. For this we use the mask. The mask defines what layers a node collides with.   
![picture 32](images/0fc683abc0a470fe42c5ee8c8eabb2b1ecfaa7749589a7b7594147945d8963e8.png)  

```py
extends Area2D

func _on_body_entered(body: Node2D) -> void:
	print("+1 coin!")
	
	#remove the entire coin scene from our game
	queue_free()
```
#### 3 . Dying 1.0
（1）  
So we happily move along in our world until suddenly we miss a jump and fall into the abyss and then, nothing happens.  

The first thing we want to do is limit our camera, so that it doen't follow our player when we fall down.  

We simply select our camera under the player, go under limit and we can set a position limit for the left top right and bottom part of our camera. In our case we need to set a limit for the bottom position. To do this, we can use the ruler tool here at the top or simply press R. and measure from this baseline here to where we would like the limit of our camera to be.  
![picture 34](images/6b9e16e3f57f2ffe0a703ce7feda628d428794c2fda61cc9de5af39299d91c22.png)  
![picture 33](images/f66eaadebb2979bd9c1b88a1092056dcb99f4903c05a36dba47ad9c389173389.png)  

量完之后回到select mode。  
![picture 35](images/54ebe5226e3b7767d2fa7d9a5f51e41cc038f1bc2284ca474e211c0dd71c5b51.png)  
![picture 36](images/2d6f4fd90bbfdcb5e6500db6bd3c439c000aeb18fe21e70385c514514a7e8c7a.png)  

（2）next we need to detect that our player has entered a dangerous area and restart the game, In other words we need to create a Kill Zone.   
I'll show you a really cool way to do this, that allows us to reuse the same Kill Zone for more than just falling off the map. Such as for spike traps, enemies, all kinds of elements of danger.  

所以我们新建一个scene。  
![picture 37](images/a4724d4d56f833596876fe1761f88d833929ac889bbe136febed92a2f73598a3.png)  
![picture 38](images/3e9b8eeeab979d38f89f1e6ae30ba5f8681b4e5578f9c2d80dfed3a3bfa168dd.png)  
为了只感应player。  

We want add a collision shape here, that's because we want to be able to reuse this for all kinds of elements that might have different shapes.  
（鸦补充：他这话没说明白，应该是：我们不能在Killzone的scene加collision，应该在Game scene底下拽入Killzone，然后再在该killzone节点里面加collision节点。  

把该scene改名为Killzone并保存

（3）  
![picture 39](images/eb7110b85cee312f41b578f1910da49d7a522d2f899a1d68d67760b3227df02f.png)  
![picture 40](images/2cfd11adf9d51eb5cad6f4cae46614135f286cb2307dababcd7c30e72bb3bcb4.png)  
![picture 41](images/6df742c350f419169522fcf49d90920f11fdd8c3e5b073213e7a131a499008ab.png)  
用这个按钮移动到这里，  
![picture 42](images/de9583993f3f8128d1a7d1eda87cb0296d357912ec0013e37e83a13bb405cd28.png)  

（4）对Killzone的scene建立脚本。  
并用body_entered的signal。  
![picture 44](images/8a018b20e64d36debc6b6c3f783b01cfccd2f0ad4ee7a8e2982352def18bc81c.png)  


instead of immediately restarting the game,   
let's add a small delay.    
We do this by using another node called the timer node.  
![picture 43](images/927b4edb074f2e551ae28cf91829b14998491beb6200cfb955f70e23478fa36c.png)  

![picture 45](images/3c1d51d40a72b116ffc3bee29c0f626c4599c8a471d5b7e68cbc4349a6c01a6e.png)  
Let's also make it a one shot to make sure that it doesn't loop. 

We can then start this timer in our code, to do that however we first need a reference to it. Luckily that's as simple as going to the top of our code clicking and dragging the timer and **holding down contrl** while releasing.  
This creates a variable called timer that automatibally finds the node using this path.  
![picture 46](images/526b88cffa0d0b2c93405ba0b43201dfd53a67972ed26f673f26873321706a35.png)  
![picture 47](images/a0d307b67b1464ebe0ea0dc495454cef2acc6723abde792cd01dbc4e4f9b4354.png)  

`$Timer`这个是path。  

Path specify a way to get from one node to another in the tree. 

举例：  
![picture 48](images/b167b869752f41c7093b06951ea7688f82a547df7850448a227d1fff3724752c.png)  
To get from the game node to the camera, the path looks like this, it goes through the player and ends with the camera.  
![picture 49](images/417dbfdaf505e06aba14f8ec82bf62067a2adf5f65241108b483d1332b4502fd.png)  

In our case where we just want to get from the Kill Zone to the timer right underneath, we don't have to go through any other nodes, so the path is simply `$Timer`.  

We now need to trigger some code when our timer runs out, and again we can use a signal(timeout()) for this.  

killzone.gd代码：  
```py
extends Area2D

@onready var timer: Timer = $Timer

func _on_body_entered(body: Node2D) -> void:
	print("You died!")
	timer.start()


func _on_timer_timeout() -> void:
	get_tree().reload_current_scene()

```

#### 4 . World building 2.0  
（1）catergorize nodes：  
【1】game scene新建一个base node。  
![picture 50](images/08229479e0c9cdceaacdad52431e5eeaca6c189904a0265cfe0893f673e6d35f.png)  
【2】rename成Coins  
![picture 51](images/1da81d2a8e9346345b678d2840a267139843ca3ba675bc9ae7535aef4b14b767.png)  
【3】再把所有的coins都拽到下面去。  
![picture 52](images/fcf355c2cf32fd59312296299839c5063f5ad5ddc9a044f6f854ef3bfcbd8a5e.png)  
【4】同样的操作把Platforms也整理一下

（2）然后再tile map再新增加一些东西：  
![picture 53](images/24fdcf69d1d16114b8303159505ef139b84d6e50e2d53332712073d168a23e1f.png)  

（3）画背景   
【1】   
把当前的layer改名Mid,  
新加一个layer名叫Background。  
把Background 的位置 move to the top, make sure that it's **drawn first.**  
![picture 54](images/7b60e606a93a6649820bb88aa1a9f20b4dbc0d710cf1a291bbbf13fbba446cfd.png)  
![picture 55](images/7ed4f2ae95119897eb570760d34ac8d752f3eee6054540cffe4b264947f3eaed.png)  

【2】  
![picture 56](images/f146513e4a327d17a1f2b7a905b7bb6f61e6d47329722f702f119b7111d1ee47.png)  

【3】  
A nice trick here is to use the rectangle to paint in a lot of tiles at once.    
![picture 57](images/e7c903583cfe6b63015204edde9b9587c8b5fc4baae3f01bee7653af27458ed5.png)  
![picture 58](images/03e680f64cb6b3c155a2c4b73d6d1cb23e6f220ef5fdad1d36e837cf1017eeea.png)  
