## COCOS_siki
BV18m421L7Ac
### 一 . 前提讲解 
1 .  
下载editor的默认位置修改：  
![picture 1](images/3410522ecd1923207883f0ff4e190efb7f708c0c6c3ca402dc7a4839365c92dc.png)  

2 . hello world  
https://docs.cocos.com/creator/3.8/manual/zh/getting-started/helloworld/

3 .   
![picture 2](images/7fbb8a5f6a6f5d234183c2b3d2d94b18f3afdccd900fb424b61fc4c030bdb70c.png)  
![picture 3](images/7185a2ac9b625708ac5b65cfbf48d061d0b6d74eafd30174dd7fe8c4d507a627.png)  
.meta文件用记事本打开发现是json文件的文本。cocos为每一个资源创建爱你一个meta文件，meta文件相当于是它的个人信息或者身份证，里面会存储每个资源的id，因为在cocos里面资源之间互相引用互相调用。

4 . cocos的组成：
Cocos-多个场景-Node-Component  

5 .    
（1）可以设置漫游或者滚轮的速度：  
![picture 4](images/c308232b4222fd0a011a6f7020e4a40b9f2711a0fb7e9ffd6a715982f711dc13.png)  

（2）按住物体后alt鼠标拖动可以对准焦点旋转。  鼠标滚轮也可以更聚焦。

6 . 相机长宽比：  
![picture 5](images/e34d3aad0d4fabb759675577ab3a604c9677daf205568f5c35daece4bea37b35.png)  
![picture 6](images/b92c0ca2f7e2d7e59333900bdb758ab93134bb212a4399d0b4267a1bd1decee8.png)  
![picture 7](images/4d3a048388640af088560263664d27db25a7b8722de13fb97c1ca9eabaa172ea.png)  

7 . 
脚本编辑器，浏览器的配置。  
File - Preferences  ：  
![picture 8](images/a8a45f384853fd8690cdad3567e63fe1639319164c6fb6fa3d200a8492133aaf.png)  

### 二 . 打砖块  
1 . 关于Prefab预制体的使用   
prefab在hiearchy中的孩子如果哪里（某个属性）先动了，预制体即使这个属性后动，这个孩子的这个属性也不会跟着预制体动。  

2 . 刚体组件（重力），碰撞器组件（边缘碰撞检测）   
- 要下落的方块挂（刚体组件 和 碰撞器组件）
- 地面挂（碰撞器组件）

3 . scene场景图标不显示：  
![picture 9](images/ada5402255bd2a0bfdad5d53481506c9801d0cf5de81d541ab607b9aee5c4407.png)  
![picture 10](images/14fd7548fd536b1bfbe3174b84857b044fab006d9f333332c37d8577a31642aa.png)  

4 . 怎么检测触摸事件-onTouchStart  
![picture 11](images/96c2b21d7254a0fad62bfe7e0222286824be78f6f846bbd328a10e410be9de70.png)  

-----
![picture 12](images/6f270aa162e1d03c44f1a61e00d99d5982a348c5b1c28a98e3c9059cddccb49b.png)  

TOUCH_START : 按下鼠标的瞬间；    
TOUCH_END: 抬起鼠标的瞬间；  
TOUCH_MOVE：每一帧只要移动就会调用  
--event.getDelta 相对于上一帧移动的像素偏移量  

5 . 脚本中的属性-property-基本类型和CC类类型  
![picture 13](images/1aafc5b9b88446335bc6699e9dd3e6e470ec7a447db8e8ec859802ff4efe1ef4.png)  

6 . 为了更好地编译调试可以不选在 “浏览器中预览”选择“编辑器中预览”。  
![picture 15](images/9f06e349dae09713149a98ad430b498e85bc0e33853e8728b31ccd313d7c4040.png)  

点击这个可以让屏幕和窗口保持一致。  
![picture 16](images/811b892f16c9843b3ff220417f395805e5442e40acaa4fa25e8d518c53b89529.png)  

7 . 
(1)情况1：   
墙-collider  
球-rigidbody, collider  
球撞墙会停住，但是墙没有任何变化  

(2)情况2：   
墙-rigidbody,collider  
球-rigidbody, collider  
球撞墙会停住，但是墙有变化  

直接给墙加上rigidbody之后，还没放进去球也会这样不固定乱飞：  
![picture 17](images/97096867135c5d6ab0eaf32cb8b25627a4a66505bf7616d47fdc3ed16cbbebf1.png)  

```
解决方法【弹幕】：  
我的墙体一生成 还没打就倒了

墙会倒把刚体组件里面的Linear Damping还有Angular Damping调到1就行了。实际上会倒的原因应该就是阻力太小了（用户手册上面看来的）
```

### 三 . ROLL A BALL  
1 . 学习键盘事件的调用  
![picture 18](images/9441202da18604451346257267abfbc2c4077364eb339316fbf8b5b551225576.png)  

键盘从按下到抬起的调用：
KEY_DOWN(一次)--->KEY_PRESSING(只要你还按着就疯狂调用)--->KEY_UP(一次)  

`event.keycode`输出键盘的对应的ascii。  

几种情况：  
（情况1）当`A`和`B`的键盘同时按下，KEY_PRESSING只会输出其中某一个按键的码。  
（情况2）当先按住`A`一段时间再按住`B`，那么KEY_PRESSING输出的码一直是`A`的，然后不再输出`A`的，转而输出`B`的。  

2 . 通过onKeyPressing事件控制小球前后移动（比较僵硬，当按下两个按键只会对一个按键进行相应。）  
![picture 20](images/e38a0adbd0705ec454840bdd6a37269239caae23353c1d6ea7b1a8092e607ac5.png)  
![picture 21](images/898d1e78580ffc58dffbeaf92953363ab3a20d207d5b4e97524ed473778a2e28.png)  
update()里面可以获取deltatime帧时间，但是onKeyPressing里面获取不到所以我们手动改写速度是0.2

3 . 碰撞事件 触发事件  
碰撞事件：两方物体都要有collider，其中一个物体要有刚体。  

【碰撞事件】小球撞到食物会发生停顿，食物影响小球的运动。别的节点不可以进入它的体内。
【触发事件】食物不影响小球的运动，别的节点可以进入它的体内。(食物的isTrigger要勾选)

### 三 . 方块
【cocos官方文档有这个案例】 
https://docs.cocos.com/creator/3.8/manual/zh/getting-started/first-game-2d/    
1 .   
图片在这里修改：  
![picture 22](images/7f2cb44ac05b029428aca666753e6173e0059525b2911ab0f94373e291a1e3c2.png)  

2 .   
![picture 23](images/7aa117b948e205f73824435395246d48754f4341b153287a3c97527ff35e3028.png)  
Allign Canvas With Screen 不取消勾选的话它就会控制Camera只去渲染Canvas的范围。就算camera位置发生变化，canvas和camera的位置也保持恒定。  
![picture 24](images/cfae93ea02cfa82daa35c98052d8e14038ef1de439030cf933f981042f37fb32.png)  
Camera放在Player下方，Camera就会随着Player发生运动。  

3 . 方块移动的几种形式    
（形式1）直接移动  
![picture 25](images/8334fc7797a3f7d191f0150487e21e2fba61b935b7ab2ebd337ac594632e5a2b.png)  

（形式2）控制方块缓慢移动    
【这种代码可能移动不到40（一个格子的宽度）】
```js
import { _decorator, Component, EventMouse, Input, input, Node } from 'cc';
const { ccclass, property } = _decorator;

@ccclass('PlayerController')
export class PlayerController extends Component {

    private _startJump = false;
    private _jumpTime = 0.2;
    private _curJumpTime = 0;
    private _jumpSpeed = 0;

    start() {
        input.on(Input.EventType.MOUSE_DOWN,this.onMouseDown,this);
    }

    onMouseDown(event:EventMouse){
        if(event.getButton()==0){
            this.jumpByStep(1);
        }else if(event.getButton()==2){
            this.jumpByStep(2);
        }
        //event.getButton()==0代表鼠标左键，==1代表鼠标中键，==2代表鼠标右键
    }

    jumpByStep(step:number){
        this._startJump = true;
        this._curJumpTime = 0;
        this._jumpSpeed = step*40/this._jumpTime;  // v = S/t
    }

    protected onDestroy(): void {
        input.off(Input.EventType.MOUSE_DOWN,this.onMouseDown,this);
    }

    protected update(dt: number): void {
        //因为dt的时间不固定，所以有时不能移动40
        if(this._startJump){
            this._curJumpTime+=dt;
            if(this._curJumpTime>this._jumpTime){
                this._startJump = false;
            }else{
                const curPos = this.node.position;
                this.node.setPosition(curPos.x+this._jumpSpeed*dt, curPos.y, curPos.z);
            }
        }
    }
}
```

4 . 添加跳跃动画  
![picture 26](images/5ecd0e4eb1339ef5403e424331fbfbfa5f1bb9e20c8a71b21f159c7e2a78d9ea.png)  
![picture 27](images/c7447cb90fae9360488c6f85c3ee52fa69e6c71c6eb264faf07cff90e6b2f1d3.png)  
![picture 28](images/6f3e29e8ed7460d4f1751178d7861246f6412fe9f59c405d9ba0737895f96662.png)  

组件要引用cc后面的：  
![picture 29](images/99483aff1cbbdfcc3558194b32c1fe268a87af07d15dd5512cda39e78b2ea0c3.png)  

5 . 新建动画资源  
![picture 30](images/8cd8da38abeaeb95ce4bb06cde54b109c4fa542072d120cf9dd8af9b86371ae3.png)  

6 . slice代表九宫格  
![picture 31](images/48092084bcac8c207933a37d10549a69a67637346b875fe58ab05522c5e6ae31.png)  
![picture 32](images/fa7da5a222e731bd8a2e3553b9af8099f117db0b41aeb2c1ef5a6e45fb91d288.png)  

7 . widget控制锚点在左上角  
![picture 33](images/2fc7a0f1abc848a411680885faeb5083eb835509628db29c920c68a1bfebba60.png)  

8 . 因为有两个canvas两个camera。  
（1）游戏层  
![picture 34](images/19d06e122d50820914ac415d6356a5710be8d6487226cbc61d9edf606ee7dc60.png)  
![picture 35](images/8239ccd3333ec9ff8b685eaecd89a772ea3d2271707bacb1b2a7dbb73b46d95d.png)  
![picture 36](images/8d481495bc64daabc516299e5fe2f4aaa5f5b8255d423e6c483a7a53c7659cd2.png)  

（2）UI层  
![picture 37](images/854f09b73b9b4d835bd497d86995d04270e7de8455b04a045fd7e8a41f71ed25.png)  
![picture 38](images/5cbfe2d911efd5fae5cc63449dbaab8633c9f2710c0ad21cceb525a9c9e42365.png)  

cocos的layer属性两个相机的话，编辑器内的预览和浏览器的预览还不一样。  