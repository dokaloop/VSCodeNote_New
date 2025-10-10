### MVC俄罗斯方块（下）
#### 19 . 控制MenuUI的隐藏   
(1)
功能：  
点击这个按钮从MenuState切换到PlayState，   
把menu菜单隐藏掉，显示我们的play菜单  
![picture 0](images/c153d245ac0058d84f964ba7de8e9370c98e5c0f76a38ed5516879fa79dac0dd.png)  
给这个绿色按钮添加事件：  
![picture 1](images/936d780ee051774911c622fefe9c67990742ec06961977ab61ac367d403c7e5c.png)  

（2） 在FSMSyestem脚本中添加这一行代码：  
![picture 2](images/c37082535fb46462f35d9969e2e6bca8388a17287b414ebcb8d5c80d5e124f51.png)  

(3)MenuState脚本：  
![picture 3](images/d7bb323e50bec9b77e44019858373143305caf1773ad2f8a838eaa0a71669fc1.png)  

（4）  
View脚本添加代码  
```C#
    public void HideMenu() {
        logoName.DOAnchorPosY(64.71f, 0.5f)
            .OnComplete(delegate { logoName.gameObject.SetActive(false); });
        //鸦疑问：siki说这样SetActive(false)节省性能，真的么？

        menuUI.DOAnchorPosY(-104.5f, 0.5f)//UI移出画面
            .OnComplete(delegate { menuUI.gameObject.SetActive(false); });
    }
```
MenuState脚本添加代码：  
```C#
    public override void DoBeforeLeaving()
    {
        ctrl.view.HideMenu();
    }
```

#### 20 . 开发游戏运行中的UI的显示和隐藏
playstate我们要显示的就是GameUI，GameUI从上往下显示。

(1)在View脚本添加代码：  
![picture 4](images/a82b106e3a5b3505f01d2f5d01580899eb3c09a377ae6bee6ec402209eea1c8d.png)  
```C#
    public void ShowGameUI() {
        gameUI.gameObject.SetActive(true);
        gameUI.DOAnchorPosY(-189f,0.5f);
    }
```

PlayState脚本：  
```C#
public class Playstate : FSMState
{
    private void Awake()
    {
        stateID = StateID.Play;
    }

    public override void DoBeforeEnterting()
    {
        ctrl.view.ShowGameUI();
    }
}
```
(2)背景放大：  
在CameraManager脚本添加代码：  
```C#
    //放大
    public void ZoomIn() {
        mainCamera.DOOrthoSize(13.15f,0.5f);
    }
```
在PlayState脚本添加代码：
![picture 5](images/b2ee3b3be1b5ebe045d52eb8e9a614076eb70b6d3f171df8b56a85d14e12fe7a.png)  

（3）点击暂停转换到最开始MenuState界面，并且显示重新开始按钮（该按钮一开始不显示），所以restartButton一开始是隐藏的。  
![picture 6](images/fcd30b03b48aee050a7dfd5b5e104d67c291968b27e71892585e2ee81715f431.png)  
![picture 7](images/9281d3682e402d416fa23b28d36e827d2383d5ffef2a7c27eeb64c7e8ad3b83d.png)  

(4)  
在FSMSystem脚本中添加代码  
![picture 8](images/54b098f804135004357f7a9e3ce33bdbebc6284c7637b7921aa1c8bc0a5d2503.png)  

在PlayState中修改代码：  
```C#
public class Playstate : FSMState
{
    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.PauseButtonClick, StateID.Menu);
    }

    public override void DoBeforeEnterting()
    {
        ctrl.view.ShowGameUI();
        ctrl.cameraManager.ZoomIn();
    }

    public override void DoBeforeLeaving()
    {
        ctrl.view.HideGameUI();
    }

    public void OnPauseButtonClick() {
        fsm.PerformTransition(Transition.PauseButtonClick);
    }
}
```

在View脚本添加代码：
```C#
    public void HideGameUI() {
        gameUI.DOAnchorPosY(189f, 0.5f)
            .OnComplete(delegate { gameUI.gameObject.SetActive(false); });
    }
```

（5）点击Pause按钮会显示“重新开始”按钮。  
在View脚本添加代码：  
![picture 9](images/a5a8cca38a83c2e524e40a9c258ddd3406313e8f2a908a0187041204e686f6cb.png)  
![picture 10](images/b9f47320194d130b4be2a2da0f88165e42f4412df101329deed6d6719cd2a7fc.png)  

（6）在PlayState脚本添加代码：  
![picture 11](images/45e6e5f38729ae9da30cf396c677b088913a817edccee4ca5655599dddadeba9.png)  

#### 21 . 控制俄罗斯方块图形的生成
(1)在Ctrl空物体上创建脚本“GameManager.cs”并把脚本放到Ctrl文件夹底下。  

（2）在Ctrl文件夹下新建脚本“Shape.cs”。  
选中这7个prefab，并且点击addcomponent把shape脚本挂上去。  
![picture 12](images/ee68ac8382099b42dc94e8f1815949d756de4633514bd7895310b184c851f00a.png)  

（3）  
GameManager脚本：  
```C#
public class GameManager : MonoBehaviour
{
    private bool isPause = true; //游戏是否暂停。默认是暂停状态

    public Shape[] shapes;

    public Color[] colors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause) return;//如果暂停下面不运行
    }

    void SpawnShape() {
        int index = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);

        Shape shape = GameObject.Instantiate(shapes[index]);
        shape.Init(colors[indexColor]);
    }
}
```

Shape脚本：  
```C#
public class Shape : MonoBehaviour
{
    public void Init(Color color)
    {
        
    }
}
```

#### 22 . 完善图形的生成和游戏的暂停
(1)在gameManager脚本中添加代码。  
![picture 13](images/5091e757c1d77bb1fa3cded23d600048d6bf1e693d1d33817bbf4637534c6082.png)  
```C#
    void Update()
    {
        if (isPause) return;//如果暂停下面不运行

        if (currentShape == null) {
            SpawnShape();
            //当currentShape落地之后，我们把currentShape设置为空，
            //这样我们就可以通过是否等于空去判断，当前有没有新的图形正在下落
        }
    }

    void SpawnShape() {
        int index = Random.Range(0, shapes.Length);
        int indexColor = Random.Range(0, colors.Length);

        currentShape = GameObject.Instantiate(shapes[index]);
        currentShape.Init(colors[indexColor]);
    }
```

(2)Shape 脚本：  
```C#
public class Shape : MonoBehaviour
{
    public void Init(Color color)
    {
        foreach (Transform t in transform) {
            if (t.tag == "Block") {
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
}
```

(3) GameManager里面添加脚本：  
```C#
    public void StartGame() {
        isPause = false;
    }
    public void PauseGame() {
        isPause = true; 
    }
```
在Ctrl脚本里添加代码：  
![picture 14](images/1fab8f317768ef37a67ebba0802e79be416c27d01f8356ac9d3a4ec34e242101.png)  

在PlayState脚本中添加代码：  
![picture 15](images/177a96c8b23ce1ad7ee168ed3c11e42b040c03fe17d81d9d18a15a35320afe49.png)  

(4)先把Ctrl层的空物体锁定。  
![picture 16](images/528b2568fbfbf3bf2c367edca7648c32a5174dd845ff326008c986a06b8deefc.png)  
选中7个形状预制体拖拽到Shapes。  

颜色设置为7，每个颜色去取一下。  
![picture 17](images/5391b11f50602e2ad4e6b75c219900fe9e840418381561826d4ae9a24db880eb.png)  
alpha全都在右边（手动调一下） !!!!!!!一定要调不透明度，默认是透明的。  
下面这一行是Shape的颜色。  
![picture 18](images/49e9b049f200b8021b9bfcd3eea47213e759f3a375075273422cada73b400dfb.png)  

#### 23 . 控制图形的下落
Shape脚本：  
```C#
public class Shape : MonoBehaviour
{
    private bool isPause = false; //当为true代表该图形触底
    private float timer = 0;
    private float stepTime = 0.8f;

    private void Update()
    {
        if (isPause) return;
        timer += Time.deltaTime;
        if (timer > stepTime) {
            timer = 0;
            Fall();
        }
    }

    public void Init(Color color)
    {
        foreach (Transform t in transform) {
            //这个方法是遍历所有的孩子的，所有的孩子就是t，因为形状的孩子有pivot也有block，我们只改变block的颜色。
            if (t.tag == "Block") {
                t.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }

    public void Fall() { 
        Vector3 pos = transform.position;
        pos.y -= 1;
        transform.position = pos;
    }
}
```
现在是会一直下落的。  

#### 24 . 判断图形所在位置是否可用
（1）在Scripts文件夹下建立Tools文件夹，里面新建Vector3Extension.cs脚本。  
```C#
public static class Vector3Extension 
{
    public static Vector2 Round(this Vector3 v)
    {//this表示扩展哪个类，扩展的是三维向量Round方法。
        int x = Mathf.RoundToInt(v.x);
        int y = Mathf.RoundToInt(v.y);
        return new Vector2(x, y);
    }
}
```

(2)Model脚本：  
```C#
/*
 * 在model层保存数据，当这个格子有图形了，我们就保存它的transform组件，
 * 当这个格子没有的时候就保持为空，如果这个格子存在图形，就不能下落了，如果不存在就可以继续下落。
 * 这就是第一个方格pos为(0,0)的原因。位置和二维数组的索引对应。
 */

public class Model : MonoBehaviour
{
    public const int MAX_ROWS = 23;
    //23是为了判断游戏是否结束使用的。如果下面都填充满了图形，上面三行也有格子无法继续下落，说明就没有多余的空间了
    public const int MAX_COLUMNS = 10;

    private Transform[,] map = new Transform[MAX_ROWS, MAX_COLUMNS];

    public bool IsValidMapPosition(Transform t) {
        foreach (Transform child in t) {
            if(child.tag != "Block")continue;
            Vector2 pos = child.position.Round();
            if(IsInsideMap(pos)==false)return false; //还要判断是否超出边界
            if (map[(int)pos.x, (int)pos.y] != null) return false;
        }
        return true;
    }

    public bool IsInsideMap(Vector2 pos) {
        return pos.x >= 0 && pos.x < MAX_COLUMNS && pos.y >= 0;//y只用管下边界
    }
}
```

#### 25 . 控制图形的下落和叠加
（1）Shape脚本：  
![picture 19](images/c8b69cee59a2163fb0b7038d73732de19c6e2f6ba652f8ff9d9bda71d1892424.png)  
![picture 20](images/9961b53afee9484fd22b26abb0d24173f1427a9b3d80a65f43843147f77ea8a7.png)  

（2）GameManager脚本：  
![picture 21](images/f034b1a8f40138d36dae1ad145dd7b1cf8e859d46439c799600d36967c83538f.png)  
![picture 22](images/f07c42f38d831b87f8584d42f8b82380d81cd926e785044db1b6273b6022e211.png)  

（3）Shape脚本中：
```C#
    public void Fall() { 
        Vector3 pos = transform.position;
        pos.y -= 1;
        if (ctrl.model.IsValidMapPosition(this.transform) == false)
        {
            isPause = true;
        }
        else {
            transform.position = pos;
        }
    }
```
![picture 23](images/3e613e95b452647b13a28dcf8075fd4afc225cba1defb7ee31c6b1c028f8eab8.png)  
![picture 24](images/64e551249f9b12745238389fb8d17285135211b1245bc2f2e70b6432b29bec16.png)  

在GameManager脚本中：  
![picture 25](images/54960a10cb70cae6e15757efc0d545a2ac32f9a26740a0a93262da702e4c8986.png)  
```C#
    //方块落下来了
    public void FallDown() {
        currentShape = null;
    }
```

Shape脚本：  
![picture 28](images/474f70848271e10d8b35511d3169ea3964c91c6a7d2bb5ea2c3f67f9941c33c7.png)  


（4）为了让停止后将形状移动到map里面。  
在Model脚本添加代码：  
```C#
    public void PlaceShape(Transform t) {
        foreach (Transform child in t) {
            if (child.tag != "Block") return;
            Vector2 pos = child.position.Round();
            map[(int)pos.x, (int)pos.y] = child;
        }
    }
```
Shape脚本添加这行代码：  
![picture 29](images/88655955b91ee398c301e19d08de63b56b26a6d9121a71b39219656763aedc05.png)  

(5)在暂停时让shape的下落也暂停住。  
在Shape脚本中添加脚本：  
```C#
    public void Pause()
    {
        isPause = true;
    }
    public void Resume() {
        isPause = false;
    }
```

在GameManager中修改脚本：  
```C#
    public void StartGame() {
        isPause = false;
        if (currentShape != null)
            currentShape.Resume();
    }
    public void PauseGame() {
        isPause = true; 
        if(currentShape != null)
            currentShape.Pause();
    }
```

#### 26 . 给游戏添加音效
(1)在Ctrl文件夹创建新的脚本AudioManager.cs，并把它挂到Ctrl空物体上。  

为Ctrl空物体加上AudioSource组件。  

AudioManager脚本：  
```C#
public class AudioManager : MonoBehaviour
{
    public AudioClip cursor;
    public AudioClip drop;

    private AudioSource audioSource;
    private bool isMute = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCursor() {
        PlayAudio(cursor);
    }
    public void PlayDrop() {
        PlayAudio(drop);
    }

    private void PlayAudio(AudioClip clip) {
        if (isMute) return;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
```

![picture 30](images/ddbe4abfc886881f06e676772df4058c99e0ba96fcc1dab737ea6c73f9ea9950.png)  

在Ctrl脚本：  
![picture 31](images/710f200ad6da55c007534099da93f4142331c473355c9fe731af52c5f3ddee5c.png)  

在MenuState脚本：  
![picture 32](images/14f8ab53c938d12eddb63a52e23c672c1065dd9a0784bd7b057b60e5a2831915.png)  

在PlayState脚本：  
![picture 33](images/54e73edee53c632a5a44f597d11abbb7634f8618be9b4e84a28eddad228ec7b9.png)  

在Shape脚本：  
![picture 34](images/7a94a9a4a56659ffbaef24ab8cd26f2f9a246145488db1ded4f454172c4a3083.png)  

#### 27 . 控制图形方块的左右移动
(1)Shape脚本  
![picture 35](images/0fc142e7670295b56ca77048d31c68550ddd1760a634759b86254611c6788f41.png)  

```C#
    private void InputControl() {
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0) {
            Vector3 pos = transform.position;
            pos.x += h;
            transform.position = pos;
            if (ctrl.model.IsValidMapPosition(this.transform) == false) {
                pos.x -= h;
                transform.position = pos;
            }
        }
    }
```

(2)添加音效   
AudioManager脚本  
![picture 36](images/1f75519c2f5a932520e6561ecec88ec37bee900caeaff84c407a8018c8886fbc.png)  
![picture 37](images/b23aa68b72928e5681aa2dd616772aa5d25617ec0eee4fb98eaf6ede2dcf9cbd.png)  
Shape脚本：  
![picture 38](images/4779459aac53ddabf0e69b328b077bba84a922a868ccda574671edfe0bf8993c.png)  

（3）但是我们只需要一格一格的移动，不需要一下移动这么多。  
在Shape代码中：  
![picture 39](images/de3ad4a956f284813e12b5752447a9ca8074cb5a701c045043dac06aa42852be.png)  

下面这边改成：  
![picture 40](images/9b2d275d2a4f8fcd43e99f61d3e962904ec289d58d79f33de909e8e34e726e37.png)  

#### 28 . 控制图形方块的顺时针旋转
Shape脚本：  
![picture 41](images/9ae5492019a05967f5fe2bdb00ec8c9181c4c9dafc3e4cb1cbac549c0eb30eff.png)  

Shape脚本里InputControl方法添加代码：  
```C#
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.RotateAround(pivot.position, Vector3.forward, -90);
            if (ctrl.model.IsValidMapPosition(this.transform) == false)
            {
                transform.RotateAround(pivot.position, Vector3.forward, 90); //第二个参数是什么轴
            }
            else {
                ctrl.audioManager.PlayControl();
            }
        }
```

#### 36-控制图形游戏物体的统一管理和多余游戏物体的销毁
（1）  
在Ctrl空物体创建新的空物体叫"BlockHolder"。  

GameManager :   
`blockHolder = transform.Find("BlockHolder");`  

(2)有一个问题：索然Shape下的Block被销毁，但是Shape不会被销毁。  
![picture 42](images/676f4080e66a89578bdf6244823abdee53557f3de61409f413945e18884e6c87.png)  

```C#
        foreach (Transform t in blockHolder) {
            if (t.childCount <= 1) { //Shape的孩子只剩一个pivot时
                Destroy(t.gameObject);
            }
        }
```

#### 37-控制设置界面的显示和音效是否静音的控制
(1)在SettingUI上添加Button组件    
Transition设置为None  
![picture 43](images/747bd5f611839e7c9391d10233d4d3bd254c5078f3d7ce78457ffb08c37feb86.png)  

#### 38-控制记录界面的显示
(1)不能直接在View脚本更新RankUI的数据，因为这样VIEW层和MODEL层就互通了，会显得比较乱。  
所以OnRankButtonClick()函数要写在MenuState脚本里面。  

#### 39-控制游戏的重新开始（课程结束）
（1）在rankUI上添加button组件控制隐藏。  
Transition设置为None  