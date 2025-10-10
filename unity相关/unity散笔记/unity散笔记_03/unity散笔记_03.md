### Unity散笔记03
#### 1 . Serialized Field Vs Public properties
title:Serialized Field Vs Public properties | Unity Game Dev Tutorial（YTvideo）    

(1)Serialized fields purely expose a property in the inspector where a public property that property not only through the inspector but to all the classes, this kind of violates the encapsulation model of object orientated programming.  
(2)
```C#
//如果是用public的话
//游戏物体Player上挂脚本Player.cs。
public class PlayerScript : MonoBehaviour{
	public string playesName;
}
//游戏物体PlayersHat上挂脚本PlayersHatcs。
public class PlayerScript : MonoBehaviour{
	PlayerScript playerScript;

	void Start(){
	playerScript = GetComponent<PlayerScript>();
	playerScript.playersName//其他脚本可以访问playersName。
 }
}
```
(3)官方“字段（Field）”文档说not recommended  
https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/fields
```C#
    // public field (Generally not recommended).
    public string? Day;
```
(4)auto property  
if you do want to use a public stream, this is a lot more acceptable.  
```C#
public class PlayerScript : MonoBehaviour{
	public string playesName{get; set;}
}
```

#### 2 . 气泡功能
（1）在Canvas下新建空物体作为根节点：  
![picture 0](images/e5f8de64bcaa8507f68e54367afffbf5d38e4e62c9e0be4e977de930dcd89de3.png)  

（2）在根节点下添加vertical layout group。
![picture 1](images/ca73cfea7e66fc50c9dad9592ead4e71fdd153a176b8e427bf91676bee045afd.png)  
这样点选：  
![picture 2](images/0444ffc1f0c5cd45a0473db6b82876ef349940674374c61706740dcd355bdcee.png)  

(3) root下新建image作为背景添加vertical layout group控件。  
![picture 3](images/3760b1f72926abde543d3d12ea04484e951e18a4af54780ea3b6acd869be09a2.png)  

（4）给root添加content size fitter组件  
![picture 4](images/ad8bcab8003e00d87c227b56ddf41d413041940e775ed22f386c02542ee64f80.png)  

（5）在Image底下新建Text  
![picture 5](images/38ea6f780ec62f7e020074489f1d97a21e6864fea25ac7fb92d0652ba9d162f0.png)  
（6）通过Root调节Image的大小，
通过Image的下图的组件调整文字到背景边框的距离。  
![picture 6](images/6ee6ce1a343f2ce7bad9d8f2709444810246e80b12dbcdaa9db9773b69a4240d.png)  
