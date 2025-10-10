### Godot Beginner Tutorial(四)
#### 1 . Audio
（1）To play these, we need a new type of node.  
![picture 0](images/a5fa854a20ee5763166b71893f87556cee0ea90e8e0c2c20c884242c77e282d8.png)  
然后重命名这个节点为Music。  

拽过来。  
![picture 2](images/d987ab68a793711666ea6f124657c973ed8f71dfca4b558740c218cd8cacbf1c.png)  
![picture 3](images/67d8d2bf46ec9eb72e3120dd45d334e68f59d4fbf7aff2f0696414bb57797307.png)  
勾选enable。  
再点击reimport。  

（2）降低音量的办法：  
方法1：  
![picture 4](images/476eb5898ebcc56ce8daccd1a5f3e68078180c0c0a6a87a110a76d9d2affd869.png)  

方法2：  
![picture 5](images/6593f2cf830c7fcec7f2fe2a174c680e40805e79c0e152524a7b4297285ccfd9.png)  
We can use the audio tab here at the bottom. This is actually a fully functioning audio mixer and we can add different buses to control our audio.  

Let's add two : one for our music, one for sound effects.  
![picture 6](images/bb2f1038eea9d0772ced64f000c6686278f8e74d3db850e9652e915053f7e391.png)  

把music节点的这里修改一下：  
![picture 7](images/8e76959efc34e2099a29dd255b39ddb8bfa69e857888de4c2f166947f9f3a9df.png)  

把它改成-12.0 dB。  
![picture 8](images/2a930620280cf155b91c877bdb62ab78c8379eef212ecc9e430b12b8eafba217.png)  

（3）Unfortunately it's going to restart whenever our scene is reloaded. A quick fix for this is to take our music node and make it into a scene.   
![picture 9](images/7441ec459ebca0a8ddbbb6083e3b1e386cd748aeffedf70b972f98ce9281c4aa.png)  

and then we can add this scene as an autoload. Autoloads are global scenes and scripts that we want to persist throughout our entire game, no matter which scene is currently loaded.   

【1】我们把这个节点删除：  
![picture 10](images/f993ab2f997830e98694e07f0b765f9597c2256b69d2628f16fe8ac0b66e723e.png)  

【2】  
![picture 11](images/4937b9667ecb1401047d54d27fdd5b04dd00f9736da32aa828e10509bfd01e1b.png)  

(4)SFX     
【1】  
![picture 12](images/de2d5ee0e5430b02f9b1448471ad18ebc8567586e0e990fb26d821578f644872.png)  

![picture 13](images/92cc04f976a8ca874294c105abe3f3570e2ab34fb48dd9fb282feed87de4972a.png)  

but since we're removing the coin immediately by calling the `queue_free()` function, the sound won't actually get chance to play. We can of course fix this by adding code that waits until the sound has finished playing. But then we might get weird functionality where we try to pick up the coin multiple times while it's playing and it will still be visible until the sound is finished.  

So let me show you a really cool trick to get around tricky timing things like this without writing any code. That is using an AnimationPlayer.  

And the first thing that we want to do when we pick up the coin is to hide the coin Sprite.  

So I'll go into the AnimatedSprite2D节点.  
![picture 14](images/9ac8312a62b078d44fcc0a889219cf453863dd24dcf2ee10b0fdd2b71bad9ee6.png)  
![picture 15](images/60b3d900c0e73b4d412b1af23b25a8d27c066accf092e004f5725ada19aad028.png)  
Godot is automatically going to create another animation track called RESET that will simply reset this value to its default state.  
![picture 16](images/b24a5757eb9c969cb56e76cc966a3776b51b14a3eb9568a38927e40352697855.png)  

【2】  
![picture 17](images/534b7d2afdd0bc56d2f6c24cfece0f1b156bc056408f3f5936456a577bfd50ac.png)  

And after 1 second here, we want to remove our coin. And this is a really cool part about the animation system is that we can actually add another track here that is used to calling functions.  
![picture 18](images/7be4b3805420dd078d52d6178a8c30d7b5adb22fb2f6657da3c495dde2fc1bd9.png)  
![picture 19](images/69d21f1ab14aeef0f6096dcd2e21bfc92801609741ba779d474c7660c093aec6.png)  

![picture 20](images/c8482db0955d73c81834c29d84257f5caf6bd7c51abf626c70ab5419da0469ff.png)  
![picture 21](images/6104a9d4300b9d249e891dd566f68f032c8557360fc504ae94d9c02a1bae1e63.png)  

【3】coin.gd的代码：  
```py
extends Area2D

@onready var game_manager: Node = %GameManager
@onready var animation_player: AnimationPlayer = $AnimationPlayer

func _on_body_entered(body: Node2D) -> void:
	game_manager.add_point()
	
	#remove the entire coin scene from our game
	animation_player.play("pickup")
```

#### 4 . Export
(1) The first time we are exporting our game, we need to download the export templates.  
![picture 22](images/d3d3191c7c326d17e7be4868c2625b4f0a173ba5fc0988fb444a43ee0883261d.png)  
![picture 23](images/6d067db05654f9af17f1ce1b301d30bf795d7ac7ab474c9d8da821a7c7e90318.png)  

(2)  
![picture 24](images/42ad265e777482e1312a8a230cbed46d948d7649e19a9f6c7bf927f9488aa21c.png)  
![picture 25](images/9a39b9fc926489f2079e9a44159b34025eb8e4dc86a92bde741edc4827349f02.png)  
![picture 26](images/e2397c22f0d6aae42e0535b8be63d96a4e26c42c73b5722eb20e52d94fc06623.png)  

- `Embed PCK` will export it into a single file

![picture 27](images/365cafcb64079d1d02611da0cd252bde617517e3564a871d2f64234d56541b30.png)  

![picture 28](images/c7c87462b98530e130f6d67354883a88cba7bba11c40155e30b26d28c0f7ad3b.png)  

