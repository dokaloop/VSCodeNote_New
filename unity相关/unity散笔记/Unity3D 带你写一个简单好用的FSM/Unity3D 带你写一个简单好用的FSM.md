###  Unity3D 带你写一个简单好用的FSM
BV1uu4y1Z7wx  

#### 1 . 编写代码
编写FSMController和IState两个脚本   
[FSMController.cs](./FSMController.cs)  
[IState.cs](./IState.cs)
#### 2 . 导入
（1）导入github里的Anim文件夹   
![picture 1](images/e74c02972f8cc9d18ab0f95b7beb9929e404f4bd4e099e7b6d070a5987f06a34.png)  

（2）往3D项目里导入2D package  
![picture 0](images/37a8f6c513376f31483e751f43351b05dac6ef72728a37ee16dbacfbf787e5a9.png)  

（3）建一个2D的square，拉长它，并为它添加box collider 2d。作为底面。    
![picture 3](images/156fa91f5882ae8b08fb3c6a10df49bd1bac16b358d8cd4cb96df3af4a94c8ec.png)  

（4）建一个2D的square，改名Player，把这张图拽过来。并为其添加capsule collider 2d，rigidbody2D。  
![picture 4](images/a771aeb1b76347a84a94bc46f90e81d917c777fbaf8f898055f2e97d30c17bc6.png)  

（5）为Player添加Animator组件，把这个animator controller拽过去。  
![picture 5](images/58cdf79ccdc3239000d4e0bdf4a1a9fae3db510aee08e9521a953d83bf500e54.png)  

(6) 为Player添加FSM controler脚本并且修改默认state。  
![picture 6](images/76bdcc3f75b086c16087f470af14939a7451a6aad53c600d9b06780b0d92a947.png)  

#### 3 . 继续编写脚本
（1）在Assets文件夹底下创建States文件夹，并且再底下新建IdleState脚本。  

但是我们发现，我们创建的state没法访问我们的状态机，难以与monobehaviour产生交互，所以我们在接口中定义machine属性，在AbstractState中给出实现。   
![picture 7](images/6cc68f6c3d954a5242f50b03f78fab781cf816dc12b267cb86f99513b85999a6.png)  


接着我们在FSMController中在状态初始化的时候，为每个状态绑定状态机。  
![picture 8](images/260130296fd0a5630232bd04acf43d1d173dfdb885ed6ae00a19425db8ab2ac3.png)  

（2）接着我们再创建一个RunState。  

（3）为了控制角色移动我们创建Params脚本

（4）//接下来我们需要状态切换，我们定义脚本PlayerInput，我们首先获取状态机组件。
//如果水平轴的偏移量非常小，我们就当它没有按下

（5）为Player添加rigidbody2d组件，锁住z轴旋转  
![picture 9](images/ebfb0f6477acbf9bec6dca73807ae16752fddff6e4d31306dd49799364935eca.png)  
为Player添加PlayerInput脚本。

#### 4 . 鸦鸦阅读代码 
![picture 10](images/d6d03008b145697ade90573d7ba4ee6533aa8115c6da87116758b19370ddab89.png)  
![picture 11](images/bd412e7b76be6e14c17735c6b035bdd1e9ba66af8c9ac397d06ef1a0af2532cb.png)  
AbstaractState是基类，里面嘛也没写。里面有属性Machine，所以IdleState和RunState能访问FSMContoller里的animator和rigidbody2D。

因为FSMController是monobehaviour，所以Update函数和FixedUpdate函数不用其他地方调用直接会运行的。

FSMController里的Enter函数和Exit函数在PlayerInput调用。  
PlayerInput（Enter）--> FSMController（Enter）-->IdleState（Enter）

FSMController里虽然调用了AbstractState的OnDestroy函数，但是其实IdleState和RunState里没有实现，而且其他地方没有调用FSMController里的OnDestroy，感觉在这个项目里没啥用。