# Create ELDEN RING in Unity ► EP. 1 Netcode For Gameobjects

版本
![picture 0](images/2ee09c391bd4e30e1467ab61e36d085b21756abcf3f22341c6dfb8f99808c360.png)  
新建一个：empty urp template作为project。
SRP means scriptable render pipeline. SRP allows users to customize the rendering engine for unity. 
如果想后期转pipeline可以在google搜“Converting a Project from the Built-in Renderer to the High Definition Render Pipeline”
好奇How to go between the built-in renderer and the scriptable render piplelines，搜索“Installing the Universal Render Pipeline into an existiong Project”
- URP Roadmap:https://portal.productboard.com/unity/1-unity-platform-rendering-visual-effects/tabs/3-universal-render-pipeline
- URP Docs:https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@10.8/manual/index.html

1 . 
（1）添加netcode   
去package manager  
![picture 1](images/37d5d9811766b40a682adcfd29336d5e1dc941e1d822ff0c32013fa3432d9b02.png)  

change to **unity registry** in **packages in project**  
![picture 2](images/39a1cc89faff672dee9bf958be3396ac7c536a45d1306f37c5d9bf04c479da80.png)   

再搜"netcode"
![picture 3](images/457d484e676fe5c5eb32562fa5dd6ab678a8580b2514a774b90f8dcdfc347412.png)  

(2)导入parrelSync link   
parrelSync is a unity editor extension that allows users to test multiplayer gameplay without building the project by having another unity editor window opened and mirror the changes from the original project.   
【1】
PackageManager ->  
左上角 + 号 ->  
Add package from git URL ->   
![picture 4](images/70274ed10f7e7780773c236235136ed1278e5a0f35ccbac06cd07d71cab99c2e.png)  
youtube描述区下的网址：
https://github.com/VeriorPies/ParrelSync?path=%2FParrelSync   
但这个直接填在里面是不行的，要加上git：  
如下：https://github.com/VeriorPies/ParrelSync.git?path=%2FParrelSync  
%2F好像就是/来着  
![picture 5](images/0ab4647b20a865c292bfa8ea72ce3a8081c597b0cda1a3ec2c29e188b710ffbd.png)    
注意：  
电脑系统里要有GIT,且不连vpn。【注意看报错】  
【2】然后这里就有了：    
![picture 13](images/d9229df1a708890eb69a2e0f3e2f982bc9e9f3f4dd979aea1f71febd60ad22f5.png)  
【3】把clone manager拽到inspector面板旁边  
![picture 14](images/eacefd682757d2ba184c61a80c1a3b2dda7c188a6f559def60f99f3d25de7000.png)  

2 .   
(1) create an empty gameObject called "Network Manager".  

(2) We're going to use a script from Netcode for gameObjects called “NetworkManager”. 
Just think of this like the thing that takes in all the information for the network between you and other players.   

(3)在networkmanager的script里 The only thing you need to change on this is the transport. 现在用Unity Transport, 未来用Facepunch.Steamworks。  
![picture 6](images/a53d32db3b04bef0d10e3915e804c07899efd8bc37e3afdeb183faf5cbeb2157.png)  
(4)单纯介绍：A host acts as a server and a client meaning a player and the server itself. A server will be something if you had something like in the cloud that just processes the information and a client is just a game client that connects to a server.  

3 . 
（1）在assets底下新建一个文件夹叫Art,  
在Art底下新建一个文件夹叫Models，把教程视频description section 里的【LOW POLY MAN】拽到【Models】文件夹下面。  
![picture 9](images/aa2a505ba35548e3cd0bfc6fb75f0584e37947c20aa2d3af38f7ece1428943f3.png)    
（2）新建一个文件夹叫【Data】,在其之内创建【Prefabs】文件夹。  
（3）把lowpoly小人模型拽到scene面板，把其名改为【Player】再把这个Player拽到新建的Prefabs文件夹之下，提示框选择“Original Prefab”  
（4）然后再把secene面板中的Player的gameObject给删了。  
（5）把这个【Player】的prefab拽到Network Manager的“Player Prefab”这一栏里  
![picture 15](images/5590728747747f3574f87ce73b4f284ad31d50e9bfcd63d911129aaf7f8708e3.png)  
 (6)【Player】的Prefab里Add Component: NetworkObject  
 解释：you're going to be adding this to basically every character in your project that is going to have some network data 之类的操作。e.g. all players, probably all of your AI  

4 .   
（1）在scene里创建image（UI）作为title screen menu.  
（2）取消勾选此image的Raycast Target，因为它不需要被鼠标点击事件track,勾上这个只是浪费内存。  
![picture 16](images/ce7250bb5722aa860ecb2aedba46b946784386e0e2477b8320b62dfb76038bbe.png)  
（3）在canvas的UI Scale Mode里选择Scale With Screen Size。  
（4）canvas的这里改成1920x1080  
![picture 17](images/c4472f6e8db1824f4d262c4c481370a819c0ba38fdf0f1e6cc131327b59d71a1.png)  
（5）image改成黑色，image的anchor那里按住alt点击最右下角的那个按钮让image伸展到全屏幕。  
再把image的名字改为Title Screen Background

5 . 
（1）把canvas改个名
![picture 18](images/2009063787493eaac8b5ff754be1d465d6a6243a500d44c82568c06684dfe94b.png)  
（2）给Background下新建Text子物体并改名“Title Screen Banner”  
（3）调整text的anchor到上端  
![picture 19](images/1a3f5e773ef36c289558edc09d2ec9cb15b6f239e6b13d57f223ba935a6856f4.png)  
（4）在Background底下加个button叫“Press Start Button”并调整anchor到底下。然后uncheck raycast target.    
（5）改button的这两个颜色  
![picture 20](images/d9b10b12882748c734705f8f048bbfe8d352c8ce8065c97b9fb070cda68dec0e.png)  

6 .   
(1)在“Title Screen Canvas”下新建script起名“TitleScreenManager”
输入代码
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace SG
{
    public class TitleScreenManager : MonoBehaviour
    {
        public void startNetworkAsHost() {
            NetworkManager.Singleton.StartHost(); //start network as host
        }
    }
}
```
这个函数的作用是相当于点这个按钮。  
![picture 22](images/1adfdc4a653560ba11431c8022d484215ea27b0d993478db63a2fbac43ad4faf.png)  
(2)然后把这个事件拽到button上。  
(3) 解释：the host is kind of like the server and a client at the same time.  
It is both a player and the server authority.   
A client is just a game client connecting to another host or a server.   
(4)event system的first selected把这个拽过去  
![picture 23](images/9ef4f52301ff0c6711a4d9f87e3062754ba774f42e9b55db21b01a85208e8c5f.png)  
解释：this makes it when you start your game and automatically selects the press start button which is good if you're using a controller.  

7 .   
（1）把pressStartButton复制一份改个名字newgameStartButton，再把pressStartButton disable一下。把newgameStartButton的onclick事件删了。    
![picture 24](images/e83022c8d26de56099ec64f2a984ebd9683294eff7272741195318ad4f721ac4.png)   
（2）在原本的pressStartButton下添加onclick事件  
![picture 25](images/eb42597896c182c1c5f313adf6b818f306dc358678377a932350dd055d4d616a.png)  
(3)在“Ttile Screen Background”下建立empty gameObject改名“Title Screen Main Menu”，  
按住alt把它anchor和position调整到最右下角那个全屏。    
（4）再让new game start button是它的子物体。  
![picture 26](images/4fac936f10ee0278deff5ca305ad69347a042113a15443c3730f064b4a951774.png)  
（5）在pressStartButton下继续添加onclick事件  
![picture 27](images/c3108983baa60a694f864087f1b0866f18891d2dfa1361e9a98bad014503d0f4.png)  
 绿圈解释：so if you press startButton, it will automatically select NewGameStartButton.  
 (6)然后把Main Menu disable了，把PressStartButton enable了。  
 ![picture 28](images/ac141cd89cba5aa8fc6baa0225442c20de295cd80603bb3584333abd7ab2d597.png)    
（7）记得把steam关了。

8 .  
（1）另存为Scene_Main_Menu_01这个scene，把sampleScene给删了。  
（2）新建一个scene，改名“Scene_World_01”。  
（3）在File->build setting里把这两个scene通过“add open scene”添加进去。  
![picture 29](images/f410c5bcb258d03e0b7856deccdef9692efa8924235a2094bc0ba0590bd44d3b.png)  
（4）![picture 30](images/487bf6989fb9c91ce052442b5bb8e2b1866a7a4889fb3c3698a91a146154b5c5.png)  
（5）在之下添加WorldSaveGameManager的script
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SG
{
    public class WorldSaveGameManager : MonoBehaviour
    {
        public static WorldSaveGameManager instance;
        //this is going to be Singleton.
        //So this allows the script to be accessed from anywhere in the project at any time
        //and there's only one in the project at any given time.
        //you might want to use a getter and setter so you can't accidentally override that.

        [SerializeField] int worldSceneIndex = 1;

        private void Awake()
        {
            //THERE CAN ONLY BE ONE INSTANCE OF THIS SCRIPT AT ONE TIME, IF ANOTHER EXISTS, DESTROY IT.
            //means: On awake, we want to check to see if this variable has been filled.
            //If instance is not null for some reason, it means there's two of these scene at one time. there should never be . 
            if (instance == null)
                {
                    instance = this;
                }
                else {
                    Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            //meaning this stays with us through every scene that we load into
        }

        public IEnumerator LoadNewGame() {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(worldSceneIndex);
            yield return null;
        }
    }
}
```
(6)TitleScreenManager的代码这里添加一个方法。  
![picture 31](images/d9f18d1be167617025cd2a64ffd46aa81fe16c491fa627bf1b2b29fa19f9ffec.png)  

（7）在New Game Start Button下添加onclick事件。  
![picture 32](images/43592018ba3cae407483c903cca826cf20cf46dafaae7ccc9e0f82178f710759.png)  

8 .  
(1)our player model does not survive the scene change. So we need to make it so when our player model spawns, when the network starts, he survives the scenes changing  
所以在palyer的prefab里添加脚本：  
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CharacterManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
```
(2)创建物体并添加脚本  
![picture 33](images/16fec021f68c7ac754bb706467e88da70d018c3e4a7c9e7374934c6ec7e28fe1.png)  
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace SG
{
    public class PlayerUIManager : MonoBehaviour
    {
        public static PlayerUIManager instance;

        [Header("NETWOEK JOIN")]
        [SerializeField] bool startGameAsClient;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else {
                Destroy(gameObject);
            }               
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (startGameAsClient) {
                startGameAsClient = false;
                // WE MUST FIRST SHUT DOWN, BECAUSE WE HAVE STARTED AS A HOST DURING THE TITLE SCREEN
                NetworkManager.Singleton.Shutdown();
                // WE THEN RESTART, AS A CLIENT
                NetworkManager.Singleton.StartClient();
            }
        }

    }
}
```

(3)在Prefabs下新建文件夹，把这些都拽过去。  
![picture 34](images/803bcc482c5c80b034d27b1a8cf844c401e7c546e62d897719626b710ad1bd50.png)  
(4)Clones Manager -> start new clone -> open in new editor  
(5)点两下client editor里的这个  
![picture 35](images/555b63b7da07b1b0eb520a5c6387053bd2e18f2c95d115feea4b0ad54c0dd574.png)  
(6)host editor的player模型变成两个了。