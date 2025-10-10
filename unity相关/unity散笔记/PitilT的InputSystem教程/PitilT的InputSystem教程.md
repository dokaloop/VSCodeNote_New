### Unity Tutorial: Everything about the New Input System (Unity 2021 LTS)
https://www.youtube.com/watch?v=-0Cl54_3lmM

#### 1 . 先看Events
Events的跟做在
TestKouTu项目的：Test2-learnEvent场景  
##### 1.1
The Unity New Input System is relying quite heavily on events so I think it is worth to have a look also at the:    • How to use Events and Unity Events in Unity( https://www.youtube.com/watch?v=AGGmnVIhHvc )  . It is not (heavily) required but definitely will make your life easier. Other than that - I do my best to cover everything in this video.   

Instead of executing code in a loop every certain time (e.g. Monobehaviour的Update()方法), we execute it only when certain event happens.  
![picture 0](images/481084d2b52fd854f4a3c3ddba21c27249e849ee675d4c415c85ecee3b754f3f.png)  

新建脚本CollisionEvents.cs 和 PlayerInputProvider.cs：  
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;


public class CollisionEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTriggerEnter;

    private void OnTriggerEnter2D(Collider2D other) {
        print("fuck" + other.gameObject.name);
        // we check if the collider2D is actually the player.  
        // we don't want to react to any other collision.  
        // to check that we can try to grab a player specific script like player input provider
        //if we found it, we call the invoke method of the ontriggerEnter Unity event.
        //if the ontriggerEnter is null, we don't want to gwt the null pointer exception, so we add a question mark

        var player = other.GetComponent<PlayerInputProvider>();
        if (player != null) {
            _onTriggerEnter?.Invoke();
        }
    }
}
```
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputProvider : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);
    }
}
```
脚本挂法：  
CollisionEvents挂在sword上  
PlayerInputProvider挂在Player上  
逻辑是：当主角运动碰到sword，sword消失，出现敌人。  

Let me explain how it will work.  
Event variables are like bags full of actions, you can easily add and remove items from them. 
![picture 1](images/0db250714c54f248ded20cfde27f34af1859ed0eb5bc7cd0f58bda64c14108ef.png)  
And once the invoke method is called on the back, all actions one after the other are executed.   
![picture 2](images/09133e2190960486641bd84341261c8eb15d049934b95d7292bbe2ce81c9ef68.png)  

Normally we add and remove the actions programmatically,   
![picture 3](images/1fde7baacb7037afa38653705d176ee61455e5e67e3f3cf30e0ea8b13cab7f24.png)  

 but unity events are special, they allow us to add and remove actions directly from the inspector, we can drag and drop the listener and then conveniently select the action. We can not only manipulate the properties of different components, but also execute public methods that are part of the scripts on the object.  

 ![picture 4](images/30b430ab8e30b981b08b69105d7ab65bc525c573b5ff8eca25950883fda718bd.png)  

##### 1.2
Now let's have a look at the regular C sharp events, but before we do that, let me tell you two words about the naming convention.  
In the previous example, it sucked. I used the 'on' event name which is not really the proper way. The name of the event as the name suggests should be the event like:  
![picture 5](images/55277c099b26f13fd37cc54c28a706eed03de0a64f2d89dff5804325ef9f51aa.png)  

The method that invokes that event should start with 'on' like:   
![picture 6](images/47921203a0cef8ac55d52db844ad3a01da47ce4edfdecb3f1fa01abb00ebb1d8.png)  
![picture 7](images/892c18a8fa19e83da45889e4dfca895dc226c50dd34e749d8218b59b6806a94b.png)  
However sometimes those methods are skipped and the event is invoked directly in another method. 如下：  
![picture 8](images/2cacdad8e7fa0d5c9d8fe728669a7aad3f5c09501fdc1e09ab288ba4e50e268d.png)  

##### 1.3 按照1.2重新写  
![picture 9](images/0a88033ac221a5b8c10761592192e925ad500cc41b963ae47357d752322c2379.png)  
- 注意上图的文件夹名叫Enums
- namespace的名字也叫Enums  

第一版代码：  
```C#
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public event Action PickedUp; //Event with no params
    //event -- keyword
    //Action -- type
    // Action that describes the parameters that will passed to an action and the action's return type.
    //now the type called action is the simplest of all, it doesn't provide any parameters and has a void return type.  
    //we invoke it exactly the same way as the unity events.  

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerInputProvider>();
        if (player)
        {
            PickedUp?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
```

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;

        var items = FindObjectsOfType<Item>();
        // a small side node: this way of grabbing all items in the level is not really ideal
        //using the service locator pattern to do it is better.  
        foreach (var item in items) {
            item.PickedUp += ResetGravityScale;
        }
    }

    private void ResetGravityScale() {
        _rigidbody.gravityScale = 3;
    }
}
```
Enums.cs的代码：  
```C#
namespace Enums {
    public enum ItemType {
        Sword,
        Axe,
        Mace,
        Coin,
        Gem
    }
}
//How we can invoke an event with some parameters
//I created small enums to help categorize items
```

第二版代码：  
```C#
using Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public event Action<ItemType> PickedUp;
    //Let's use it as a type for new serialized verval in the item script
    //because sometimes we may have different actions for different items
    [SerializeField] private ItemType itemType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerInputProvider>();
        if (player)
        {
            PickedUp?.Invoke(itemType);
            gameObject.SetActive(false);
        }
    }
}
```

第三个版本代码，这种情况下用EventHandler比用Action更好。  
```C#
using Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Behaviour.Utils;

public class Item : MonoBehaviour
{
    public event EventHandler<PickupEventArgs> PickedUp;
    //Let's use it as a type for new serialized verval in the item script
    //because sometimes we may have different actions for different items
    [SerializeField] private ItemType _itemType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerInputProvider>();
        if (player)
        {
            PickedUp?.Invoke(this, new PickupEventArgs { ItemType = _itemType });
            gameObject.SetActive(false);
        }
    }
}

```

```C#
using Behaviour.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;

        var items = FindObjectsOfType<Item>();
        // a small side node: this way of grabbing all items in the level is not really ideal
        //using the service locator pattern to do it is better.  
        foreach (var item in items) {
            item.PickedUp += ResetGravityScale;
        }
    }

    private void ResetGravityScale(object sender, PickupEventArgs args) {
        if (args.ItemType == Enums.ItemType.Sword) {
            _rigidbody.gravityScale = 3;
        }
    }
}

```
PickupEventArgs.cs的代码：  
```C#
using Enums;

namespace Behaviour.Utils {
    public class PickupEventArgs {
        public ItemType ItemType;
    }
}

// It works even without it
```

脚本挂法：  
Item.cs挂在sword上   
Item.cs挂在axe上  
PlayerInputProvider.cs挂在Player上   
Skeleton.cs挂在Enemy上  

逻辑：  
玩家碰到axe敌人不会掉下来，玩家碰到sword敌人会掉下来。  
![picture 10](images/9d90bb49aeeaab4566f52dd9999b5dd13402732440056ef5ab15079071a6aa5c.png)  

注意：  
axe的这里要选择Axe  
![picture 11](images/26b73d6dfe4dcad9a0472ba91247bef8caf28059b9309958ef86e3604f659572.png)  

【注意！】**看到时间轴的06:28就没往后看了。**  

#### 2 . 正式开始学Input System  
##### 2.1 装Package
先装Package：  
![picture 12](images/dd116f97e4d53c0fcc7f3482d5d03dc0d30110b53701dd0dffcc36efedda7cd6.png)  
![picture 13](images/1e4a1985f1e2aa4991b391951d6d1337656db291109c540d93451fc152f1bdbd.png)  
这样会导致老的inputSystem用不了，只能用新的。  
如果你想换回老的inputSystem:  
可以在Edit中点击Project Settings：  
![picture 14](images/21efda6bf77e6e2ad73aa745c5c7dd27cd4edaf327d78cd5447cdecefd8df311.png)  
![picture 15](images/d36fd70833f793854500dae926ca4e78b3cb886b9107511c3850005208ba0c1d.png)  

##### 2.2 编辑InputActions内部
(1) 在Assets文件夹中右键：  
Create --> Input Actions  
重命名：GameInputActions  
![picture 16](images/845105642d23f2c357093c6969c64ae5dcae22a5b304a3e07edd7f468606ae25.png)  
This file is basically what will store all the information about our mapping. So everything related to input will be there.   
The information like what keys we use for walking, or what keys do we use jumping and so on.  
In general just type of stuff that we always find in the input manager.  

(2) 双击：GameInputActions 打开  

（3）点击这里，新创建一个action map  
![picture 17](images/dca9a6cd7a9998f5168652e366d44e28e6dae2e961ff3d1edaf3a0622563907a.png)  

再创建一个：  
![picture 18](images/879528cf15f67729126d53d173d5b23a5154d762a3ab61d6c2052118a500871a.png)  

写入action:  
![picture 19](images/7c3550513635fcf83aaa5c0079e93953eb8d3384c5b4dd2b804e0b4732a6f9ff.png)  
![picture 20](images/0de6923dacf37cad500384f213b242e5ca96bdb6b1ed1908b91998a8b20711ef.png)  

选中PlayerFlyingAirplane，再按键盘中的delete键可以把这个action map删除掉。  

The interesting part about new input system is that you can assign multiple bindings to one action.  

比如选中Player的Jump Action：  
的binding：  
点击Listen按钮，  
再点击键盘中的space按键。  
![picture 21](images/0ad78bdf5713c2b6494d399aebd9c20ae741e14932e6a570f1941b2607211f59.png)  

可以添加多个binding：  
![picture 22](images/efadfed44bddbb359d43ff8caf1dd02e4935508c2ac9c7dd7325cb7be797bdf3.png)  

（4）Action Type有三种：  
![picture 23](images/687d7481cf51cbe4fe6115400be65d3b4e82548be809d9a0d09a60820224b53c.png)  
Value和pass through are used rather for continuous input, so things like movement.  

(5)Control type  
![picture 24](images/a2abe9c52f753fdd02ceda42137dda490edf04073913a8093d9f31d109d6f5dd.png)  
The control type is basically a return type that will be given to us when we try to access this particular action in code.  
But a button is a great example, because on one hand, we would expect boolean values.  
![picture 25](images/fc3fa2aef18bc45c82ea05ad334a5c876bc61e7e68ffad8ad6001c10d90ac7ce.png)  
![picture 26](images/a4dfbfb5808731d3f4db5a599b7846cc171025e9fc7577ac90f9712625b10c27.png)  
This will create like one dimensional axis. Like horizontal axis or a vertical axis that we know from the old input manager.  
![picture 27](images/d08fe4956159ae6f31bce19641d0c0b93488e80ddc9703bfc35e1e5ad7b4bb39.png)  
What would happen then basically when we click on the binding itself not on the actual keys, we can see different valus.  
![picture 28](images/9e4f489945477d9fce04c23a544749c37eb321ef690e7950edab92da0d3e0739.png)  
按A会得到-1。  
按D会得到1 。

（6）  
![picture 29](images/cd2d499e344d87dcc24584e6bdb05bee9e84175d8e780b9f0bcd9f65f03344fc.png)  

双击2d vector 重命名为WASD  
![picture 30](images/a15f2424fdcca3dca62d7409494644059597e9ddd46d222b36189bdc684ec470.png)  
![picture 31](images/49c285c595d1a67b7c90d671520fbbee64b3fa355e76d7f952dd14a71013c474.png)  
加上arrows的binding：  
![picture 32](images/0cce51e46fdd8b5dbd7a57ee5313a34366a3885a3a222410abdce36352c21b29.png)  

This allow us to discuss the differences between the value and pass-through types. Basically for the value action type, whichever input is stronger, this one will be taken into consideration. So e.g. if you have a gamepad and you have two sticks, and you will move one a little bit to the left and then the other one completely to the right. The character will start obviously moving to the left a little bit because you used the left moved the first stick. But as soon as you move the other one to the right to the very end, the character will start moving right.  

When the action type is pass through, the behaviour is different.  What happens then, the most recent input is taken into consideration. For a gamepad this might be a little bit problematic, bacause gamepads are analog, the values constantly change, so there is like a flickering of values. If you moved left stick and the other right stick, you know you will just have a one huge mess of values.  
For example for the keys on the keyboard this would be perfectle fine, because basically the one that was pretty suppressed later would be the one taken into consideration.  

![picture 33](images/102279e1023e7df7cedc08762e0325650dc1a9b0223931301ebb75d103f22e43.png)  

##### 2.3
(1)  
![picture 34](images/89140f3099739bf50afa0aad8c5cb45a3bdf75e564887291bc937b9472b8314d.png)  

【注意！】**看到时间轴的14：47就没往后看了。因为有up以前项目的代码**    
可能需要看：    
![picture 35](images/e2c2856050d34830a2ee4ee8916cd1adda1f587cfa1370f15633d0dda40b4afd.png)  
国王君一系列关于跳跃的视频。   

![picture 36](images/bb024322764b07979bd73a2801f73ba4d2e7d816db6ef98dcc24d82732ba2ddc.png)  
射击相关的一系列视频。  