# unity散笔记（一）
## 一 . UI anchor
可以看这个链接(谷歌搜unity ui ancho就有r)：
https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/UIBasicLayout.html  
网址里一些关键内容的提取（读英语太费劲）：   
1 .  
![picture 0](images/555cb8149a8c6c3116cb64f036f7cd6b5ff64f086f9b6a31dd0f493ba34dd237.png)  
这个图标在2021版本的unity的这里：  
![picture 1](images/6e268d88f137334ad3991f16ff0fdcce00eecd71f3a614a4a33a780829e15218.png)  
2 .  
Rect Transform是UI独有的。  
3 .   
anchor就是4个三角形组成的小花花。   
作用：  
保证子物体的长方形的四个顶点，到小花花的距离的连线是不变的。  
![picture 2](images/638b31012af125d3df00a0b538bcaee64b33c16bbf13aa25e4c9a577baaab3af.png)  
比如A到B点的连线。  
不管怎么扩大缩小父物体（那个最外面的白色框框），子物体AB两点连线都是不变的。

4 .  
（1）什么都不按【只会移动anchor到黄点位置】：   
![picture 3](images/e6ee312098c4478bb095bd438406b985c24450c97d43918639b74a0216e3d16e.png)  
 (2)按shift【移动anchor，同时移动pivot到蓝色的点的位置】  
 ![picture 4](images/39a413b70791ae95dbbae7384d473d86c1991919f23b354d2681dd33a84d106f.png)  
 同理可以把内圈想成是子物体，外圈想成是父物体。pivot（即子物体旋转中心）移动到图上对应的蓝点位置（与上图比多出的蓝点）。  
（3）按alt【移动anchor，同时把子物体或移动或拉伸到指定位置】  
![picture 5](images/809f48772b028406722251b3e2e8837b5b45b35bfb152c6fea89e87708eb835a.png)  

5 .   
(1)当anchor小花花是集中在一起的时候，显示的字段为 Pos X、Pos Y、Width 和 Height。Pos X 和 Pos Y 值表示pivot和anchor的相对位置。  
注：改变POS的话anchor是不变的。子物体的pivot一般都在子物体中心【没改过的话】。所以可以计算子物体的pivot相对anchor移动了多少。  
（2）当anchor三角形分开的时候，字段变为 Left、Right、Top 和 Bottom。  
选中这个Left，  
![picture 6](images/fd78ca42489000ccc32386dc9360176b8b1fbe6654b5575901a5e5b616d4f895.png)  
会看到这一段距离是这个left的值  
![picture 7](images/514c7ccfd7671986ee295f369f63dc7d2b3e3123ad0d28a22a0fd6cbc2f66b9e.png)  
（3）当anchor不是全都分的时候  
![picture 8](images/fe8f14c3e799db6f3c9ba17359cf8c63be56645156b1983c8496a26d72092584.png)  
![picture 9](images/7e74c621ccd04bea13a7c211029a37807b7b0a1fc16953ae07c15a5971d5ed82.png)  
为了保证蓝线的距离是一定的，需要绿色的虚线是一定的，竖着的绿线表示红色方块的height不变，横向的绿线表示一直保持横线这么长的距离。  
![picture 10](images/96769e2dae4546026000f7ae8b6403b5004f08f64e885ca1951aefdd820eeb7a.png)  

## 二 . Raycast
1 . 
默认Button中包含了一个Image组件和一个Text组件，只要其中一个勾选Raycast Target，那么这个Button就可以响应鼠标事件。

UGUI的鼠标事件是通过射线检测实现的。当点击鼠标时，Unity会遍历当前勾选了Raycast Target的所有组件，找到最上层的组件来作为当前点击的响应点。所以场景中勾选Raycast Target的组件太多的话，就会降低游戏运行效率。

然而Unity在创建Image、RawImage、Text等基本组件时是会默认勾选Raycast Target选项的，如果到了项目后期，逐个组件检查是非常麻烦的。因此可以重写创建方法，在创建时不勾选Raycast Target选项。这样就可以避免UI中出现无用的勾选了Raycast Target组件

2 . Quite simply, if selected (check box is checked), the UI element will block the raycast (i.e. your mouse click). If you don’t have it checked, then your mouse will not work on that button, **and the next thing below/behind it will catch the raycast**.

The point is to remove the mouse-clickability from UI elements (like maybe a name tag) that don’t need to be clickable (raycast target=false).

Likewise, if you have a UI element covering half the screen (like a window or something), you probably don’t want to click things behind it so (raycast target=true)

No performance impact either way.

3 . 
这个网址没看太懂  
网址：https://discussions.unity.com/t/understand-how-raycast-target-works-on-ui-elements/189152  
的OP认为当取消勾选raycast target的UI后面有一个3D物体时，鼠标点击事件会到3D物体上但是事实好像并非如此。  
- You can however use both raycasters at once, Graphics and Physics, and use EventSystem events only.
- I have found that multiple raycasters can steal a click from each other.

## 三.When to use [SerializeField] and why?

1 . [Serializefield] is just use for showing a private variable’s value on Inspector. You can easily change the value like public variable. But None can access this value from another script or places.

虽然上面说了NONE。But you can with the Reflection API. For 99% of uses cases if you are using reflection to get private members your approach is **flawed**.

2 . Serialization is the process of taking an object in ram (classes, fields, etc…) and making a disk representation of it which can be recreated at any point in the future. When you apply the SerializeField attribute to a field, it tells the unity engine to save/restore it’s state to/from disk. You mostly use serialization for the editor, and especially when building your own editor windows and inspectors.

For most games (especially simple ones) PlayerPrefs is sufficient for saving state to disk. 

## 四 . Unity EventSystem入门  
https://blog.csdn.net/qq_58870988/article/details/138547296  
讲了手柄，按钮触发间隔，EventTrigger（触发事件），2D3D的raycast。

## 五 . Run In Background
到达步骤：  
- 选择File -> Build Settings。  
- 在Player Settings中，找到Resolution and Presentation部分。

**Run In Background（后台运行）**：
- Run In Background属性用于控制当应用程序失去焦点时，Unity是否继续运行。  
- 如果勾选了此选项，游戏在失去焦点后仍然会继续运行，例如当我们切换到其他应用程序或桌面时。  
- 如果未勾选此选项，则游戏会在失去焦点时暂停运行，这在某些情况下可能是期望的行为，以节省资源和性能。  

## 六 . Time.deltaTime
![picture 11](images/e501c79621fe767afc4b7df320844a8c90800e5fecabdac09d8ff36a4e32bb12.png)  
![picture 12](images/71680a8942c1200141df79a6f6ca990dcb6f649d4c132f3ae1d31cab480aed3f.png)  

## 七 . forge networking
(1)server里面的物体动，client里面的物体随着动。  
![picture 14](images/c232ce89f67c733a56784d89dfff3cd48300444ab5353a1e8bc75093f73409b4.png)  
![picture 13](images/40ab8c8f71ddcd03580b3b465ee13643544527f8616c78b66fe9ea3afcaba840.png)  
（2）Remote Procedure Call
RPC is all about receivers. 所以会出现一个问题：当HOST连入并且方块已经移动3格后，CLIENT再连入，会发现CLIENT里面的方块没有移动。  
![picture 15](images/c15f1831fe2bb4f78b70fd077b0a1c62d88e930bf3de5faf074a14a4343967d6.png)  
![picture 16](images/f5e236e8502d21f9c811cc0f0f523aaac61a98b74c856671c4f88f20b4421519.png)  
里面的一条评论： Basically for everything you want on the server. player shooting, player movement. everything which you dont want something locally. Locally the data can be hacked. for example you are caluclating the score locally. dont do that. do that on the server and then show the final result.  
（3）Remote Procedure Call Arguments  
![picture 17](images/d4d5039221c309a0103ced2eea33973f507fd4710af8e0d0831bf380fcfbfe80.png)  
![picture 18](images/11809b46124840b51f61480da8ffdc527741a8af2f27f1545b313adeeb842a20.png)  
![picture 19](images/4891e412bea2f2da678497104c8d393a5d54bbaf75bdcfaea29c62c9d8c54836.png)  
![picture 20](images/00d4905ba03f1de26fa767f2713577722df39ccecf470f75e32bbd84bcf60674.png)  

## 八 . B站的netcode课
（BV1RY411B7pf）  
1 . 网络同步讨论  
![picture 22](images/c6b4602a15570373e1b864af975add9ab5a0cc81f8ab767a045eadfe18d6a226.png)  
![picture 23](images/505bc78d0fdcc6a28422e5b6f0720585599beac578f3beb87da3b9a0082e4840.png)  
创建副本：  
有四个同学在寝室中玩游戏，其中一个同学的电脑作为主要的服务器，其他三位同学将会连接到这个同学电脑上进行游戏的娱乐，游戏的过程中，承担主要角色的游戏的同学会把电脑上的信息传回到游戏公司的主服务器上，因为是要先到某个同学电脑上，所以可能会有作弊现象。  
![picture 24](images/d901a8bce9a9dc6f4945cc95bf7eb66036a53f29a4c415e45e55ee3ff9b03708.png)  
很多人请求一个服务器压力大。分布式减轻压力，分布在不同的地点，为就近的人提供服务。比如：我在成都，我朋友在纽约玩同一款游戏，就可以我访问杭州的服务器，我朋友访问纽约的服务器，纽约和杭州的服务器之间游戏公司去维护一个专线的连接。  

2 . P2项目准备-主角创建 
（1）window->general->lighting->environment  
环境光的天空盒去了。  
（2）键盘上下控制前后移动，键盘左右控制旋转  
![picture 25](images/3609f140f0ee845fa07f3a99b369101d37e3c6447f740483998863e217b99ea0.png)  
![picture 26](images/ad23eb43ab3c19f3493084ddaa120c0dd746c42ef50428e8e70a54a58fa24823.png)  

3 . 金币创建  
（1）Player勾选is trigger，Coin不用勾选  
![picture 27](images/da0ad71a41f6ce747a8d8ad2a8530d4a448111f68d28b7d0239a6c5303850bd6.png)  
（2）为了防止player穿过地板掉下去两种解决办法：  
【1】取消gravity 【2】Constraints锁定Position,勾选表示锁定  
![picture 28](images/57241e6327eeeacd1c33f8cd910a37be3c9ee45293a3021ae519daa18ea6f857.png)  
（3）在Player的脚本里  
![picture 30](images/9920a5b257d58eedadc26617982d28de150834f7552dd0ae03ea0b749d9e1343.png)  
(4)专门的empty gameobject上挂脚本  
![picture 31](images/4885debac17de4cf6eb3dbd49510486ba8fa9b745f0670149d1fc3240c6cdf36.png)  
instantiate是生成，金币从5f的高度掉到地板上。  
将四元数设置为Quaternion.identity实际会将其欧拉旋转设为（0,0,0）或无旋转。

4 . 按钮启动-server-client-host  
（1）networkManger中这两者的区别在于：  
两者【UnityTransport】【UnetTransport】:   
![picture 32](images/0c5a7508135f7c16acfff4b18cd64c84d8e24d52daf156ed5785d6f93147caf6.png)  
![picture 33](images/c4a0be591811589cf55a1bf3acc36fdcbf7e221049f3896c3740615b37035f36.png)  
UNet是以前的方案  
![picture 34](images/2cc08484f70cb0aa58299a4534d98489115a3c2811a4fea4a089ce5cff3bcf8e.png)  
因为我们是本地开发，联网是连接的本地的另外一个用户，没有跨越局域网，也没有连接到互联网上。  
（2）创建几个按钮  
四个按钮的含义。
比如我们在组织足球比赛，需要有一个主办方，主办方提供场地供运动员参加“Start server”。每一支参加的球队就是“client”，上场就是“start client”，HOST就既是主办方也是一支参赛球队（又有server的功能，又有client的功能）。   
![picture 35](images/7adb8d7d70ccfc163291b74c38d0be85c83c05f14ef76359be6b0bd2ee2f79ac.png)   
代码写在“GameManager”脚本里。  
![picture 36](images/50352b95a4d71f00191276e212d6a400e821a0f82c45a6f2f3378bb0587429d3.png)  
![picture 37](images/43e3e6c9272cf94b7da56ab7e1139cfaefc9c54fa7fa3d8551c6c2a9cbc561b6.png)  
![picture 38](images/26ecdc941f8dcd0368db3ef24a07d9b0346aad8a9b631402ba68eef23e8bc0b1.png)  
在“GameManager”脚本里加三个回调函数。  
![picture 39](images/14b561984811e10918995e138c26b781213f04210f5272d999d8d634383d7bc2.png)  
我们要监听是否有其他足球队上场，可以使用NetworkManager的各种回调方法。  
第一个函数会在另一只足球队上场时进行激活。每一个加入场上的足球队全局id是唯一的。  
第三个函数通知服务器已经准备好。  

5 . parrelSync  
![picture 40](images/290e2c945a4e48159273aa786fb8bc44854a36116cef4dd57c7b5bf987e8ea55.png)  
clone里面的Assets文件夹是链接/快捷方式，链接到我们原来的工程中的Assets。

6 . 主角transform同步  
（1）在player的gameObject身上挂NetworkObject组件  
![picture 41](images/6cfe294d7123e10bb4d0a5fc05c19428287e00303b03312b16b1dfa2c5732ccb.png)  
（2）把player的prefab拽到NetworkManager（游戏物体）的这里  
![picture 42](images/31d8d2cd4da93890e468cb19e8d373915a7ed71fd911b8e1dece9345f63a3c36.png)  
此时创建角色不由我们完成，由NetworkManager完成。  
所以把gameManager脚本的这里注释掉。  
![picture 43](images/9c507b0eb095d792e94caad9e2254710a95cb3a66c86d54718cccb8ac02dde6d.png)  
（3）为了让client和host的player主角不生成在同一个地方，Player脚本这里加上一句  
![picture 44](images/3c2e50d91a50945e5479a6c6f8874fbb9b30e9e7c24bd94f9290b58160ceca59.png)  
后运行发现，两边场景的位置不太一样。  
host产生两个随机位置:  
![picture 45](images/e801881c99231604f585ecf3406ed676b14aa6f65aed4ff1b3883af19aeaabc9.png)   
client产生两个随机位置:   
![picture 46](images/f92ec687cd83f8dfc710bceb29a0b413152a886ac404c21ffddb69ba6c90e49e.png)   
所以player一共四个随机位置。  
![picture 47](images/0ed7cd3a9df1337424af85b34a340f4eeb6a006cee493abc97e0c55fa9a0c9a8.png)  
Player继承自NetworkBehaviour。注意！Client和Host在isClient的判断下都是true。isOwner判断这个Player是不是自己这边产生的。  
（4）  
那么现在：  
【1】start Host， Host_Player生成  
【2】start Client， Host_Player 和 Client_Player生成且Host_Player的位置对。  
【3】返回看Host中，多出来的Client_Player的位置不对（和Client中不一致）。  
另一个问题：  
用前后左右控制的时候Host_Player 和 Client_Player都会同时同向移动。  
（5）为了解决这两个问题  
![picture 48](images/64d1e96cb64e8c409402b0e83d050e2175ca5d547b28d2179520d014ea1c66cd.png)  
![picture 49](images/8fecdf97c515493b97d85bece35f34661aca6062194a78fcb6b31d729bfcef4f.png)  
如果是本平台生成的则把那两个数据发送出去，如果不是本平台生成的则接收那两个数据。  
（6）但是这样会有报错，为了解决这个报错要   
![picture 51](images/40e93a0b55268140ee25ad86867885c1c3c73ebb78d40ad08a0d14dfd0089ad4.png)  

![picture 50](images/dd389914e0343018091fe55cde75a225c7ab8458ac06292c1d4f548f38f6257c.png)  

7 . 不同主角外表区分   
（1）用UI区分，先把UI的text的位置调对。  
![picture 52](images/e2cd6fa66e6184bcb6167e914aa053effe122dd68698193b4d0ae46d6079d255.png)  
![picture 53](images/4b6d9758b10ea9d50fa10625ae0855079dbd58314bfacbbc1e6936c9d5f308ab.png)  
![picture 54](images/ffec46ca21a9e6fe3bca0a1de5022164a789314daef4501149522b5650c7ee8c.png)  
（2）在Payer脚本里添加这些，使得数字显示对应ID。  
当MonoBehaviour组件创建的时候，首先执行awake，start等等这一系列的生命周期的回调函数。现在这个组件修改成NetworkBehaviour（网络组件），在网络组件被创建的时候，它其实还会去调用这个OnNetworkSpawn()。这个方法能获取关于网络的一系列的信息。    
![picture 56](images/61bff95b4ae4bd9dbf22e60d62188fc8a0374fce056d78c4a7d18abea0ba6fa8.png)  
也可以在Start()里获取OwnerClientId。  
【补充】   
这里用的是if(this.IsServer){}方式。  
其实还可以用之前那种比较麻烦的方式：  
【1】if(this.IsClient && this.IsOwner){}  
【2】`[ServerRpc]`  
e.g.改变player的pos和rot  

【补充++】  
【1】文档中说OwnerClientId：  
Gets the ClientId of the owner of this **NetworkObject**  
【2】https://docs-multiplayer.unity3d.com/netcode/current/basics/ownership/  
中说IsServer or !IsServer is the traditional client-server method of checking whether the current context **has authority**, and is only available in client-server topologies  
【3】https://blog.csdn.net/a924282761/article/details/134330692?spm=1001.2014.3001.5502
中说：  
Player脚本将在每个构建中为每个玩家执行。因此，如果连接了4个玩家，那么在主机构建中将有4个Player脚本，只有其中一个将IsOwner设置为true。在第二个玩家构建中，仍将有4个Player脚本，并且再次只有一个（不同的一个）将IsOwner设置为true。    
【4】【鸦鸦的理解，有极大概率错误】判断if(this.IsServer){}可能是因为，先有server然后server会：  
When a client starts a distributed authority session it spawns its player, locks the local player's permissions so that no other client can take ownership, and then spawns some NetworkObjects.   
生成不同的Client给权利，可以在这个时候看生成的client的id。  

（3）区别颜色   
通过修改这个东东  
![picture 57](images/64c820556deaad4332f24df3fcd6251d5915eb79134db7214f8b447184449498.png)  
![picture 58](images/bf48e971480e63ed0e16a1d4abb8b843b52ecf081945558d54e13a5494458361.png)  
  
![picture 59](images/65e2281315771320df175b257ead4b4d332636cb422903c954d47bea689925aa.png)  

8 . 金币位置同步  
（1）这里放网络里需要同步的其他东西，我没放啊，只是告诉你位置  
![picture 60](images/20753665df232ce44a81562c641c88ccd22183fd10ce08426eadd847ba7b789d.png)  
（2）为coin的prefab添加networkObject  
![picture 61](images/a9e0e56fe9c83c716e00ec60026d0698975fcbea54b6e14f7d08b2a9defb864a.png)  
（3）拽过来  
![picture 62](images/660939ba3119c29f8b99c89576189b42f48855afb03c9bdbbad2abe9f6cdccb6.png)  
（4）我们玩家加入游戏之后，会看见场景和场景上的物体已经加载出来。所以金币的创建应该由服务器实现。  
在gameManager脚本：  
![picture 63](images/42fdce88cb074d57c86474ed516cc4046193f3025056baae8685ab8d0dfeaeb1.png)  
可以观察到在host主场景里有金币，client场景里没有金币。  
把这里的代码修改一下：  
![picture 64](images/71de372d3641b4f9dd54dbb2a736790d2d7598759e6c49bd486e2d7890cea138.png)  
两边场景都有金币且金币位置统一。  
（5）为了使主角能够推着金币走，验证金币位置改变时两边场景是否同步，需要首先把player的Box Collider的is Trigger选项关了。  
此时测试发现client场景中金币的位置并没有发生改变。    
解决方法：对coin这种非主角的游戏物体，有一种更简易的方法。为了使不同场景之间位置同步，可以为其添加NetworkTransform的组件。我们的Netcode方案就会自动为**添加**上这个组件的物体进行位置同步。  
![picture 65](images/0d30940fc1b5ee3a81dc2e0dd842f9aa2d291dc4b64cba0234ad026ab3347a2c.png)  
勾选的则为要同步的信息  
（6）可以看到client场景发生穿模现象，host场景里没有发生穿模现象。  
出现穿模现象原因：对于物理的碰撞运算，我们的netcode方案物理碰撞是在server端进行运算的，客户端再去做数据同步，网络传输会有延迟。  
为了解决这样的问题，可以给coin**添加**：Network Rigidbody的组件。 

9 . 金币消失状态同步  
（1）把Player的is trigger重新勾选上。  
（2）  
![picture 66](images/7b246cfc76c5aad13f5e6d1062cee2f0c8de429a6e273387f7a84b18d7e1bc95.png)  
上面这个方法单机游戏可以，网络游戏就要考虑是谁碰到的这个金币呀。  
![picture 67](images/1d9aaf12329d0beadd79366f3ee3c8736063f6de02ae85369c54290cbcd7314c.png)  
(3)在Coin上挂Coin脚本。  
![picture 68](images/4f77f6abf7445e46b4a3ad6560a49420ab6d392308853d35ac164950e7e7d283.png)  

代码：如果是服务器端撞到金币，直接设置，如果是客户端撞到金币，通过RPC通知服务器。

客户端如何根据这个值的变化来调整我们的coin是否显示。在netcode里面为networkvariable提供了监听的方法OnValueChanged。  
![picture 69](images/59e4119ff491f82519ac6ea32fc95f211595f10285f7073b8f7583835f6d2342.png)  
`networkIsActive.OnValueChanged += //...`这句话是不是放`this.gameObject.SetActive(networkIsActive.Value);`前面后面都可以。

在Player脚本里修改：  
![picture 70](images/435405da88cec73db933e7ae59188f780c7e474545d753860f788f24088bfeb9.png)  
（4）这时候出现报错：  
![picture 71](images/7cfff3f6e38033c3693061a3526a2feae70ad806e9b24e99346377c191fbde7d.png)  
意思是只有金币的拥有者才能invoke serverRpc。由代码可以看出金币是由server端生成的，不是client端。所以client场景进行触碰金币操作会报错。  
为了解决这个问题在Coin脚本添加：  
![picture 72](images/704a9ed5f6556dd16c4592ce79356d74e440ec7ed6497759f08280317b327e50.png)  
这个 RequireOwnership = false 可以允许非server端向server发起rpc请求了。  
金币是由服务器创建，对每个场景来说都是平等的。  
弹幕：不好意思，来自NGO 1.7.1版本，这个地方的物体隐藏是自动同步的，不需要给Coin挂载脚本  

10 . ClientRPC点到点通知  
如果两个游戏玩家发生了相互作用，应该怎么办？  
怎么获取 谁碰了我 的这个 “谁”。  
这个信息传递是点对点，不用像金币一样广播给整个场景里面的所有玩家。  

Netcode提供了一种由服务器调用客户端方法的一种机制。  
例子：Player A 碰到 Player B的时候，Player A会向我们的服务器发送一个消息，所谓发送消息就是由PlayerA调用一个server RPC。通过server RPC来通知服务器“我现在已经撞到了一个角色对象”。服务器在受到这个消息以后再去调用一个客户端的client RPC用这样的方法来告诉指定的client端B：你被A给撞到了。  
![picture 73](images/5edb4438b059ec6bb9b4bffa5fafad571190d3bfc93090d7bd892d914a3f12fa.png)  
![picture 74](images/3ce4cd874cca565dfd9d9bb24af6be26f142f2ae7f2102c7b79ebe8ea62659db.png)  
这段代码的（!IsOwner）那里有点不太懂，鸦鸦猜测是不是NotifyPlayerMeetClientRpc执行者不是owner。  

过程鸦鸦猜测：UpdatePlayerMeetServerRpc先通知服务器，NotifyPlayerMeetClientRpc服务器通知client。

```C#
void UpdatePlayerMeetServerRpc(ulong from, ulong to)
//from填当前playerA的OwnerID，To填被撞的PlayerB的OwnerID。 
void NotifyPlayerMeetClientRpc(ulong from，clientRpcParams p)
//通知PlayerB
```

11 . 人物动画导入  
（1）下载unity的标准资源包  
![picture 75](images/0e5c8e19211c53bd2bca2249409f70bfb93f62c7b1419889dbd177cf8010ed8c.png)  
一个模型两个动画  
![picture 76](images/f85e8eeff4d655db412972d4e1abcff77bd44f70c7075844b5843cd1e4f2afa2.png)  
**模型的rig选择这个**  
![picture 77](images/d18104c3d7fe417477ceea736a768555b5e23e5b82956a1d0d877f781cf43fdc.png)  
（2）  
【1】给模型Ethan建立prefab  
【2】创建Animator文件夹，文件夹之下创建AnimatorController改名Player  
![picture 78](images/634321921fd9678aa200f40c1d23172dd5dc2ac476f3ed75a12ed765d606e666.png)  
【3】编辑该AnimatorController  
![picture 79](images/60e7936a37a7cbd2f6890e95d945b35f1f926ebd71ad46a14663ebee7d15ba78.png)  
把iddle和walk拽上去，再右键添加trasition.  
【4】添加变量，以及变量为true或false对应哪个transition。  
![picture 80](images/165c7212fa3ef82a9eb1a14ce4e83d1a8f4f47344c6d69ff7720b6e8a69403e5.png)  
![picture 81](images/255f617ea2f01d3445925e1158b32b6b0efd708814f60340c4b962d626646fe8.png)  
【5】把这个animator拖拽过来。  
![picture 82](images/80852440d1ed79e9c356681ace4eb579d64db077602e205bffe12a22f2485b43.png)  

(3)把player有的组件脚本给Ethan哥给挂上去。还有UI显示id也整上。rigidbody的constraint限制一下让它不往下掉。is trigger勾上。  
得给Ethan哥多添加一个这个renderer组件。     
clone的editor里NetworkManager这里也要检查是不是也修改了：  
![picture 0](images/32cb060c000c909ebe110e7aa3824e6ee1f5de1e972915ed9295bbe9f5d5bef9.png)  
（吐槽：突然发现应该先把原始的editor保存了，再打开clone的（汗）上面那一步就不用检查了（汗））  

![picture 83](images/eedfa91df2c34a015c151558fd3a9903fb74fb564cf0f5d11c0635024c637c2a.png)  
还有这个apply root motion要取消勾选   
![picture 85](images/5b51fbe465f1c27502cf8654986faa66a074d35a088f958e69f64d9393421fc2.png)  

(4) 修改player脚本。  
逻辑：当负责移动的键盘获取到的值非0则表示人物在移动，这时更新动画。  
![picture 87](images/c918bb0d268f9cc05bf75b713c5c75c8bdaea021668e070152060d2d5a90b1d1.png)  
![picture 88](images/77e5ecc4f1660d9bfac2664068d5d446eaf8d57b13148ebdf72bebfba78f4a1c.png)  
![picture 89](images/2dc4971085163b5c66a73877590e5af95163c11b8fec3ddfa011b84408d31e84.png)  

（5）这时发现人物会漂浮，是因为instantiate生成时的y轴是0.5f。  

（6）这两个transition的has exit time都要取消勾选。  
![picture 90](images/fd20a1bf229fc047bbb8e87a161bf1c973bd0f09e752f6c752137d45160ecef6.png)  
（7）运行发现两个场景动画不同步。

12 . NetworkVariable同步动画  
Player脚本  
当用户需要状态改变的时候，通知服务器，服务器通知其他客户端。  
![picture 91](images/e110240db0280c1f440e6912f57b7f77fa34d5bcfc6d367d03a63b4e7f9f8bbc.png)  
![picture 92](images/3e4095e32301f98d6f25494883740bb60c18e81654e28a16774712e52a59568b.png)  
![picture 93](images/fdbfa8922cbd5ed59ef59a25f29747ed639a54aba7f15e8226de862c54cae1c9.png)  

13 . NetworkAnimator同步动画   
NetworkVariable那样做很繁琐，netcode方案为我们提供NetworkAnimator。  
（1）添加NetworkAnimator  
![picture 94](images/89c70fe0fb10db0e1db6cb0e5a7228e2520a76d9acfb3b587bf6362883d4635f.png)  
(2)animator参数这里删了isWalk（bool），添加一个新的参数Walk（trigger）。  
![picture 95](images/e6352bddc4316bea6202fbe7b42f51285b7ebbe915cd681c49d04f6ebaf76940.png) 
![picture 96](images/8b828422cefc5bd5166a46bbcd065ddd474199e4d417df310ccde657ea176d5f.png)  
![picture 97](images/b6d647037894b7564f9f4182216417b3676dbb134bd621804ab1eeda87b1474a.png)  
（3）Player脚本   
![picture 98](images/5c8565c8e22c9d17e082f9c85d894d0369b353f8210bfc9f725e7b9e599cc94e.png)  
![picture 99](images/80436b609d012b43084a0b092aa3a7ee7535cf6752f4840bce1d294ccf285530.png)  
![picture 100](images/1714027e11a13fc445d3fa9edf184ad54bdb74cb31e46940155193e5232be1ba.png)  

14 . 使用ClientNetworkTransform同步主角位置  
我们只需要考虑玩家自己角色的控制，而不需要考虑其他玩家角色的控制。  
新建脚本clientNetworkTransform挂在Ethan上。  
![picture 101](images/76641f25f2dbadcfa7c751c0808047ce9644fbd9a7b20812bca62cae05f8633d.png)  
再注销掉用到这两个参数的地方：  
![picture 102](images/5f5b555cd8b66f8bcd0bed0bc76ea9babac7daf60d8be6dfbab4af2dca2e1529.png)  

## 九 . 另一个Netcode课
BV1g8411o713  
标题《Unity利用NetCode实现网络游戏（七）——概念和框架初步讲解》   
1 . 
![picture 103](images/b2ef3cf0fd1ba6a418388717bb48a43a401f8a65b71fd23540f91b57c4cdcdbc.png)  
![picture 104](images/019073edb505fd5ae8a64fff83827f87540ee4c3f0353b1b561f3a3c80dcc7e0.png)  
所有存在于网络的物体都要有NetworkObject。  
2 . 数据传输里有远程调用，远程调用分ServerRpc和ClientRpc。  
![picture 105](images/36e1c64d28732626782f49c93ab9c28a8ccec371d01e72f17f3968f1109d7cb8.png)  
ServerRpc: 客户端调用，服务器执行。  
![picture 106](images/a23dd7f527cd3ac27b33bf377c48be1a9a02810008303b3be6e117438eb77c30.png)  
ClientRpc: 服务器调用，客户端执行。ClientRpc发给每一个客户端。如果是Host主机的话还会发给自己。  
![picture 107](images/aeac9592a1f436d7785bc40415232c07c9deb0a7ae27a37526429b713c282cc9.png)  
![picture 108](images/797c8c8ce2d9aabc83495fb444f47bf9e97e17bf60cdd118e2bc50f30a074628.png)  
传参只能传值类型，不支持引用类型。  
3 .序列化  
序列化我们平时也会用到，e.g.（1）比如我们把变量公开在Inspector面板中的时候也是一种序列化。（2）有时候我们会读取json配置文件，json也是一种序列化。  
序列化在NGO(networkgameobject)中就是为了传输数据，它针对C#和Unity的基本类型已经准备了内置的序列化，让我们不用再手动序列化。针对C#，这里的基本的类型它都已经序列化过了，针对Unity的类型也都基本序列化过了。
![picture 109](images/0f4a3ca040a97c9d76b07b4f939621a2f35b7f65013f919f99681ce0af58a21f.png)  
4 . 结构体  
![picture 110](images/0916daedf4cb49105b7e48ddd3b33a9754c1e50cf6f22e67df05ddab142c7036.png)  
