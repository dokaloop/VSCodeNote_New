#! https://zhuanlan.zhihu.com/p/649288262
# 第一课 从配置安装到画第一个三角形（笔记）

## 课程前置条件
### 1. 课件与代码
课件：https://github.com/parallel101/openglslides
<br/>案例代码：
<br/>（1）github: https://github.com/parallel101/opengltutor
<br/>（2）gitee: https://gitee.com/archibate/opengltutor

### 2. 课程软件要求
编译源码所需软件:
<br/>（1）编译器：MSVC>=19 或 GCC>=9 或 Clang>=11（支持C艹17即可）
<br/>（2）构建系统：CMake>=3.10<br/>
（3）编辑器：推荐Visual Studio 2022

小彭老师所用软件：    
（1）编译器：GCC 12.2.1  
（2）构建系统：CMake 3.26  

## Chp1. 什么是渲染  
### 1 . 计算机图形学  
![](https://pic4.zhimg.com/80/v2-33e4418875938d8880587c30fdcd58b6.png) 
### 2 . 什么是渲染  
![](https://pic4.zhimg.com/80/v2-ad8e2e61f86aa4a911dc8d23e08dab05.png)
### 3 . 一切皆三角形  
所有的复杂图形，都可以由三角形构成。
![](https://pic4.zhimg.com/80/v2-20b9eb5564fe5f6f1dfea93285580433.png)
圆形：也可以拆分成很多个三角形来表示，只要我拆分的足够细，甚至比像素还细，你就会误以为这是真的圆形，而不是三角形拼接而成的n边形。
![](https://pic4.zhimg.com/80/v2-e1c25997f9dea0d140c175047ce9df20.png)
(上图布线不太好，细分会出各种问题)  
包括PPT软件，也是很多三角形在那里。  
*（思考：为什么要用三角形呢？三角形有什么优势？）*
![](https://pic4.zhimg.com/80/v2-8499dfa3544b22d9a3de46801419b1d3.png)
（上图为blender里，三角形切的有讲究，切的每个角度尽可能接近60度）    
### 4 . 计算机图形学：画皮        
如果一个东西看不见，那我们不妨认为它不存在，我们只在乎物体看得见的表面。
![](https://pic4.zhimg.com/80/v2-f50909f768738d8c81fd1b8e81694fe0.png)  
看到有同学说：看不到的地方都不用画，实际上是一个半圆。  
**三维图形也可以由一堆三角形拼凑而成**  
（1）物体的表面可能是一个任意曲面，用刚刚无数三角形逼近圆形的思想，我们也可以用三角形表示任意物体的表面。  
*[关于三角形，老师从二维的正方形讲到任意三维物体的表面]*  
（2）总之我们发现，只要善用图形学的至理名言：三角形，可以表示任意三维图形。  
（3）这就是为什么，只有薄薄表面的一大堆三角形，会被我们称为模型（model）了。  
（4）在物理仿真和烟雾渲染等领域我们需要关心物体的内部，但是至少实时渲染这边不需要！我只看到一张皮就满足了！

### 5 . 高模VS低模  
（1）当然，为了保证高质量，需要三角形足够密集，让人看不出多边形拼凑出来的，让人信以为这是一条光滑的曲面。因此有了高模和低模的区分。  
（2）一般建模师都会先在低模上进行操作，完成后在通过网格细分算法（subdivision）把低模自动转换为光滑的高模，然后由雕刻师在高模上完成细节刻画。
![](https://pic4.zhimg.com/80/v2-f3b77eae5bacb3354b5dc44eb3bc73e2.png)  
高模仔细看是有一个个正方形的，渲染的时候会转成两个三角形  
![](https://pic4.zhimg.com/80/v2-2b83e19045e12b0d79f513742bb24a95.png)
![](https://pic4.zhimg.com/80/v2-e8eebd347d8be682de6931e5371f352c.png)
### 6 . 如何用一系列坐标表示一个方块：顶点坐标+顶点之间的联系  
**obj文件中v、vt、vn、f这四个参数的含义**  
https://blog.csdn.net/xiongzai2016/article/details/108052800  
>![](https://pic4.zhimg.com/80/v2-e48b449d07791a1675d6dce316cb1890.png)
![该obj得到的模型](https://pic4.zhimg.com/80/v2-b3f18eac08088e17ff1b87bebd26b34a.png)<br/>
**现在来解释各参数的含义：**  
**v**: 表示顶点，即组成图的点，如立方体有8个顶点，每个顶点有x,y,z三个值。  
**vt**: 纹理坐标，其值为u, v。纹理应该是指某个面的粗糙程度(我暂且没看出这个变化)，那纹理为什么有坐标呢？想象一块可以自由拉伸的布，坐标表示这个布的一角要放在这个位置，这就是纹理坐标。我们知道一个面最少由三个顶点才能构成，如果此时将一块布拉伸到这三个顶点上，则这块布会变成一个三角形。  
**vn**：顶点法向量，其值为x,y,z，你可能好奇为什么顶点有法向量，其实这个法向量是表示顶点的朝向。如果有三个顶点组成一个面，面是有两个朝向，向里或向外，所以可以通过顶点的朝向来确定面的朝向。而且这三个顶点的法向量是一样的。  
**f**：表示一个面，由三个v/vt/vn的索引形式组成。比如obj文件中f 5/15/7&emsp;&emsp;4/14/6&emsp;&emsp;6/16/8 ，表示由第5、第4、第6这三个顶点组成了一个三角平面,平面的纹理由第15、第14、第16这三个纹理坐标形成，这个平面的朝向是第7、第6、第8这三个顶点的法向量求平均值。 

![](https://pic4.zhimg.com/80/v2-01bb059e6d7222c634224f5462d6f56a.png)  
opengl有个深度过滤系统，后面的会被覆盖掉。   
对于图片上的疑惑，
小彭老师：因为obj中不仅允许三角形，还允许四边形或任意多边形。
f后面可以跟n个数代表n边形面。不过进入渲染以后我们都需要转换成三角形才能用。

**渲染的本质**  
输入是顶点，输出是字符画。   
**图片表示**  
不同地方亮度不一样，感觉出立体感了。亮度的计算有公式，按照这个公式来，这个公式和现实物理几乎一模一样，起到以假乱真的效果。

### 7 . 人们对渲染的错误理解  
&emsp;&emsp;渲染并不是给灰色的模型“上色”，模型本身不存在灰色不灰色，灰色的是显示在屏幕上的模型的二维投影，真正的模型是内存中的一堆三维顶点坐标，渲染是把这一堆三维坐标根据指定的视角、灯光、材质等信息，投影成二维图像，即使你指定的材质刚好是灰色的。  
&emsp;&emsp;你在 Blender 建模窗口里看到的，之所以是灰模，不是因为没有渲染，而是因为他为了让你能为了让你能快速预览模型的大致形状而不用风扇狂转，采用了**最低配的渲染模式**。
![](https://pic4.zhimg.com/80/v2-bf837213b49b42b745fb3cb987cda893.png)
### 8 . 实时渲染VS离线渲染  
![](https://pic4.zhimg.com/80/v2-f39ba5d6880d9914b760d1be73441786.png)  
**离线渲染-康奈尔箱**  
+ 离线渲染几乎不在乎时间，它们采用路径追踪（path tracing）和蒙特卡罗积分来求解渲染方程，得到与实际照片无异的结果，因此又称为“照片级”渲染。
+ 路径追踪的原理是，在每一个像素点上反射一条光线，然后检测它和场景物体的碰撞，如果发生碰撞，则计算反射后的出射方向，继续追踪这条方向的光线，直到光线被物体完全吸收或超出迭代次数限制为止。
+ 由于图形学中的模型大多是三角形网格，因此路径追踪本质上是射线（光线）与大量三角形（模型）求交。
+ 但这种算法也有它的限制。由于路径追踪需要追踪每个光线与物体表面的交点，因此对于复杂场景或高明度的光源，需要的计算量会非常庞大，渲染时间也会变得非常长。此外，由于路径追踪使用蒙特卡洛积分法，具有随机性，存在噪点的问题，需要堆砌大量采样次数才能使其收敛，指数级地加大了计算成本。  
![](https://pic4.zhimg.com/80/v2-1740cfb322657f5232f769fc6fce3380.png) 
相传迪士尼的《疯狂动物城》，需要10000个“核时”才能渲染出一帧。什么概念呢？就是说单核心CPU，需要工作10000小时，才能渲染出你看到的一帧，如果是100核CPU则只要100小时就能出一帧。而电影一般每秒有24帧，考虑到整部电影有一小时多……

**第二条路-光栅化**  
![](https://pic4.zhimg.com/80/v2-3f21f2c88c54ede76a28b69c7ac900ef.png)拆成一个一个三角形，一个个去绘制这些三角形。  
光栅化是一个可以并行的算法，可以在CPU上编写软件代码实现，但效率较低。考虑到光栅化是绘制图形最高效的算法。人们发明了GPU，把光栅化做成硬件电路，不必软件编程，软件只需要向GPU发出指令，就可以调用GPU的光栅化电路，并绘制图像。  
![](https://pic4.zhimg.com/80/v2-5fc7f4d68a8079298e78f2e4c8359597.png)
*鸦鸦问：这个像素的中心点（橘色的点）不在绿色的三角形内，为什么右边的三角形画了那个点？*  
*小彭老师答：说明小彭老师的网图有问题，下面两块应该是没有的。网图的作者似乎理解成“只要有一点点覆盖到”就绿。实际上opengl为了防止多个相邻三角形绘制时产生冲突，判定是非常严格的。  
鸦鸦问：什么叫多个相邻三角形绘制时产生冲突？  
小彭老师答：**比如左下始终是小于等于，右上始终是大于**，唯恐出现边界情况。就是说三角形的边刚刚好卡在中心点上，那么opengl会认为他归属于左下的那一侧，右上侧如果有相邻三角形就不会负责这个点的绘制。*  
（鸦鸦想：加粗的这句话还不太明白，以后学到那估计就懂了。）  

**着色：使物体明暗分明**  
+ 如果只是光栅化，那么我们看到的图形就都是黑白的二值图像，根本不会有立体感。
+ 为了让图形看起来立体，真实，我们需要像离线渲染的路径追踪一样，计算物体的光照情况，给不同的位置上不同的颜色这个操作称为着色（shade）。
+ 确定这个点要绘制后，就会调用所谓的着色器（shader）。着色器会根据三角形每一个像素点的位置，结合物体材质反射率、颜色、该点三维坐标与光源、摄像机的角度位置关系等信息，在相应的像素点填充上符合光学规律的颜色，区分出亮部暗部，让它看起来立体。
![](https://pic4.zhimg.com/80/v2-0addef1153313f8e5e0462af989a2704.png)  

光栅化这东西虽然已经很快了，但你用CPU去循环填充的话，还是来不及在1/60s内，只要不能在1/60s内完成，游戏玩家都是没法玩的，这个阶梯我们要爬上去，这个梯子就叫GPU。CPU控制模块比较多，擅长处理分支判断（if-else），GPU数学模块比较多，flops（每秒浮点运算次数）比较高，擅长sin（x），1+1=2这种计算。*（以后查：啥叫控制模块）*

### 9 . GPU为实时渲染而生
![](https://pic4.zhimg.com/80/v2-d36e97c4af85d90788f532cbba3f82a0.png)
随着GPU的更新换代，GPU也在更新换代，OpenGL2.0不同材质，反射率曲线可以自己指定。4.0之后更厉害了，不只能做图形渲染了，任何线性数据它都能处理，就出现了“挖矿”。可以自定义材质，材质自定义可以定义一个计算函数，计算函数放一个挖矿函数，GPU就涨价了。    
**从 GPU 到 GPGPU** 
+ 后来，着色器能够并行运算的特点被发掘，用于图形渲染以外的通用并行计算工具，后来【OpenGL 4.3】 也推出了更适合通用计算任务的“计算着色器（compute shader）”，这种着色器的语法限制更加宽松，首次加入了对 block 和 thread 的控制能力，用途上显然早已和“着色”没什么关联了，只有并行的优点被保留，GPU 逐渐演变成通用的并行计算硬件。
+ GPU 强大的并行运算能力和延迟隐藏能力，对于需要同时处理大量数据的应用场景，比如物理仿真、音视频处理和人工智能等，GPU 也能发挥更强大的计算能力，大幅提高吞吐量。
+ 这种具备通用并行计算能力的 GPU 也被称作 GPGPU（General Purposed GPU）。


### 10 . 实时渲染-质量堪忧   
![](https://pic4.zhimg.com/80/v2-a4c8c661982832c09ba440ce21218f24.png)  
离线渲染中，真实照片和离线渲染的jpg图像是像素级相似，真假难辨。   
![](https://pic4.zhimg.com/80/v2-85e7102dfbefc54d2ab1af19c5df9d14.png)     
硬件加速的光栅化虽然高效，但由于光栅化只能计算光线的***第一次***反射，实时渲染在全局光照方面令人堪忧，为了实时性不得不牺牲了渲染结果的准确性。    

**实时渲染的进步**  
![](https://pic4.zhimg.com/80/v2-08a186bb8aeb45c61bba8c398e6930ef.png)  
图中对整体效果最明显的是屏幕空间反射技术（SSR），他在已经渲染完毕的二维的屏幕空间进行光线追踪，成本更低，但也能达到类似全局光照的效果。   

**GPU也开始支持光线追踪**  
![](https://pic4.zhimg.com/80/v2-80d977c2ce4a629d91498d54519182b3.png)  
+ 就像当年光栅化差一点就能实时了，NVIDIA 发明 GPU 用硬件加速光栅化一样，他们现在又发明了硬件加速的光线追踪，同样集成到了 GPU 里，于是现在的淫威大 GPU 由光线追踪+光栅化+流处理器三个模块组成，后来还引入了伺候 DLSS 和 AI 降噪的张量计算模块。
+ 要注意并不是说 RTX 等于光追，RTX 只是“硬件加速”的光追。正如硬件加速的光栅化一样。我们用 OpenGL 计算着色器，CUDA，OpenCL，一样可以在任何没有硬件光线追踪功能的 GPU 上进行**软件光线追踪**，只不过会比较慢，难以达到实时而已。
+ 虽然硬件光追只加速了 2.4 倍左右，但是由于实时渲染的特殊性，同等画质下提升 2.4 倍速度，就等于同等 1/60 秒的情况下提升了 2.4 倍画质，帧率不降提升画质，是质的飞跃，这也是为什么在实时领域硬件加速（不论是光栅化还是光线追踪）都显得格外重要。

![](https://pic4.zhimg.com/80/v2-1eea2947324a9eae7aac90a0481c0119.png)  
上图是CPU,CUDA本来还要...的意思。
![](https://pic4.zhimg.com/80/v2-bca23a68c1d0bb29be6e1d8ccf09026a.png)
**GPU 渲染一个物体所需的全部流程一览**   
![](https://pic4.zhimg.com/80/v2-ad75bf933eca79aaff43f3d61581a8a3.png)  
顶点信息粉红强力一点的那一端x值大一些。屏幕空间特效有反光。    
**题外话：GPU 也可以渲染二维图形**  
GPU（图形处理器）在渲染三维图形方面几乎是不可替代的，但是它们也可以用于渲染二维图形（包括文字和图标），例如我们平时看到的图形用户界面（GUI）、浏览器（Web）等，都有 GPU 的功劳。GPU 的渲染能力非常高，它可以同时渲染许多图形，还可以使图像处理速度（例如拍照后加美颜滤镜）更快。GPU 可以处理的图形元素包括点、线、矩形、多边形、文本等。它还可以使用多种不同的技术和效果，如图形加速、抗锯齿和透明度，以提高图形界面的质量和性能。所以，GPU的用途不仅限于游戏和 3D 应用程序，它们也可以帮助我们更快更好地渲染的图形用户界面。包括 2D 平面游戏的精灵（Sprite）绘制，也离不开 GPU 忙碌的身影。
## Chp2. 初识OpenGL  
### 1 . 什么是OpenGL  
你可以C++自己写一个软光栅，这样不仅低效，还要重复劳动，要写很多代码。有OpenGL这个工具，又高效又不用写很多光栅化代码。  
EasyX是在DOS状态下工作，画三角形软光栅实现。（不一定是实时的，分辨率还低,e.g.480p）
![](https://pic4.zhimg.com/80/v2-b6137696e87905342292bf5a3e750583.png)
![](https://pic4.zhimg.com/80/v2-b67fac103ef5c895301b18be9ab3724d.png)    
### 2 . OpenGL 的版本与驱动支持  
+ 就和 C++ 语言一样，OpenGL 的 API 是有许多版本的，每个版本 API 的制定，是由一个名叫 Khronos 的组织发布的。和 C++ 的 ISOCpp 一个尿性，他们只负责制定 API，不负责实现，由各大硬件厂商的驱动来实现。
+ API 版本每年更新个一两次，硬件厂商看到了，就会更新他们的驱动版本，在新驱动中支持开始新版本的 API。
+ 不能使用最新版本的 API，有时是受制于软件（驱动）版本，有时受制于硬件（显卡）架构。如果我们同学没有最新的硬件，至少可以先更新驱动。
+ 新驱动不仅更新了 API 版本，支持了新特性，还可能优化了性能。
+ 例如小彭老师尽管显卡不是最新，却经常更新驱动，现在能够用上最新的 OpenGL 4.6。
+ 如果你不确定自己的驱动是不是最新的，作为参照，小彭老师现在的 NVIDIA 驱动版本是   530.41.03。
+ 驱动越新，支持的OpenGL版本越高。   
  显卡越新，支持的OpenGL版本越高。   
  能够支持的OpenGL版本 = min（驱动支持的版本,显卡支持的版本）

解释：ISOCpp规定比如16<int<64（必须有符号），具体int是多少个bit呢，硬件厂商或者说编译器厂商自己去决定。当然它们都比较仁慈GCC MSVC 认为int是32位。不仁慈的情况，long和intptr_t在linux是32还是64位取决于平台是多少位。微软上long总是32位的。
比如OpenGL官方说超过ssbo数量4就可以了，不一定要正好为4，淫威大说我们支持10000个，按摩店说我们支持100个，intel说我们这个集成显卡比较菜支持4个吧，这时候一个程序来了，程序员用淫威大显卡，一下申请了1000个ssbo，他在他自己电脑上跑没问题，同事的电脑用按摩店，报错了，给他改成90个。另一个人用intel跑崩溃了。因为官方只要有4个就够，这就是通用标准的坏处。——OpenGL的尿性，建议都用比较新的显卡。    

### 3 . OpenGL 的版本与驱动支持
你可以在 Khronos，KHR，或者说可汗，的官方网站查看不同版本 gl 函数的 API 文档：
https://registry.khronos.org/OpenGL-Refpages/gl4/html/glRenderbufferStorage.xhtml
### 4 . OpenGL 版本历史变迁
![](https://pic4.zhimg.com/80/v2-9f7d6d0a2ebb63711587d0b02ed82dea.png)  
***鸦鸦**：小彭老师，课上讲的这里，breaking change 的 fun 变成 bar，参数类型必须变么？假如原来是int现在还是int可以么？  
**小彭老师**：foo(int)变成foo(int,int)是breaking。   
foo(int)变成bar(int)是breaking。   
函数名字改变，函数参数类型改变，函数参数新增且新参数没有用cpp=语法指定默认值都是breaking。   
**鸦鸦**：foo(int)变成bar(float)和
foo(int)变成bar(float, float)也是breaking对吧     
**小彭老师**：嗯（表情包）    
语义版本号是 major.minor.patch    
**鸦鸦**：那fun_EX不是也变了名字么？为什么不是breaking，不就是这个么？   
**小彭老师**：变了，但是保留原有的函数。breaking说的是我引入了bar然后把foo删了。如果我只引入bar，但是不删除foo，那也不是breaking。foo(int)变成foo(int,int)本质上也是删了foo(int)加了个新的。*   
***鸦鸦**：谢谢小彭老师。*

### 5 . GLSL版本与OpenGL版本对照
![](https://pic4.zhimg.com/80/v2-6b0811dc5839e2f14f22406ebc2322ca.png)  
*GLSL是一个独立的版本，OpenGL1.0是固定管线不需要着色器，2.0才开始出现着色器语言。*    
OpenGL 2.0 的可编程管线，为了可编程，引入了着色器
其中片段着色器（fragment shader）允许用户自定义的每个像素的颜色计算公式（故得名着色器），这个公式后来被人们称作 BRDF；而顶点着色器（vertex shader）允许用户自定义的每个顶点的矩阵投影方式，修改顶点属性等
比如我们课程是 OpenGL 3.3（***现代版本***），对应的 GLSL 是 3.30，因此在着色器里写 #version 330
今天先不用担心着色器，只需要知道他存在就行了，我们下节课才正式开始介绍着色器。  

**古代OpenGL**
+ OpenGL 的接口（API）是有许多版本的。
+ OpenGL 2.0 及以前的版本，称之为古代 OpenGL，例如：
```C++
glBegin(GL_POINTS);
glVertex3f(0.0f, 0.5f, 0.0f);
glVertex3f(0.5f, 0.0f, 0.0f);
glEnd();
```
![](https://pic4.zhimg.com/80/v2-95b0ed3d6ea95c3dc6b2e958d6da2a93.png)
+ 由于我们是一个一个函数调用来传入顶点的坐标，颜色等信息，这种模式下的 OpenGL 又被称为立即模式（intermediate mode），**立即模式**是古代 OpenGL 特有的，效率较低，且灵活性差，难以自定义新的属性。
+ glMatrixMode、glPushMatrix 和 glOrtho 等函数也是立即模式的 API 之一，如果你在一个 OpenGL 教程中看到这样的函数，那么他就是古代的教程。

**现代 OpenGL**
+ OpenGL 的接口（API）是有许多版本的。
+ OpenGL 3.0 及以后的版本，称之为现代 OpenGL，例如：
```C++
glGenVertexArrays(1, &vao);
glBindVertexArrays(vao);
```
+ 特点是有非常多的各种 VAO，VBO，FBO，各种对象及其绑定（bind）操作。
+ 初学者可能对此心生畏惧，不要担心，在小彭老师的答辩比喻法介绍下，没有什么花里胡哨概念是难理解的，他会告诉你哪些是需要注意的，哪些是次要的，帮你拎出重点，排除掉亿些不重要的干扰项，熟练使用 C++ RAII 思想封装，了却 OpenGL 状态机模型的痛苦。

### 6 . OpenGL 实现与不同的 API
![](https://pic4.zhimg.com/80/v2-588861c1ec3d5d58638d3a4d992f0cca.png)
PPT中“不负优化了OpenGL”断句是“不/负优化了OpenGL”，我想成了“不负/优化了OpenGL”。
负优化=阉割，不负优化=不阉割。
### 7 . OpenGL 扩展    
+ OpenGL 提供的函数都是通用的，几乎每个正经的 GPU 都支持的功能。
+ 而有时，硬件厂商不满足于只提供大锅菜，还会开小灶，这就是 OpenGL 扩展，扩展官方提供的一种添加额外 API 的手段，用户可以检测当前 OpenGL 实现是否具有某扩展，如果有，则可以使用这些函数，如果没有，则必须想办法绕道（walk around），用比较低效的通用 API 实现那个只有 NVIDIA 显卡才具有的扩展，或者宣布放弃支持非 NVIDIA 显卡。
+ 例如这是一个 NVIDIA 从 Turing 架构开始支持的一个 OpenGL 扩展，扩展的名字格式如下：
GL_NV_compute_shader_derivatives
+ Khronos 官方有一个页面来维护这些扩展的描述文档：
https://registry.khronos.org/OpenGL/extensions/NV/NV_compute_shader_derivatives.txt
+ 这些扩展需要驱动和硬件本身的支持，老的显卡不一定具有，往往只有特定品牌，足够高型号的显卡才具有，为了照顾没有最新显卡的同学，小彭老师在实验源码中完全不使用扩展，如果要使用，则也会加入分支检测不到扩展时的“绕道”方案。
### 8 . Windows安装OpenGL    
+ 安装 DirectX 运行时的同时会安装 OpenGL 驱动，只要安装了 DirectX 就安装了 OpenGL。
+ 会在 C:\Windows\System32 中出现一个 opengl32.dll，这个就是 OpenGL 运行时，程序启动后会调用 LoadLibrary(“opengl32.dll”) 加载这个文件，并用 GetProcAddress 加载其中的 gl 函数。该 dll 文件只是运行时库，光这个文件没用，需要同时具有物理显卡驱动才能运行。
![](https://pic4.zhimg.com/80/v2-cb59e8a0448b301b56830e69ddbe9c0b.png)    
dll是动态链接库。这个库调用显卡驱动。  
**安装显卡驱动**     
不过如果你玩游戏的话，通常来说 OpenGL 驱动早已经在你的电脑里了，这个东西一般是和 Direct3D 一起安装的，用 dxdiag 或 CPU-Z 工具也可以检测到 OpenGL 安装的版本。
（我用dxdiag和CPU-Z都没看到OpenGL版本，后来下了opengl extensions viewer才看到opengl的版本）
![](https://pic4.zhimg.com/80/v2-0a8c3bf906282ed06a54c4b8447403ba.png)
### 9 . OpenGL头文件
+ 古代 OpenGL 往往用这个系统自带的头文件：      
#include <GL/gl.h>
+ 这里面包含的都是些 OpenGL 2.0 以前版本的老函数，而不具有现代 OpenGL 3.0 以上的新函数，如果我们想要用现代 OpenGL，就不能用这个头文件。
+ 现代 OpenGL 没有头文件，而是必须使用 LoadLibraryA 手动去 OpenGL 的 DLL 里一个个加载那些函数，如果我们每用一个函数就得手动加载一下函数，那该有多痛苦啊！
+ 因此，有了 glad 和 glew 这样的第三方库，他们会在启动时加载所有的 OpenGL 函数，放到全局函数指针中去，这样当你使用时，就好像在调用一个普通的函数一样，没有痛苦。
+ 因此为了现代 OpenGL，我们必须选择一个 API 加载器，本课程选用了 glad，当你需要 OpenGL 函数时，不是去导入那个落伍的 <GL/gl.h>，而是导入 <glad/glad.h> 作为代替：       
#include <glad/glad.h>

*课上补充：glad和glew选一个，我们选glad，因为它的定制性比较高，它的作用是帮你加载opengl32.dll。调用函数指针，指向opengl32.dll，它是一个加载器。以前为什么用头文件，以前opengl函数比较少，而且不经常变化，所以可以用头文件，固定就几个函数。3.0进行了大更新，加了一堆函数，这时候头文件效率就比较低了，还不如搞个api加载器，方便它更新版本。用了加载器就不要导入老的头文件啦。*

**glad 坑点注意**
+ 此外还要记住 glad 头文件必须在其他 gl 相关库的前面，虽说 C++ Guidelines 都要求头文件的顺序理应不影响结果，但毕竟 glad 是个特殊玩意，还是得照顾他一下的。
+ 例如 glad 必须放在 glfw 头文件的前面：      
#include <glad/glad.h>       
#include <GLFW/glfw3.h>      
+ 建议自己的 glcommon.h 头文件里写这两行，然后用 gl 和 glfw 就导入这个 glcommon.h，这样就能保证顺序不乱。如果用到其他的 gl 相关库也可以往 glcommon.h 里追加。

*课上补充：因为glfw也要用到opengl函数，它如果发现没有gl函数的话，它就会自己去导入一遍“#include<GL/gl.h>”。
建议可以搞个自定义的头文件glcommon.h 。*

![这页没太看懂（时间节点：1:38:18）老师提醒：文件结构树](https://pic4.zhimg.com/80/v2-ea60f8acc1cd55f129985d9c1add456a.png)
*兼容模式，就是2.0的函数你还能用，core模式只有3.0以后的函数你才能用。*

**glfw - 跨平台的 OpenGL 窗体管理库**
+ https://github.com/glfw/glfw
+ GLFW 是配合 OpenGL 使用的轻量级工具程序库，缩写自 Graphics Library Framework（图形库框架）。GLFW 的主要功能是创建并管理窗口和 OpenGL 上下文，同时还提供了处理手柄、键盘、鼠标输入的功能。
+ 注：他实际上也支持创建 OpenGL ES 和 Vulkan 上下文。

**glm - 仿 glsl 语法的数学矢量库**
+ https://github.com/g-truc/glm
+ glm 和 glsl 的语法如出一辙，学会了 glsl 等于学会了 glm，反之亦然。
+ 选择这款最接近 glsl 语法的矢量库将会大大节省我们的重复学习成本。
+ 此外，glm 还支持 SIMD，支持 CUDA，虽然本课程用不到。

## Chp3. 配置开发环境
唯一需要提示的，其他去看ppt吧> <
![](https://pic4.zhimg.com/80/v2-227b36f1d0be8848af5d0da0abaed08d.png)

如果出现这个错误，请安装显卡驱动！
![](https://pic4.zhimg.com/80/v2-94ab45b8a42e9d5a7d42f09e84f79e85.png)
*为什么这个错误小彭老师要写英文：因为MSVC有个特点，你在字符串里写中文他就开始报错了，因为MSVC默认是GBK模式，不是跨平台的utf-8格式，又不敢写GBK格式，Linux用户和Maike OS用户又不高兴了，所以只敢写英文。*       
***鸦鸦**：老师我在听课的时候遇到这一段。请问没有用默认的gbk模式，那用的是什么模式？      
**小彭老师**：msvc默认gbk模式，gcc默认utf8模式。gbk和utf8的交集是ascii。其他字符，包括中文，在gbk和utf8中对应的二进制表示不同。     
**鸦鸦**：哦哦哦哦！！！所以小彭老师写英文是为了ascii？     
**小彭老师**：嗯（表情包）    
英文字母全部是ascii。*    

## Chp4. OpenGL 样板代码
### 1. 我们的第一个 OpenGL 程序 - 从初始化 GLFW 开始
在开始画图之前，需要先初始化 GLFW 这个库。     

```C++
glfwInit();  // 初始化 GLFW 库
```     
**加上错误处理这个次要干扰项**
```C++
    if (!glfwInit()) {
        throw std::runtime_error("failed to initialize GLFW");
    }
```
+ 诸如 glfwInit 这样的 C 语言函数都约定，返回非 0 值表示出错，如果我们不去判断他的返回值，那么一旦出错将不会有任何提示，继续执行后面的代码！不好意思，gl 家族都是纯 C 语言的函数，他们没有办法使用 C++ 的异常，而出了一个小错就直接把整个进程 exit(-1) 掉又过于武断，所以只好用返回值告诉调用者“我是不是出错了，出了什么错”的信息。
+ 本课程使用 C++ 编程，为了在这种传统的 C 语言风格错误处理和 C++ 方便调试的异常之间转换，我们需要检测每一个 gl 家族的 C 语言函数返回值，检测到出错时，就立刻抛出 C++ 异常。而一般的调试器或 IDE 都会在抛出异常时断点，大大方便了我们调试！
### 2.使用 GLFW 创建一个窗口
```C++
auto window = glfwCreateWindow(640, 480, "Example");
```
+ 创建一个宽 640 像素，长 480 像素，标题为“Example”的窗口。
+ 创建完窗口后，我们就要在其上绘制图案了。如何让 gl 函数知道我们要在哪一个窗口上画图呢？OpenGL 有一个概念叫做上下文，大致意思是：        
你让我画一个方块，但是在哪里画呢？你得先告诉我一个上下文语境啊！
+ 要把刚刚创建的窗口设为接下来 gl 函数的上下文。
```C++
glfwMakeContextCurrent(window); //设置当前窗口
```
**加入一些无关紧要的干扰项后**
```C++
    GLFWwindow *window = glfwCreateWindow(640, 480, "Example", NULL, NULL);
    if (!window) { //这个函数失败会返回一个NULL
        glfwTerminate();
        throw std::runtime_error("GLFW failed to create window");
    }
    glfwMakeContextCurrent(window);
```
+ 这就是我说的“排除干扰项”教学法，gl 的很多函数都非常复杂，但大多都是次要的。
+ 教育学生时，如果直接给他们看完全严谨的最终代码，他们都会看不懂，奔溃。
+ 而如果把代码中真正关键的部分提取出来，以伪代码的形式给他们看，理解后，再看加上了错误处理，状态保存与设置等次要的工作，他们就会明白，哦，刚才我理解了顶层设计，现在我再来看看都新增了哪些具体细节，例如错误处理等。先把握大局，后落实具体。
+ 你可以把上下文想象成一个全局变量。而 glfwMakeContextCurrent 则是会初始化那个变量，使其中的“屏幕”指针指向你创建的窗口 window。
+ 当你调用 gl 函数时，这个函数会去读取这个全局的“单例”，并修改其中的状态。

*glfwCreateWindow(640, 480, "Example", NULL, NULL);    
这句有两个null是因为c语言特产lpReserved。你学过windows的话，它会搞一堆很长的参数。C语言没有重载，也没有默认值，它只能以NULL的形式传进去告诉它我不需要这个参数。*

**小彭老师**：lpReserved。这是一个金典wendous孝话。如果以前写过wendous编程会get到孝点。就是说wendousapi会预留很多额外的参数。       
**鸦鸦**：看成sapi了。     
**小彭老师**：CreateWindow(const char *szName, void *lpReserved)     
然后说第二个参数保留作以后使用，目前必须为null。    
**鸦鸦**：预留额外的参数有什么好处？    
**小彭老师**：这样以后他们拍脑袋加个新功能。比如本来只能指定个标题szName。现在他们还允许指定字体了。   
这样老的程序用的是CreateWindow(“title”，null)则使用默认字体。    
知道api更新过的新程序用的是CreateWindow(“title”，“sans”)则使用衫斯字体。    
这样就不需要breakingchange导致老代码不兼容了。      
所以wendousapi的设计原则是：理论上永不breaking-change。这样即使在win98时代的程序也能在wen11上运行。当然现在一帮小年轻，小浮躁狗进来以后，喜欢一天天breaking-change。     
之所以吐槽这个是因为有时候一直到最后这个保留参数都没有用上。反而是写代码麻烦了，要一直写一堆null和0。当然思想是好的。    

然后为什么要参数名字叫lpReserved呢？这个是微软推崇的“匈牙利命名法”。远古C语言，没有类型检测，是没有办法分类型的。可以把void*直接赋值给int变量，非常危险。为了伺候老年C语言，微软提出我们在变量名里前面写上，例如 int iSize   
这样用的时候一写iSize就知道它是int类型，不是short类型。    
int *piSize就知道这是指向真正size变量的指针。   

为什么有p了还搞个lp呢？因为以前16位实模式的dos操作系统。指针分为两种，near指针16位用p表示，far指针20位用lp表示，然而i386发布wendous进入32位保护模式时代后，就没有far near之分了。理论上已经不需要lp。早就没有far near了，c编译器也早就能区分清类型了，但由于ms老头程序员历史习惯才保留了lp。所以现在请不要使用匈牙利命名法卖弄情怀。

顺便一提，cpp的allocator一开始也是为了伺候far near指针的。后来32位时代开始没落，现在才逐渐发展成实用的pmr。    
就是说cpp和dos其实是同时代的。c标准时间上都没有规定int类型的大小。int完全可以是16位的，当然现在32位和64位系统上int已经是32位了。真正在c语言标准中保证是32位的写法，是int32_t。int64_t，而不是long，long在wendous上就是32位，64位linux就是64位，32位linux又是32位，非常搞。int64_t和uint64_t才是标准的。如果需要随硬件64/32变化的int类型，则可以用intptr_t和uintptr_t，32位上等价于int32_t, 64位上等于则变成int64_t。

**鸦鸦**：哦哦哦哦…glfw可以在其他操作系统上用，那么其他操作系统应该没有windows这个保留老婆。其他操作系统会有这个null ，null么。

**小彭老师**：
linuxapi主打一个简洁，没有这么多reserved。linux也没有匈牙利命名法。不过现在新出的一些api也开始复杂化，比如clone，说是比fork＋exec睾效。我是没兴趣去用，都用qt或boost封装好的跨平台接口。  
**鸦鸦**：老师是不是在linux中编写opengl代码，是没有这两个参数的。那这样一份代码就不好跨平台了吧，还得改。  
![](https://pic4.zhimg.com/80/v2-7ada84091a7e2a9b357088452254069e.png)  
**小彭老师**：是有的，是一样的。  
wendous自己的api: nullnull  
linux自己的api: 干净  
glfw封装的api: nullnull  

### 3.初始化 GLAD
+ 有了上下文以后，就可以初始化 GLAD 这个库了。
```C++
gladLoadGL(); // 初始化 GLAD，加载函数指针
```
+ 由于我们使用 glad/glad.h 而不是 GL/gl.h，必须先 gladLoadGL 后才能正常使用 gl 函数，如果不先 gladLoadGL 的话，gl 函数就还是空指针，试图调用他们就会直接崩溃。
+ 注意：gladLoadGL 必须在 glfwMakeContextCurrent 之后，因为 GLAD 的初始化也是需要调用 gl 函数的，需要一个 OpenGL 上下文。

**加上错误处理这个次要干扰项**
glad 也是 C 语言函数的尿性，需要伺候一下他的返回值。
```C++
    if (!gladLoadGL()) { //返回非0表示错误
        glfwTerminate();  // 由于 glfwInit 在前，理论上是需要配套的 glfwTerminate 防止泄漏
        throw std::runtime_error("GLAD failed to load GL functions");
    }
    print("OpenGL version:", glGetString(GL_VERSION)); // 初始化完毕，打印一下版本号
```
由于我们使用 glad/glad.h 而不是 GL/gl.h，必须先 gladLoadGL 后才能正常使用 gl 函数，如果不先 gladLoadGL 的话，gl 函数就还是空指针，试图调用他们就会直接崩溃。

*鸦鸦：C++没有print函数吧？
小彭老师：小彭老师自主研发了一个print函数。    
此外，cpp23现在有std::println了。*
### 4.终于可以开始画图了吗？
在 glfwMakeContextCurrent 确定了绘图的上下文，gladLoadGL 加载了 gl 函数后，我们终于可以开始调用 gl 函数进行绘图了！我们的整个程序看起来像这样：
```C++
glfwInit();
glfwMakeContextCurrent(window);
gladLoadGL();
画图;
```
**死循环，不断画图**        
但是这样的话我们只画了一次图就退出了，窗口会在屏幕上一闪而过（只停留1帧）。
为了让窗口持续存在，我们需要用一个死循环卡住窗口，不让他直接退出。
```C++
glfwInit();
glfwMakeContextCurrent(window);
gladLoadGL();
while (true) {
  画图;
}
```
**检测窗口是否已经关闭**   
但是 while (true) 死循环又卡的太死了，我们点击窗口右上角的关闭按钮 x，他也不退出！
所以加上 glfwWindowShouldClose(window) 判断当前窗口是不是被点击了关闭按钮 x或是按了alt+F4。
```C++
glfwInit();
glfwMakeContextCurrent(window);
gladLoadGL();
while (!glfwWindowShouldClose(window)) {
  画图;
}
```
如果点击了 window 上的关闭按钮，glfwWindowShouldClose 就会返回 true，再加上 ! 运算符就变成 false 了，使得循环在点击关闭按钮时退出。

**拉取“最新事件”**   
很可惜，加上了 glfwWindowShouldClose 判断也不会在点击关闭按钮时退出，因为 glfw 窗口有一个事件（event）系统，事件是从操作系统队列中取得的，如果不去主动获取，那么就不会知道有一个“点击关闭按钮”的事件发生，因此我们必须在每次循环结束后使用 glfwPollEvents 从操作系统那里获取“最新事件”，才能让 glfwWindowShouldClose 生效。
```C++
while (!glfwWindowShouldClose(window)) {
  画图;
  glfwPollEvents();
}
```
你因为看到外面下雨了，就决定把自己关在家里不出去，但是你既不看天气预报，也不看窗外，怎么知道外面雨停了没呢？你就会一直等下去。而 glfwPollEvents 就是你看新闻的动作。

**把我的画图指令提交 - glFlush**   
等一下，我们画的图没有在窗口中显示出来！原来，gl 的画图函数为了高效，是有一个命令队列的，只有在调用 glFlush 时，才会把命令提交到驱动中去，并在窗口中显示。
```C++
while (!glfwWindowShouldClose(window)) {
  画图;
  glFlush(); //提交到OpenGL驱动中去
  glfwPollEvents();
}
```
你是一个小说家，你写了许多小说，但是你很困惑，为什么没有人喜欢我的小说。原来，你根本就没有把写好的小说投稿到出版社，那确实不可能有人看得到你的小说了。

**双缓冲专用提交函数 - glfwSwapBuffers**     
以前的窗口都是单缓冲的，由于时代的进步，现在的 glfw 创建窗口默认都会创建双缓冲的窗口，需要调用 glfwSwapBuffers 代替 glFlush。
```C++
while (!glfwWindowShouldClose(window)) {
  画图;
  glfwSwapBuffers(window);
  glfwPollEvents();
}
```
一般需要使用双缓冲区（double buffer）的地方都是由于“生产者”和“消费者”供需不一致所造成的。在 OpenGL 中，生产者是我的画图函数，而消费者是显示图形的窗口。
![](https://pic4.zhimg.com/80/v2-9dab64074bdc76df89e5e932dc9f3960.png)
*我的理解是两种可能：（1）第一帧什么都没画，第二帧把第一帧（蓝）在内存里画的移动到显示界面。       
（2）第一帧画了，一边画（蓝色）一边显示，然后第二帧也画了，一边画一边显示（红）。
回头去查一下具体该怎么理解。*

小彭老师答：第一帧在红色地方画，这时蓝色是屏幕还没有显示东西。第二帧才开始显示第一帧的东西在红色地方画第二帧。显示的始终落后于当前绘制的1frame。   
我的理解：   
![](https://pic4.zhimg.com/80/v2-66944dbe5a656c2e76cc940b1dc30143.png)

**双缓冲原理 - 小说家的寓言故事**    
《单缓冲》      
想象一个纸资源非常稀缺的世界，地球上只有一张纸，好消息是这张纸可以无限擦写。
你给读者写小说时，就在这纸上写一篇，然后把纸寄给读者。但是这是地球上唯一一张纸，读者拿去看了，你就没有纸了，你没法写小说了！你现在必须干等着读者看完纸上的小说，寄回来，才能把纸擦掉重新写第二篇小说。而当你写第二篇小说的时候，读者也只能干等着你写完，把那地球上唯一的一张纸寄过来，你们两个都恨透了这无聊的等待。    
《双缓冲》     
后来科学家在地球上发现了第二张纸，他立马把这张纸送给了地球上最杰出的小说家——你了。有了第二张纸，你开发了一种新打法，可以让作者始终有活干，读者始终有小说读。
设两张纸编号为 A 和 B，你首先在 A 纸上写小说，把 A 纸寄给读者后，读者拿起 A 纸开始阅读你的 A 小说。此时你不用干等着读者读完你的 A 小说，寄完后你可以继续在 B 上写新的小说。等读者读完了 A 小说，把 A 寄回你家后，你的 B 小说也写完了，寄给读者。读者开始阅读 B 小说，与此同时你也回收了 A 小说的纸，写起新的小说来，大家都不用干等了。

**真的可以开始画图啦！**    
好了，介绍完一圈套模板的超长鬼代码，现在可以真正开始画图了。
```C++
int main() {  // 这是主函数，程序的入口
 glfwInit();
 glfwMakeContextCurrent(window);
 gladLoadGL();
 while (!glfwWindowShouldClose(window)) {
  render();   // 我们决定把画图的部分统一封装在另一个 render 函数里
  glfwSwapBuffers(window);
  glfwPollEvents();
 }
}
```
## Chp5. 空间坐标系    
### 1 . 屏幕空间坐标系（二维）
+ 屏幕是二维的，
当我们要画一个点时，如何告诉屏幕我要画的是哪一个像素点？
+ 计算机图形学普遍采用的是笛卡尔坐标系，他具有 x 轴和 y 轴两条相互垂直的直线。
x 轴线上其中一个方向标有箭头，表示这个方向是“正方向（x+）”，沿着这个方向，点的 x 坐标越来越大，没有箭头的方向就是“负方向（x-）”，沿着这个方向点的 x 坐标越来约小，直到点在原点左侧，x 坐标变为负数。
+ 在这种坐标系下，要确定二维空间中的一个点，就需要 x, y 两个坐标。
x 和 y 这两个坐标都是实数，在计算机中，则会用浮点数（float）表示。
因此当我们要在屏幕上画一个点，就需要指定该点的 x, y 两个坐标。
也就是提供两个浮点数 x 和 y。
![](https://pic4.zhimg.com/80/v2-1cec8619ad6ab006d9c87605a56d8a75.png)
### 2 . 屏幕空间坐标的取值范围
+ 由于计算机的显示器是一块固定大小的方形屏幕，x 和 y 坐标无法向两端无限延伸，是有范围的，不同的图形 API 对屏幕空间的 x 和 y 坐标范围规定也有所不同。
+ OpenGL 中，规定 x 和 y 的取值为从 -1.0 到 1.0。x 轴正方向向右，y 轴正方向向上，屏幕中心为原点。
![](https://pic4.zhimg.com/80/v2-4172b96932f58fa89f15cfe6836f3b93.png)
### 3 . 屏幕不是正方形的情况
注意到我们计算机的显示器往往不是正方形的，通常是 16：9 的横向长方形（对于手机则是纵向长方形），这种情况下 x 和 y 坐标取值依然不变，还是 -1.0 到 1.0。只是整体被压扁了。
![](https://pic4.zhimg.com/80/v2-34e962ef9d0bab38bbe373a2b3ed60ff.png)
![](https://pic4.zhimg.com/80/v2-d4bdd3ae72c36e477a7d57341a888cbb.png)
投影矩阵也要用到aspect。
### 4 . 屏幕分辨率 - 空间离散化
+ 显示器有一个重要参数叫做分辨率，例如我的显示器分辨率是 1920x1080 的，意味着他宽度（x 方向）上有 1920 个像素点，高度（y 方向）上有 1080 个像素点。
 + OpenGL 在绘制一个点时，就把你提供的浮点坐标（x，y）转换成像素的坐标：
```
（round(x * 1920), round(y * 1080)）
```
+ 其中 round 是取整函数，求最接近的整数。
![](https://pic4.zhimg.com/80/v2-8bf2072a75bc25ac7f8b8e19f9f4e28b.png)
我们屏幕是一个个像素点（网格，离散变化），而我们指定的坐标却是0.1，0.2……连续变化的浮点数。OpenGL找最邻近的像素点。
### 5 . RGB 组合 - 颜色离散化
+ 如果你近距离观察显示器，就会发现他实际上由一个个像素点组成，每一个像素点又都由红、绿、蓝三个 LED 灯组成，计算机通过调节三个 LED 灯不同亮度的组合，从远处看，就好像有各种不同的颜色一样。
+ 这三个灯的亮度有 256 个档位可供调节，刚好对应于 8 位无符号整数 unsigned char 的表示范围 [0, 255]，因此会有“颜色就是RGB”，“RGB 就是三个 uchar”的说法。
![](https://pic4.zhimg.com/80/v2-2947d06ebe3c4ebaae1e01527fdf018d.png)
*像素点紧密地排列在一起，每个像素点又分为三个灯泡（RGB），每个灯泡液晶通透率就是液晶它有个特点，就是它转90度，偏振光透过来了。总之它就可以调节这三个灯的亮度，三个灯都亮的情况是白色，*
![](https://pic4.zhimg.com/80/v2-c15e66298746e48098058e152b3137fc.png)

**虽然我们的输入是浮点数，最终的结果却都是离散化的**
+ 我们提供的glVertex2f（x，y）坐标是 [-1, 1] 浮点数。
但是 OpenGL 为了在离散的屏幕上绘制，会用
```
（floor((x/2 + 1/2) * 1920), floor((-y/2 + 1/2) * 1080)）//PPT这里改一下
```

转换成整数坐标，并点亮相应的像素。  
*小彭老师:   
因为opengl对程序员采用坐标原点位于中心的坐标系   
小彭老师:   
对硬件采用左上角坐标系   
小彭老师:   
并且硬件还要求乘以分辨率   
小彭老师:   
得到整数的要上色像素位置坐标   
x/2+1/2  
-y/2+1/2  
是 中心 移动 到 左上角*   
我的理解：
![](https://pic4.zhimg.com/80/v2-03dacaff774798f82f8705a9b786c08d.png)
&emsp;&emsp;就opengl中计算像素位置会用（floor((x/2 - 1/2) * 1920), floor((y/2 - 1/2) * 1080)）和round(x * 1920), round(y * 1080)这两者有什么区别么？这个问题我问了一下new bing，
new bing的回答为：
你提到的两个表达式都是用来将规范化设备坐标系中的顶点映射到屏幕坐标系中的像素位置。其中，第一个表达式（floor((x/2 - 1/2) * 1920), floor((y/2 - 1/2) * 1080)）是用来将[-1,1]区间内的x和y分量映射到[0,1920]和[0,1080]区间内，并向下取整。第二个表达式（round(x * 1920), round(y * 1080)）是用来将[0,1]区间内的x和y分量映射到[0,1920]和[0,1080]区间内，并四舍五入。    
&emsp;&emsp;这两个表达式的区别在于，第一个表达式假设规范化设备坐标系中的原点在中心，而第二个表达式假设规范化设备坐标系中的原点在左下角。

MATLAB取整函数   
原文链接：http://www.cppblog.com/xiaozhixd/archive/2010/11/17/133856.html

(1)fix(x) : 截尾取整.
>> fix( [3.12 -3.12])  
ans =  
3 -3  


(2)floor(x):不超过x 的最大整数.(高斯取整)
>> floor( [3.12 -3.12])  
ans =  
3 -4  


(3)ceil(x) : 大于x 的最小整数
>> ceil( [3.12 -3.12])  
ans =  
4 -3  


(4)四舍五入取整 
>> round([3.12 -3.12])  
ans =  
3 -3  


MATLAB中四个取整函数具体使用方法如下：

Matlab取整函数有: fix, floor, ceil, round, fix  
朝零方向取整，如fix(-1.3)=-1; fix(1.3)=1;  
floor 朝负无穷方向取整，如floor(-1.3)=-2; floor(1.3)=1;  
ceil 朝正无穷方向取整，如ceil(-1.3)=-1; ceil(1.3)=2;  
round 四舍五入到最近的整数，如round(-1.3)=-1;round(-1.52)=-2;round(1.3)=1;round(1.52)=2。  

**opengl中round()和roundeven()函数**   
**roundEven** returns a value equal to the nearest integer to x. The fractional part of 0.5 will round toward the nearest even integer. For example, both 3.5 and 4.5 will round to 4.0.  
 **round** returns a value equal to the nearest integer to x. The fraction 0.5 will round in a direction chosen by the implementation, presumably the direction that is fastest. This includes the possibility that round(x) returns the same value as roundEven(x) for all values of x.

*小彭老师：为什么roundeven要向偶数取整呢？   
因为可以避免系统误差，例如你有一个数据：    
0.5 1.5 2.5 3.5    
那么你四舍五入一下，平均值就增加了0.5。但是向偶数舍入，就可以让平均误差互相抵消。所以这是fpu默认的取整模式。   
鸦鸦：fpu？    
小彭老师：以前x86 cpu只有整数，浮点数是发射到外部另一个独立的x87 fpu去计算的。不过现在为了睾孝fpu已经集成到cpu内部了。*

+ 我们提供的glColor3f（r，g，b）颜色是 [0, 1] 的浮点数。
但是 OpenGL 为了操控只能 256 档调节亮度的三原色 LED，会用
```
（floor(r * 255), floor(g * 255), floor(b * 255)）
```
的档次来点亮三颗 LED。

### 6 . 屏幕也有 Z 方向？   
屏幕也是有Z方向。      
![有层叠前后关系](https://pic4.zhimg.com/80/v2-fb053e60f225f7ab9b807c2c33e00e6d.png)
+ OpenGL 规定朝向屏幕里面为 z 轴正方向。
z 坐标越小的值越靠近人眼或者摄像头。*为了服务opengl右手坐标系。*        
+ 屏幕是二维的，为什么还要有 z 坐标？
+ 这是为了服务于 OpenGL 的“深度测试（depth test）”的功能，他们管 z 坐标叫“深度”，点的 z 越大就说明他“陷入屏幕越深”，也就是离人眼更远。深度测试是什么呢？     
 ![](https://pic4.zhimg.com/80/v2-d74d43ec8594949dd379e1f569dc2de1.png)

### 7 . 深度测试
+ 由于光学规律，远处的物体会被近处的物体遮挡，OpenGL 为了模拟现实中的这种遮挡效果，会给每个像素除了 RGB 值外，额外加一个深度值的信息。
+ 每次绘制一个点时，会检测当前点的 z 值是否小于缓冲中的深度值，如果小于等于则成功绘制，覆盖旧物体；否则认为该点被前景遮挡，放弃绘制新物体。
+ 这种格式的图像又称 RGBD 图，在计算机视觉中非常有用，由于现有的 png 格式支持 alpha 透明度通道，深度值 D 通常会夺舍保存到 alpha 通道里。
![](https://pic4.zhimg.com/80/v2-6bbaed9b28ec5155a84bcfea5f5b5eab.png)

**深度图**
+ 所有像素点的深度可以组成一副新的图像，称为深度图。启用深度测试后，OpenGL 缓冲区不仅包含颜色信息，还包含一张深度图，用于剔除遮挡在前景后方的物体。
+ 和普通 RGB 颜色的图像一起，又称 RGBD 图，在计算机视觉中非常有用，由于现有的 png 格式支持 alpha 透明度通道，深度值 D 常常会夺舍保存到 alpha 通道里……
![](https://pic4.zhimg.com/80/v2-1736b4fa837b9934bba1ebbb8c4710c8.png)
*你绘制的时候不仅要说x,y坐标，还要说这个东西有多深啊。*
+ 没有深度缓冲，图形的相互覆盖只能由绘制先后顺序决定，后来者居上。
而启用了深度测试后，会根据像素点的 z 坐标来判断谁覆盖谁，例如图中的宇航员会覆盖他背后的月球表面，因为宇航员离摄像头更近，z 坐标更小。
### 8 . 屏幕空间的裁剪
![](https://pic4.zhimg.com/80/v2-91bd9b77f848c754ea561507a4090e04.png)
*只画在框框里的那段（蓝色），三角形不用全画。*       
如果画了一个 x 或 y 坐标超出 [-1, 1] 区间的点，OpenGL 则会认为他已经不可能显示在屏幕上了，所以会把这个点裁剪（clip）掉，不予显示，也不会对他进行任何着色器计算。
![](https://pic4.zhimg.com/80/v2-9539dc3d50b4e1ea4d15559cf543cdb3.png)

**Z 方向也会裁剪**    
+ 就和 x，y 坐标一样，z 坐标超过 -1 到 1 范围的点会被“裁剪”掉。
+ 你可能疑惑，x 和 y 会超出屏幕被裁剪可以理解，因为他们本来就不可能在屏幕上显示了，z 坐标也裁剪，看起来好像没有这个必要？
+ 有必要的，因为 OpenGL 的深度缓冲是有限精度的，通常是 24 位无符号整数，把 0 到 2^24-1 映射到 z 浮点坐标的 -1 到 1，如果 z 浮点坐标无限制，那么定点量化的深度缓冲就容纳不下了。
  
*太远的物体不显示，太近的物体也会不显示。例如如果地球在摄像机后面，深度值为-3万8，就不用画了。*
![](https://pic4.zhimg.com/80/v2-be47fa9f54547de6485f14fa7a4f7cbe.png)    
补充：https://blog.csdn.net/qjh5606/article/details/118675803
### 8 . 世界空间坐标系（三维）   
三维空间同样有笛卡尔坐标系，确定三维空间中的一个点，就需要 x, y, z 三个坐标。
![](https://pic4.zhimg.com/80/v2-2b9f0e1c2daae606a6f165781ec87419.png)
## Chp6. 绘制各种图形 
### 1 . 三维世界到二维屏幕的转换
&emsp;&emsp;无论我们想要表现的图形空间是多么丰富多彩的三维世界，最终都需要投影到二维的屏幕上呈现给用户欣赏。    
&emsp;&emsp;在三维世界坐标和二维屏幕（准确的说还是三维屏幕，其中 z 坐标用于深度检测）之间转换的，是一个矩阵，我们将在下一课中详细介绍投影矩阵等知识。    
&emsp;&emsp;目前我们只考虑二维图形的绘制，在默认的配置下（没有手动指定过任何矩阵），OpenGL 会把我们输入的世界空间坐标直接当作屏幕空间坐标。     
### 2 . 指定一个顶点
要画一个点，可以用 glVertex3f 函数，他有三个参数，分别是你要画点的 x, y, z 坐标。    
由于目前我们只是在二维屏幕上画图，也暂时不打算启用深度测试，z 坐标暂时没有意义，可以始终为 0。   
默认的配置下（没有指定过矩阵），OpenGL 会把世界空间坐标直接当作屏幕空间坐标。    
```
glVertex3f(0.0, 0.0, 0.0);
```
在（0，0，0）坐标处绘制一个点，也就是在屏幕的中央绘制一个点。        

要画一个点，可以用 glVertex3f 函数，他有三个参数，分别是你要画点的 x, y, z 坐标。   
由于目前我们只是在二维屏幕上画图，也暂时不打算启用深度测试，z 坐标暂时没有意义，可以始终为 0。   
默认的配置下（没有指定过矩阵），OpenGL 会把世界空间坐标直接当作屏幕空间坐标。   
```
glVertex3f(0.0f, 0.0f, 0.0f);
```
在（0，0，0）坐标处绘制一个点，也就是在屏幕的中央绘制一个点。      
但是 0.0 这样的写法并不严谨，glVertex3f 的参数是 float 类型的，而 C 语言（万恶的）中带小数点的常量（如 3.14）默认是 double 类型的，此处发生了隐式类型转换，为了防止被转换（以及影响 auto 推导），建议在每个带小数点的常量后面加一个 f 后缀（如 3.14f），这样 C 语言就会把他视为 float 类型常数而不是 double 类型常数。   

*glsl里默认是浮点。
科研狗是double（64位）一般是科学计算的。图形学是float（32位）。人工智能用half（16位），有时量化成4位，2位。*
### 3 . 画一个点 
+ 但是光靠 glVertex3f 指定一个顶点坐标还没有用。OpenGL 支持多重绘图模式：    
点 GL_POINTS   
线 GL_LINES   
面 GL_TRIANGLES    
+ 我们可以用 glBegin(GL_xxx) 来指定一个绘图模式，然后通过 glVertex3f 指定这种模式下的一些顶点坐标，最后调用 glEnd() 结束绘制。
+ 例如要告诉 OpenGL 接下来的顶点数据是让你用来绘制“点”可以这样写：
```C++
glBegin(GL_POINTS);
glVertex3f(0.0f, 0.0f, 0.0f);
glEnd();
```
画一个点，但是太小了，只有一个像素大小，根本看不见！直径能不能调大一点？
![](https://pic4.zhimg.com/80/v2-325952d75c73b48dce841c7790ca282a.png)
### 4 . 画一个直径 64 个像素的点
可以用 glPointSize 函数指定点绘制的大小。
```C++
glPointSize(64.0f);
glBegin(GL_POINTS);
glVertex3f(0.0f, 0.0f, 0.0f);
glEnd();
```
![](https://pic4.zhimg.com/80/v2-fcb6a9a55ed5a1fa032222a5f8cc6408.png)
### 5 . 画一个直径 64 个像素的，圆形的点
glEnable 函数可以启用 OpenGL 的一些特性，例如 GL_POINT_SMOOTH 会让点的形状变成圆形的（而不是默认的方形）。
```C++
glEnable(GL_POINT_SMOOTH);
glPointSize(64.0f);
glBegin(GL_POINTS);
glVertex3f(0.0f, 0.0f, 0.0f);
glEnd();
```
![](https://pic4.zhimg.com/80/v2-046b74e596a8acaeb8b4f1adbeb798a4.png)
![](https://pic4.zhimg.com/80/v2-e2f5807752701f3c4d73b0133e61eefe.png)左图是有锯齿的。右图是抗锯齿的，0.5应该表示不透明度吧。    
**启用抗锯齿**      
```C++
glEnable(GL_POINT_SMOOTH);
glEnable(GL_BLEND);
glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
glPointSize(64.0f);
glBegin(GL_POINTS);
glVertex3f(0.0f, 0.0f, 0.0f);
glEnd();
```
![](https://pic4.zhimg.com/80/v2-02a7271681bec0b52d1a682881c1fedd.png)

**状态机模型：一次设置，永久生效，直到再次设置或取消**     
```C++
glEnable(GL_POINT_SMOOTH);
glEnable(GL_BLEND);
glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
glPointSize(64.0f);
```
这些东西可以放在 main 函数里，因为 OpenGL 使用的是“状态机模型”，任何东西只需要设置一次，以后会一直保持这个设置不变，直到你再调用或者 glDisable。    
*这些设置可以移动到main函数里面来，不用放在render()，render()它是每个循环都会绘制一次。*

**CHECK_GL**      
+ glEnd() 也可以加上 CHECK_GL，检测绘制过程是否出错。
+ CHECK_GL 宏的实现原理：     
https://www.bilibili.com/video/BV1DN411C7Xb（【C/C++进阶】宏函数实用指南）
+ CHECK_GL 宏的使用案例：       
https://www.bilibili.com/video/BV1AX4y1h7jg（【C++/OpenGL】三体运动物理仿真）    
![](https://pic4.zhimg.com/80/v2-7764352b2df67c3f768b5c28b0ef869f.png)
![](https://pic4.zhimg.com/80/v2-1610e41b008885fe506aaac8f2381ca6.png)
![](https://pic4.zhimg.com/80/v2-af675f948ec8d9e804307052861b5723.png)
![](https://pic4.zhimg.com/80/v2-eae466a9870073e9dfa56fa682df4f86.png)     
遇到这几种报错可以查：https://registry.khronos.org/OpenGL-Refpages/gl4/html/glRenderbufferStorage.xhtml   
![](https://pic4.zhimg.com/80/v2-d58885c1e8edd4fb53e4da40e366cad0.png)    
可以mark一下这个网址：https://registry.khronos.org/OpenGL-Refpages/gl4/html/    
![](https://pic4.zhimg.com/80/v2-d08fecd70186298fd14937de4f81fdb2.png)       
CHECK_GL注意一点，它只在最后的glEnd()上用就行。glBegin()不要用哦。    
因为Begin和End之间只允许有glVertex3f，glColor这类指定顶点数据的函数。不能有glGetError();结束后再秋后算账。    
![](https://pic4.zhimg.com/80/v2-fa28c085c60b3fb44ab9ee82cfa05a98.png)
![](https://pic4.zhimg.com/80/v2-1499e7e3e4a358f6d0be29253dfb4f90.png)

### 6. 画多个顶点
![](https://pic4.zhimg.com/80/v2-76c959644cbb1f39127ca5d31f42104d.png)
+ 正如 GL_POINTS 这个名字所暗示的那样，这个模式下只要指定多个顶点坐标，就可以绘制多个点。要绘制三个点可以这样写：
```C++
glBegin(GL_POINTS);
glVertex3f(0.0f, 0.5f, 0.0f);
glVertex3f(-0.5f, -0.5f, 0.0f);
glVertex3f(0.5f, -0.5f, 0.0f);
glEnd();
```
*Z轴一律不考虑，现在画的是2维的点。*   

**每个顶点指定不同的颜色**     
每个顶点可以通过 glColor3f 分别指定颜色，以（R，G，B）三个 0 到 1 之间的浮点数来指定：  
```C++  
glBegin(GL_POINTS);
glColor3f(1.0f, 0.0f, 0.0f);
glVertex3f(0.0f, 0.5f, 0.0f);
glColor3f(0.0f, 1.0f, 0.0f);
glVertex3f(-0.5f, -0.5f, 0.0f);
glColor3f(1.0f, 1.0f, 0.0f);
glVertex3f(0.5f, -0.5f, 0.0f);
glEnd();
```
### 6. 画三角形
+ GL_POINTS 把每个坐标当作单独的点来绘制，而 GL_TRIANGLES 则是把三个坐标点连成一个三角形来绘制：
```C++
glBegin(GL_TRIANGLES);
glVertex3f(0.0f, 0.5f, 0.0f);
glVertex3f(-0.5f, -0.5f, 0.0f);
glVertex3f(0.5f, -0.5f, 0.0f);
glEnd();
```
**画三角形 - 每个顶点不同颜色，使三角形呈渐变效果**    
+ 三角形的每个顶点若用 glColor3f 指定了颜色，则三角形会呈现渐变的效果。
```C++
glBegin(GL_TRIANGLES);
glColor3f(1.0f, 0.0f, 0.0f);
glVertex3f(0.0f, 0.5f, 0.0f);
glColor3f(0.0f, 1.0f, 0.0f);
glVertex3f(-0.5f, -0.5f, 0.0f);
glColor3f(1.0f, 1.0f, 0.0f);
glVertex3f(0.5f, -0.5f, 0.0f);
glEnd();
```
![](https://pic4.zhimg.com/80/v2-78b294fd067714d930cd0c6840ba1f66.png)

**画三角形 - 单一颜色填充**  
如果只指定了一个 glColor3f，则所有顶点都是同样颜色，渐变效果退化为全部采用相同颜色填充。
```C++
glBegin(GL_TRIANGLES);
glColor3f(0.5f, 0.5f, 1.0f);
glVertex3f(0.0f, 0.5f, 0.0f);
glVertex3f(-0.5f, -0.5f, 0.0f);
glVertex3f(0.5f, -0.5f, 0.0f);
glEnd();
```
![](https://pic4.zhimg.com/80/v2-3248ae83fe8fe2bfdbf77920bde429de.png)

**画多个三角形 - 要画 n 个三角形则指定 3n 个顶点坐标即可**  
+ 同样的，GL_TRIANGLES 可以绘制多个三角形，但要求 glBegin 和 glEnd 之间 glVertex3f 调用的数量必须是 3 的整数倍。
+ 指定 3n 个顶点就会绘制 n 个三角形。
```C++
glBegin(GL_TRIANGLES);
glVertex3f(0.0f, 0.0f, 0.0f);
glVertex3f(0.0f, 1.0f, 0.0f);
glVertex3f(1.0f, 0.0f, 0.0f);
glVertex3f(-0.5f, 0.0f, 0.0f);
glVertex3f(-1.0f, -1.0f, 0.0f);
glVertex3f(0.0f, -1.0f, 0.0f);
CHECK_GL(glEnd());
```
![](https://pic4.zhimg.com/80/v2-03edbb25c05df970fe385db658a23626.png)  
**画多个三角形 - 分两次调用**  
如果你觉得太复杂，分成两次 glBegin 和 glEnd 也是等价的。
```C++
glBegin(GL_TRIANGLES);
glVertex3f(0.0f, 0.0f, 0.0f);
glVertex3f(0.0f, 1.0f, 0.0f);
glVertex3f(1.0f, 0.0f, 0.0f);
CHECK_GL(glEnd());
glBegin(GL_TRIANGLES);
glVertex3f(-0.5f, 0.0f, 0.0f);
glVertex3f(-1.0f, -1.0f, 0.0f);
glVertex3f(0.0f, -1.0f, 0.0f);
CHECK_GL(glEnd());
```
### 7 . 画一个圆 - 先画一圈点试试看
```C++
glBegin(GL_POINTS);
constexpr int n = 20;
constexpr float pi = 3.1415926535897f;
for (int i = 0; i < n; i++) {
    float angle = i / (float)n * pi * 2;
    glVertex3f(sinf(angle), cosf(angle), 0.0f);
}
CHECK_GL(glEnd());
```
angle = 循环的次数/平分数 * 2π
![](https://pic4.zhimg.com/80/v2-cc86806422ed9ebaec05690bdf8a850a.png)
**画一个圆 - 用一系列三角形实心地填充这个圆**
```C++
glBegin(GL_TRIANGLES);
constexpr int n = 20;
constexpr float pi = 3.1415926535897f;
for (int i = 0; i < n; i++) {
    float angle = i / (float)n * pi * 2;
    float angle_next = (i+1) / (float)n * pi * 2;
    glVertex3f(0.0f, 0.0f, 0.0f);
    glVertex3f(sinf(angle), cosf(angle), 0.0f);
    glVertex3f(sinf(angle_next), cosf(angle_next), 0.0f);
}
CHECK_GL(glEnd());
```
![](https://pic4.zhimg.com/80/v2-adc6fefd447f5cbebb7e1c357bb18b55.png)
*为什么要写这么一串：constexpr float pi = 31415926535897f;  
因为M_PI在windows中在math.h不定义，你得定义一个宏才能让它定义。不去定义这个，却定义min函数和max函数，这两个函数没有什么卵用，被标准库std取代的函数。包括M_E也不去定义。你导入了windows.h的话，建议你undef一下min()max()这两个宏。*
![https://baijiahao.baidu.com/s?id=1729374634493915166&wfr=spider&for=pc](https://pic4.zhimg.com/80/v2-b8bb68fe1bcfd24e1184b01ececd5572.png)
**画一个圆 - 取点密度提升，用 100 边形画近似圆**
![](https://pic4.zhimg.com/80/v2-cc39efe46d15e01cc63fd7c2a259b564.png)
![](https://pic4.zhimg.com/80/v2-4a5267e03bbe139131bd4da67c2f7a8c.png)
**画一个圆 - 让圆的半径为 0.5（单位：半屏宽度）**
![](https://pic4.zhimg.com/80/v2-6ad7de99dd685c4093e807fb24b8f893.png)
![](https://pic4.zhimg.com/80/v2-7e5f8983dca82e55586dbe5a0d47c1d3.png)  

**画一个扇形 - 1/3 个圆，控制循环变量的范围即可**
![](https://pic4.zhimg.com/80/v2-6179238a74b9b717e473d7984fdfd052.png)
![](https://pic4.zhimg.com/80/v2-61a1a128ad6746d3bf93513819396ead.png)

**画一个同心圆 - 用 100 个四边形拼接在一起即可**  
```C++
glBegin(GL_TRIANGLES);
glPolygonMode(GL_FRONT, GL_LINE);
glLineWidth(5.0f);
constexpr int n = 100;
constexpr float pi = 3.1415926535897f;
float radius = 0.5f;
float inner_radius = 0.25f;
for (int i = 0; i < n; i++) {
    float angle = i / (float)n * pi * 2;
    float angle_next = (i+1) / (float)n * pi * 2;
    glVertex3f(radius * sinf(angle), radius * cosf(angle), 0.0f);
    glVertex3f(radius * sinf(angle_next), radius * cosf(angle_next), 0.0f);
    glVertex3f(inner_radius * sinf(angle), inner_radius * cosf(angle), 0.0f);
    glVertex3f(inner_radius * sinf(angle_next), inner_radius * cosf(angle_next), 0.0f);
    glVertex3f(inner_radius * sinf(angle), inner_radius * cosf(angle), 0.0f);
    glVertex3f(radius * sinf(angle_next), radius * cosf(angle_next), 0.0f);
}
CHECK_GL(glEnd());
```
![](https://pic4.zhimg.com/80/v2-bc4881f6018be1fca49356e28ef0e7e0.png)  
为了理解代码我用线框模式画了如图
![](https://pic4.zhimg.com/80/v2-056d46723765c1edaaadbde02e430b63.png)
![](https://pic4.zhimg.com/80/v2-29a812fac5219e62675c468488af9f64.png)
![](https://pic4.zhimg.com/80/v2-1b0b691976d80086389733d6f43c2dfb.png)

**动感光波——————**
![](https://pic4.zhimg.com/80/v2-3f5985b8e8bcce364257da546608b610.png)
```C++
glBegin(GL_TRIANGLES);
constexpr int n = 100;
constexpr float pi = 3.1415926535897f;
float radius = 0.5f;
float inner_radius = 0.25f;
static int x = -1;
x++;
if (x > n)
    x = 1;
for (int i = 0; i < x; i++) {
    float angle = i / (float)n * pi * 2;
    float angle_next = (i+1) / (float)n * pi * 2;
    glVertex3f(radius * sinf(angle), radius * cosf(angle), 0.0f);
    glVertex3f(radius * sinf(angle_next), radius * cosf(angle_next), 0.0f);
    glVertex3f(inner_radius * sinf(angle), inner_radius * cosf(angle), 0.0f);
    glVertex3f(inner_radius * sinf(angle_next), inner_radius * cosf(angle_next), 0.0f);
    glVertex3f(inner_radius * sinf(angle), inner_radius * cosf(angle), 0.0f);
    glVertex3f(radius * sinf(angle_next), radius * cosf(angle_next), 0.0f);
}
CHECK_GL(glEnd());
```
![记得有这个](https://pic4.zhimg.com/80/v2-9c81308ebbf8fcc7f368ae6a69fef98c.png)  
实现效果：  
![没法放gif，懂我意思就好](https://pic4.zhimg.com/80/v2-9ac77f72030fc57c6cf42304f5269bc4.png)

**动感光波2——————**   
![](https://pic4.zhimg.com/80/v2-970e27a68c12b4e0165d8737470befb5.png)
![本应放动图](https://pic4.zhimg.com/80/v2-75e59efaed6c19e474c997aaca2fec9a.png)
![](https://pic4.zhimg.com/80/v2-f57ed6dcafb8fd3f51f82ec55f85a86d.png)
![本应放动图](https://pic4.zhimg.com/80/v2-cd4e23d8a8ca853307fcb522fdffa7f5.png)
![](https://pic4.zhimg.com/80/v2-84a4fdd1ea2acced5c0d2993ea99d3a2.png)
![本应放动图](https://pic4.zhimg.com/80/v2-aba6a167f18661ccab9e65021616b7e7.png)

## Chp7 GitHub 交作业
主要看PPT，其他需要补充的：
1 . 如果要把分支也fork上
![不要勾选这个](https://pic4.zhimg.com/80/v2-341e12ee9c8f0e79d8953d6ee2ed6ebe.png)
2 . ![不要把tree那些的地址也写上](https://pic4.zhimg.com/80/v2-35aae707df00e3571688fa1b12aff874.png)