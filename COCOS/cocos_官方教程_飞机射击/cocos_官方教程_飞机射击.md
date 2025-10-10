### cocos_官方教程_飞机射击
1 . gizmo  
![picture 0](images/e9287d2f39e781b5fb6f676a6360f5b9065cd00176d7765da1064b9d25143c39.png)  

2 .材质： builtin standard接受光照，builtin unlit不接受光照，当然这两个不止这点区别：  
![picture 1](images/44a1e79467072e7c9934d4ec0ff745a2bac123d224251a93742d8562d9e24a2a.png)  

材质关联贴图：  
![picture 2](images/40717f2f8f74e973cd790122dab1aa9f52da7daa837876360abc162002d01fd2.png)  

3 . 这里可以添加自定义设备宽度：  
![picture 3](images/b5ae396ab87491e7c60a3a63b7523bbd61f737313776a888deb30ee3131cf464.png)    

![picture 7](images/1fca26c8436f1d03d82454b828a013cedb657f353bff24dbf68febe314f2597a.png)  


4 . 相机的projection是ORTHO  
![picture 4](images/e492fcfcd5e7d5b15b26458b203660f73f237d939c20e35c639f1cd00ab66a62.png)  

5 .  
![picture 5](images/7f7abb14b9368e89f107f6fd94eee1fe7e3f56bc831f7e6b526e83ad901c95a7.png)  

6 .  
默认情况下组件是不会在编辑器下运行的，我要让它在编辑器下运行的话需要加：  
![picture 6](images/7ffb0d46c13da947250e7d7ad25508346b7acb4efd8cedc0d657386a1deba01b.png)  
这其实是一个装饰器的写法，装饰器大多数提供的是一个描述信息给编辑器，让编辑器提供相对应的功能。
因为脚本默认情况下是在运行时才会执行的。

按住ctrl键将鼠标移动到第二行的`_decorator`上，点击跳转到装饰器提供的API。  

7 . 敌机出现逻辑  
![picture 8](images/4a361406a0959d9c7e6ed85044fa5211e2224ed92855be1d515dcb18592b2f64.png)  

8 . 碰撞矩阵，掩码：  
![picture 9](images/06ece91d83a4ab3d28a389bb6b8734357918f2afcdac8d5c0c55e831a9214238.png)  

9 . 2D根节点有两个：  
大多数情况下使用的都是Canvas节点，另一个则需要创建空节点，然后在它身上添加RenderRoot2D组件。所有的2D节点都必须在这两个节点下才可以被Creator识别为2D对象。  

10 . 下方的物体inputEvents就会被挡住。  
![picture 1](images/98155f18784b6a23c5f00a658c15d3b507dd5275eec4c0871c382abea1b9a023.png)  

11 . 对象池  
整个项目有用到instantiate的地方去替换。  
![picture 2](images/6ca46f7abc5696784af520f3a3a620ab02a8b31d5b4f479cbdb3c6b9dfec8775.png)  

因为PoolManager不是个组件所以没有地方去实例它。因此这边定义一个静态的方法去做实例化。