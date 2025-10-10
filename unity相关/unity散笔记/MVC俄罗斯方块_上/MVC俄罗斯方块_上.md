### MVC俄罗斯方块(上)
#### 1 . 什么是MVC架构
对于游戏来说它是没有一个统一的架构去开发这个游戏的。

MVC这三层：  
Model（模型）：用来存取数据 e.g.分数，地图的数据（这些数据一般会发生变化）e.g.人物的等级血量游戏物品  
View（视图）：玩家可以看到的部分，交互的界面  
Controller（控制器）：控制游戏逻辑  

分层的好处：将来如果2D改成3D外观

pureMvc现成的框架，学习起来比较困难

#### 2 . 创建工程，导入素材
（0）选用7：10的比例  
![picture 5](images/cd46915d620abc14a0149ac1b3d0dd8cab2e8da2a6da97358f2804df3e7346e2.png)  
（1）  
这个是配色方案：  
![picture 0](images/d45cc98135344173e999bbc36552a0045946ab85373d0a502dff6c288c4caa43.png)  
(2)选中sprite，点击sprite editor  
![picture 1](images/5541620e0d8c5c0b99ed2b288692fe5c0b34d6533eafa20a2eb5f22037680218.png)   
为每一项更改名字：  
![picture 2](images/385bdbad6c818be9311eb9cd09d3409a79b746b2b07583e26c85621525c543ed.png)  
![picture 6](images/199e79ff4fdb445440109c88f001a40138d55f92b02524fbc71cbd6f13d4e5c5.png)  

![picture 3](images/9a90be86b7dd33e115e26474585399e82721272c1f186d7ee09f6be5f41bb598.png)  
所以这个是62像素是不到1米。   
![picture 4](images/58102ff7bc55065de8b86b1d25ec2fb7ee168b85b290774790af83ccb2a2468c.png)  

#### 4 . 创建MVC的架构脚本、分好层
Ctrl层是一个桥梁，连接着Model层和View层。  
Model层跟View层是不交互的  
（1）创建3个empty gameObject，分别叫：  
Model  
View  
Ctrl  
(2)在Scripts的文件夹下新建三个文件夹：  
![picture 7](images/c6f33033a08535b75c1925f0fb701470f8d384ad6a6b25611603be3dd128978d.png)  
![picture 8](images/5276de9546e5f7be5ea59a40372acfb740962f92898f801e210c117be56789b9.png)  
再把这些脚本挂到对应的游戏物体上  
（3）为游戏物体添加标签，标签加到对应游戏物体上：  
![picture 9](images/df1d416647cf35190e0d9aa8ededc1d7337cdb6e7221c2866eb07a716635ff36.png)  
（4）再Ctrl脚本写入代码：  
```C#
public class Ctrl : MonoBehaviour
{
    [HideInInspector]
    public Model model;
    [HideInInspector]
    public View view;

    public void Awake()
    {
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();//FindGameObject后面没有s
        view = GameObject.FindGameObjectWithTag("View").GetComponent <View>();
    }
}
```

#### 5 . 创建菜单界面UI中的按钮
（1）中文字体TMP（BV1uM41177zn）  
【1】对着中文字体右键creat -> TMP -> Font Asset  
![picture 0](images/47a7e9aec08e091ddda29c433343aeeab2a89c504272e36051ac9b030d849706.png)  
【2】复制一个属性设置为dynamic  
把第一个字体设置为static  
然后把复制的那个拽进这里  
![picture 1](images/190c04c060aa2f658d692633d49d1d9e664b16d7dc551af0cf83e3e76c2e3473.png)  
里面推荐看的视频：  
BV1Kr4y1T7XB

（2）按住alt可以等比例缩放  
![picture 2](images/7d135201528238e2a8cc1e7c97289c678d37d9499a553d02bca523bece97932f.png)  
（3）把colorStyle拖到UI底下然后用吸色工具吸色。  
![picture 3](images/c81f2373f0e32885762538d66d65912acfd07eb39c1f51b36577e3fdb7da0723.png)  
上面这一串是界面颜色  
下面这一串是方块的颜色   

（3）把Main Camera的背景设置为白色

（4）在Canvas底下新建子物体：emptyGameObject并改名为MenuUI。  
对齐下方并拉伸：  
![picture 4](images/779faac5838562cac62254f830de82d0eb925fc869efc038815645c0a4227ad6.png)  

（5）在sprite editor里将绿线拉到这里可以，是为了有关拉伸的操作。   
![picture 5](images/576a79447d450cac944f99ecf0328867e9deb66793c6701cee380522f2151b79.png)  

（6）在BUTTON(尺寸100x100)下新建Image，  
Image Type选择simple。  
并且居中拉伸，然后上下左右间隔都弄20。   
![picture 6](images/ce9911979a33be291a5214bc507536999645de390758c771194ecb069d196dea.png)  
![picture 7](images/76447c960d8738e817b9846de1cb82b882dee409821033f8a3e11ebf530f4a88.png)  
再把这个Button做成Prefab复制3个：  
![picture 8](images/764cf5599e9b3b137ea4929ae184c2bd21aea6c54445cc90fb5330d1590290c6.png)  
![picture 9](images/90a8558260f820dcf2e444b27573ddac0f2496a6b419ec5c18b8de75ba2307d6.png)  
改名，RankButton的图片的sacale的y设置成-1可图片上下翻转。
把Prefab里Button的子物体Image的raycast Target取消勾选  
![picture 10](images/10815ce472268b3a724d2dae1791f9ec47e8fdf32e31d899b608430f8185a046.png)  

#### 6 . 设计菜单的UI的布局和颜色
（1）通过取色更改一下颜色    
![picture 11](images/08b9ec7af42cab45e8e77a64007b882d2702b516ee111e06928211f90ee67cea.png)  
（2）自动布局  
【1】在MenuUI下添加Horizontal Layout Group组件  
![picture 12](images/1e0ff95887852d07f49fbc5a86abd5caf2fe87237cc11a54529524f4d638c645.png)  
![picture 13](images/cf3c8cc1c569a6ccca6a98d3416c66574edaeb9e93279edd6620c22e4988eac1.png)  

#### 7 . 设计游戏中的UI界面  
（1）在Canvas创建空游戏物体，改名GameUI，然后按住alt选择这个，居上左右拉伸。  
![picture 14](images/64959b2be3c11e782791aa3c904eca3ae66f0cd70dab66d4bd7bac8b9f6aa7d8.png)  
（2）把pause button的大小和里面图标的间距调小。  
![picture 15](images/12756a7cca2c739bd978c2f1a5acab73466524ec4990d744dfc36777cd05ba83.png)  
![picture 16](images/4b14d90db649c9dd3f32d6e3e8ba3def1190e1bedcc0c97e6543e87d2c02d3ee.png)  

把pause button的anchor放在右上角。  
![picture 17](images/d8e4a290b228f110254a55df28bb142b1b01765c65c5b9d8a9aadd1ea148144f.png)  
![picture 18](images/41c1ba2eb6517e2c6b6b0a5ebc181170bab641f72b838da6bc9bac07c673af61.png)  

(3)“分数”二字是父物体ScoreLabel，“100020”是子物体score。两者的raycast target可以取消。    
![picture 19](images/6b23828170a26ef612fdc59df95b55c55debeed00f6ebf6ca3bdb8dffbb01bfb.png)  
100020的字体是eurof。   

（4）修改一下颜色和文本  
![picture 20](images/5afdb6fd4eb779e7de5e40afaa57a6bd467faa79e6abe8f10db75b808f512f8e.png)  

(5) 把Canvas移动到View地下：  
![picture 21](images/4ef75b6116e2d6457057d5dac08d5a7cc78042f078f773c8ee627dba4654f5f2.png)  

#### 8 . 开发设置的UI界面
（1）在canvas下添加image改名SettingUI，并按住alt键拉伸到全屏幕：  
![picture 22](images/dfa2207c268f7989cf7f1b9b56ae4deeddfbd64b4e1f15e1658ae707524a6793.png)  

把这个image透明度调低：  
![picture 23](images/0f32515daeb22a5af20cb458c37dff70c89bf1138afe65c5203d84a38022c7a5.png)  

（2）添加这些，并把Background的raycast target给取消勾选。  
![picture 24](images/da6190ca94629f36a04a1d1a6b0eacbb7fa4df20380eade44c430303bed65851.png)  
![picture 25](images/d7addd820140f93b0b45c740861eb1245d03a87fb1cd7d56e0e5cc40d8b8ef2d.png)  

（3）为audio button添加斜杠图像，并改名mute。  
![picture 26](images/ec1ff2a82be1501c68d2c3173d2be3e4ec67910b52db9d61888fea58bbd1d1fc.png)  

#### 9 . 开发分数和游戏记录显示的UI界面
（1）复制SettingUI改名RankUI并修改里面的内容：  
![picture 27](images/8ccf5dbecefb3b6dcad4cd90bfce610d6caebe4cd0d74c528a888e1e6cf9fb68.png)  
![picture 28](images/82321b1a251834ab78a1d151519036291d21967afcd23439c71cb670f9bb90bc.png)  

#### 10 . 设计游戏结束的时候GameOver界面。  
（1）复制RankUI改名GameOverUI并修改里面的内容：  
![picture 29](images/7e11b11098a4e4ea0e3a96ef64bcbb9dcfe4a0c1fd51899df6ba3a303aa8a8f5.png)  
![picture 30](images/1da05da424bc8a728c05d7f54abbb1835a84bf3243ecba554f5bd908b3d8877f.png)  

#### 11 . 设计俄罗斯方块的背景地图
（1）  
把Tetris Assets里的sprites的block拖到Hierarchy并把它设置成prefab。

这个block长宽大概是0.9米。  
地图坐标Position是从0,0开始。这样它的Position坐标就可以正好转换为二维坐标系的索引。二维数组的索引。  

ctrl+d复制以后，按住ctrl移动，可以1米1米的移动。   
（2）10个Block为1row。做20个row放到map空物体中。  
![picture 31](images/557044ab52424d31c1672b8bc8737788b05c87d1479c13b13dbfe25205524f1c.png)  
![picture 32](images/3bfe0480f8f2c90cd6fc150190f91e9a92d415c5a024eddd0bbf8b935363fb58.png)  

（3）调一下main camera的位置和size
![picture 33](images/fe10b056352c6c67b821667db5e4374799e50b68299896384341bdbe14ce1af7.png)  
并把canvas，main camera, map都拽到view底下。  

#### 12 . 设计下落的基本图形
（1）在prefabs文件夹下面新建Shapes文件夹  

（2）把block的prefab拖到画面中，新建空物体作为它的子物体改名为Shape-1，把Shape-1的位置reset，再让Shape-1作为block的父物体，这样可以让两者位置一致。  

（3）再做出其他的Block
![picture 34](images/5f67a99ed64aa5396e26b1d812fa9499592ac0d46d21eeccafbd9f605cbf097b.png)  
![picture 35](images/a6a6347ac4dddf9b32b02423ad51e58219b68c8b08f364bb497298001a9cb955.png)  
把block的prefab设置标签为“Block”  
![picture 36](images/7ec84bb0b8d266e5761291dc3e53f30ebe84ffc19bf1683ad519639626673d1c.png)  

（4）添加旋转中心  
![picture 37](images/e42bcc48649d8e9dbb562a9a011137746b79bb76f1df0a5e2c96ccd6b51467fa.png)   
设置旋转中心时保证旋转后还在地图的方格上，不能有偏移了。

（5）把Shape-1拽到prefabs的文件夹下的Shape文件夹下：  
![picture 38](images/fc79dd0edf26c23da762f115d4e0dd8fa4b2e6584b0fbae501fad48f32b0a71e.png)  

（6）Shape-2 是I形。  
![picture 39](images/90f18be53d963693652193ffdac374d8928de519eb73b2d2f84794d0c19296d0.png)  
![picture 40](images/b30d3c67f82e070be6d257e599d364eddc4369af0564a515b11aaf07446cf20c.png)  
直接把shape-2从hierarchy拖到prefabs里。  

Shape-3  
![picture 41](images/117942647183783bbdcfdf9f28a2de39f37ab34ed927c04c469bbdb6d39ac09e.png)  
绿红箭头在的地方是旋转中心

Shape-4  
![picture 42](images/c97f8c3452bb70cc495c6da5c131d2ac797550c3eecc7c4b803222c8edda013c.png)  
绿红箭头在的地方是旋转中心

Shape-5  
![picture 43](images/358826d001eee6749cd65267e8354a4708b87272bd0f911a5f444c0cbf8fd355.png)  
绿红箭头在的地方是旋转中心  

Shape-6  
![picture 44](images/25725f707c2135e81d8187c8e44e4b7a6af1d10494737c4adf7585791d586460.png)  
绿红箭头在的地方是旋转中心 

Shape-7  
![picture 45](images/4e440a3d9832015b170498d579eac72432bbae4491d2e2f60764c4232197701f.png)  
绿红箭头在的地方是旋转中心   

![picture 46](images/8a4b9d65ef8ef6885261759c551d0505ac01cc04b7670d143eb8fcb0a86d5795.png)  

#### 13 . 导入游戏有限状态机FSM和分析游戏状态

（1）  
有限状态机在siki学院的这几节课里面讲了。  
![picture 47](images/6d0fb713e1286311545e5e3e373b5197e78183fd3f926902002d9717346dc6b0.png)  

https://web.archive.org/web/20210420233819/http://wiki.unity3d.com/index.php/Main_Page
搜"state"

![picture 48](images/44d2ef78a7d114117f4b312e55fe92d44cf620d317ca2b5d2ac2beea05db9830.png)  

但是上面这个网站已经过期了，我把代码里的注释打上去在谷歌搜到这个：
https://discussions.unity.com/t/finite-state-machine-project/416733

有限状态机管理游戏状态，  
游戏状态分为这几个状态：  
开始状态-开始状态也是我们的菜单状态  

游戏状态-游戏中的状态  

暂停状态  

游戏结束状态-失败   

（2）在scripts文件夹里新建文件夹FSM   
新建FSMSystem类把网络上的代码烤过去。

（3）FSMSystem这个类不需要继承自monobehaviour类，因为这个类不需要挂在游戏物体身上。

这里面一共有两个类：FSMState，FSMSystem。

FSMState我们需要把它挂在游戏物体上，所以我们需要FSMState继承自Monobehaviour。  
![picture 49](images/77190ef05dfe39598006806845190223f853b60a073343bee99e79af9a0385ec.png)  

我们将在Ctrl层创建含有四个状态的脚本。

（4）在代码中添加这4种状态：  
![picture 50](images/90576d74b9b518fde313fccd8e002abb5ff1bba4d2486badead01a0f090d6c4c.png)  

#### 14 . 创建四个游戏状态类和状态机，设置默认状态
（1）新建脚本  
![picture 51](images/89a1286c041703b9622adae598fd70616f8537080cb459beb3c942aaba14bbfa.png)  
这几个脚本都继承自FSMSatate。   
（2）
start()和update()方法暂时不用。  
![picture 52](images/a1d912ca86a9060dbe86ae7abbcd922f744b08c3e44e8854135d1cd3f9e84365.png)  
重写抽象类：  
![picture 53](images/78d82cd59ba659bcb8472530b2649d5b8daf462c7e59520abf1a2984ce0b48d6.png)  

这个Act()和Reason()方法在我们的State这边并不总是需要的，所以可以把Act()和Reason()方法改成虚函数，这样我们不一定去实现了。 
![picture 54](images/bad0fe88ef9b345d4a347299d940b8bcbd89d4bb5b5a93a81db0b85aa92f69db.png)  

performtransition里的foreach的完整版：  
```C#
        foreach (FSMState state in states)
        {

            if (state.ID == currentStateID)
            {
                // Do the post processing of the state before setting the new one
                currentState.DoBeforeLeaving();

                currentState = state;

                // Reset the state to its desired condition before it can reason or act
                currentState.DoBeforeEnterting();
                break;
            }
        }
```

改成这个样子：  
![picture 55](images/207137b93ce52f501ebee08544fae9427120e0400547a7be7e2bee3b67d9fcbc.png)  

这样重写的方法就可以删除掉了：  
![picture 56](images/015af1e6f37f5780d5412d0591a22318eb8f65333990c19faf85b8f63aeb1e3b.png)  

（3）把其他3个state也改成继承自FSMState  

(4)hierarchy的ctrl空物体下创建名为“State”的空物体。上面放置我们的四个状态。再把四个脚本拉过去：  
![picture 57](images/bb786187a3dc7e10627cfc8830820171f4523ecd1dd9520f42de80b62193c8a7.png)  
为什么把state做成游戏物体放在这里呢，因为后面有些事件需要状态来去监听，不同状态下一些按钮的点击事件，所以我们放在这里可以通过拖拽来监听一些事件。  

（5）接下来我们在Ctrl脚本构建有限状态机。  

原来FSMSystem是按照第一个调用的AddState的作为默认状态，没有设置默认状态的方法，我们需要自己写一个。  
这个s.ID我们还没设置，一会我们要去设置每个状态的id。  
在FSMSystem类里添加：  
```C#
    public void SetCurrentState(FSMState s) {
        currentState = s;
        currentStateID = s.ID;
    }
```
![picture 58](images/2ec3883f31921f29c1609f2248d2bb48779851f3d79bc122791f83336e251f49.png)  

Ctrl脚本代码：  
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    [HideInInspector]
    public Model model;
    [HideInInspector]
    public View view;

    private FSMSystem fsm;

    public void Awake()
    {
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();//FindGameObject后面没有s
        view = GameObject.FindGameObjectWithTag("View").GetComponent <View>();
    }

    void MakeFSM() {
        fsm = new FSMSystem();
        FSMState[] states = GetComponentsInChildren<FSMState>(); //获取子物体，子物体是State空物体挂了4个state的脚本
        foreach (FSMState state in states) {
            fsm.AddState(state); //遍历添加在状态机里
        }
        MenuState s = GetComponentInChildren<MenuState>();//设置菜单状态是默认状态
    }
}

```

#### 15 . 给状态添加ID，导入DOTween插件
（1）  

这个stateId有什么作用：用来控制状态转换的时候，通过stateId来区分  

在四个State脚本中：
```C#
public class Playstate : FSMState
{
    private void Awake()
    {
        stateID = StateID.Play;
    }
}

public class PauseState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Pause;
    }
}

public class GameOverState : FSMState
{
    private void Awake()
    {
        stateID = StateID.GameOver;
    }
}

public class MenuState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Menu;
    }
}
```
（2）  
在四个状态脚本里面可能会去处理一些事件，有可能需要进行状态的切换，要通过Ctrl脚本的FSMSystem fsm的Performtransition。  
在FSMState类中添加这两行让外界可以访问：  
![picture 59](images/b3f657fd773a0ac24485077aef5fa62576a9096da6e935d25827e04ff369dbbd.png)   
![picture 60](images/654b21a82bc23f37987c15deb824fb3a499dd8c4bfe3dbeb7dce4801adfebbe7.png)  
这样Ctrl脚本就可以访问FSMSystem fsm。

（3）在这里点击这个来设置dotween。  
![picture 61](images/fc63d77d6ed0ae200cdd53c563b7ac80040979df3b5a05a4340d7f44b65e3d7f.png)  
![picture 62](images/0e21d6601a1514d17bf98cd72581336dd33a1061f2c4965ec5a5e11d5bc62551.png)  

#### 16 . 开发菜单MenuUI的显示动画
（1）  
在View脚本添加代码：  
![picture 64](images/4c280ad3f967aa5a92cbed0327b3533935e49f75a66860b77b6ce2b99c3d5e1a.png)  

（2）  
在view脚本中添加头文件`using DG.Tweening;`

不同UI的Anchor是不一样的。  

把LogoName的anchor设置为上边：   
这一步要先设置不然PosY的值会变。   
![picture 68](images/def3ab8abab124e26f8d348a29b1e21115bb1ced4a8a78db5079602edd347302.png) 

默认LogoName的UI和MenuUI是在画面外面的，然后运动进来。  
复制这里的值：  
![picture 65](images/fed7352d67f96c4d93c2756e083825de1a058e5299ea8bc3b0239c17990bda29.png)   

![picture 67](images/f986c9c4a8d4a157e4e883b579989f2189bdacb9efbe2cbac952edb8a76e876f.png)  

然后把它拖拽到默认位置的外面：  
![picture 66](images/80be3886344308596f492a3322e00db2792134cd6badd0ec6e4fffc6358b77f4.png)   

LogoName默认是隐藏的。

对menuUI也做同样处理。  

View脚本：  
```C#
    public void ShowMenu() {
        logoName.gameObject.SetActive(true);
        logoName.DOAnchorPosY(-73.0f,0.5f);//时间暂时设置为0.5s

        menuUI.gameObject.SetActive(true);
        menuUI.DOAnchorPosY(101.97f, 0.5f);
    }
```
#### 17 . 进入菜单界面，调用菜单显示
(1)  
View脚本可以通过Ctrl脚本访问，所以我们可以通过MenuState访问Ctrl脚本，Ctrl脚本访问View脚本。  
修改FSMSystem脚本：   
![picture 69](images/28eacfb5f9cfe5f5f09f8fab91c2450f702aa6ab60dc85684e9f651f88307008.png)  
![picture 70](images/f6b81a4c995254a8bd09341cec6e3a61f50100b5d6423b17cfbbfb55ef737dc1.png)  
修改Ctrl脚本：  
![picture 71](images/d0c4942f6afc927bf7be3b48aec2a574b8ed3a341a5df43e2c76a9859a75a567.png)  

这样MenuState类就可以调用view类里面的方法。  
```C#
public class MenuState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Menu;
    }

    public override void DoBeforeEnterting()
    {
        ctrl.view.ShowMenu();  
    }
}
```

(2)但现在是状态切换的时候才调用DoBeforeEnterting()方法，默认情况下不调用这个方法。  
所以在SetCurrentState方法里添加代码`s.DoBeforeEnterting();`：  
即第一个状态（默认状态）时，后面切换状态时不用管。  
FSMSystem代码中：  
```C#
    public void SetCurrentState(FSMState s) {
        currentState = s;
        currentStateID = s.ID;
        s.DoBeforeEnterting();
    }
```

Ctrl脚本中：  
![picture 72](images/5ce3a2845f0c09b16f3765bb8cb232f5bff103f0d5691cc03939875f68b82590.png)  
MakeFSM()在Ctrl脚本的Awake()函数里调用。

ShowMenu方法访问logoName和menuUI是在View脚本的Awake函数里访问。所以有可能logoName和menuUI会出现空指针。

怎么解决问题：   
赋值在Awake里面，调用在Start里面。  

所以在Ctrl脚本中：  
![picture 73](images/5e2622a996cb355c99d678707b77c12d6bdd30ef942d869a8b98158ad835daee.png)  
![picture 74](images/166a9bdcdb7104fe6d8616d6739d0eb4bec378e5684a4af8a9899588c6891d74.png)  

#### 18 . 控制相机的动画（视野放大和缩小） 
（1）  调整相机POSY  
![picture 75](images/3eade2f1499eb89cb22007cc2dc820df4347321cd3715db865654833282ec32e.png)  
目前的GameUI挡住背景了所以摄像机需要向下调整。  

![picture 77](images/2018b4beab23b0eae5c35da4b0be3359a6c288073c046400b33cc4d99facc1c3.png)  
![picture 76](images/95c2db327bc9f5ae65a2b6de2a76536a84e082fbbbc0b9e2bd54b85a7640b53a.png)  

（2） 调整摄像头size  
因为背景需要在这两个UI之间。  
![picture 78](images/35234b9bd15c4e244ab56ea793ea6be588aa63b7a1984787b47b6ce520c2c5f2.png)  

调整这个位置：  
![picture 79](images/d070b4c4632fc49df17ef3293fe7e97e7e693fabd80314d2f25ad49391d856f1.png)  

通过代码控制相机的size变化：  
在Ctrl空物体新建脚本CameraManager.cs  
![picture 80](images/6a3c9335c8b01d6867298b71d1351a9aad9bab633bdc589f24192e530ab6267a.png)  
```C#
public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    //放大
    public void ZoomIn() { }

    //缩小
    public void ZoomOut() {
        mainCamera.DOOrthoSize(16.48f,0.5f);
    }
}
```
(3) Ctrl脚本里添加：  
![picture 81](images/d6350a04e2cddfbe295df4f3d065a263b1065c060811b70213bbd2b29f759b17.png)  

（4） MenuState脚本里添加：  
![picture 82](images/2450513f1831b2a6f7e0152d2cbf74b6ddf1c06ae6f67abce3120e055cc6bc7f.png)  

（5）把相机size改成1000，让背景一开始看不到。
![picture 83](images/b350f08898087cd3dbfc9630cd62e4a402537714d5df34ba8aa21e21d96c055d.png)  

