### unity UI策划笔记  
#### 1. LayoutElement  
参考的是这个网页：  
https://blog.csdn.net/weixin_45532761/article/details/129936137  

优先级: Min >Preferred >Flexible

的含义是：  
如果 Min Width < Preferred Width  
取Preferred Width。  
如果 Min Width > Preferred Width   
取Min Width。  
因为要先保证Min Width被满足。  

#### 2 . Layout Group里的
Child Control Size 和   
Child Force Expand的用法解释：  
https://www.hallgrimgames.com/blog/2018/10/16/unity-layout-groups-explained    

（1）    

Child Force Expand：是否要强制子布局元素扩展以填充额外的可用空间

父物体的vertical layout group勾选这些：  
![picture 0](images/20ed4787e36475a847e3b5a6af7cedc958e18c432ddcb70f8dd59072a1596f3b.png)  
子物体呈现这样的效果：  
![picture 1](images/db97d53d0f507c2167ffa8789771b6321d760478999146539d005c58ffe132af.png)  

勾选Controls Size Height 而不勾选Force Expand Height会导致高度=0。  
![picture 2](images/593734071fb043310273326da0dc5a102bd6aa54cf3d02b991989397f2291602.png)  
因为勾选controls size height会使默认值为0，因此一旦只让它控制，我们的图像就会消失。  

为了在只勾选：  
√ Child Controls Size Width   
√ Child Controls Size Height  
√ Child Force Expand Width  
这三个的情况下怎么让图片显示出来？  
可以为三个子物体添加“Layout Element” Component以重写那个默认的0值。  

（2）Flexible Height控制的是权重值。假如一个设置为1，一个设置为2。  
那么它们的大小比例是1：2 。  

当一个子物体又勾选了preferred heights，又勾选了flexible height。  
那它实际的值等于preferred heights的值 + 在剩下的划分中所占得的比率的值。  

#### 3 . 测试题第三题的正确解法：  
![picture 3](images/6fe8a537e00e555d8146fa18c87bae81be403f269bf1ddbb804ab9d65b28a257.png)  
arrow image的pivot设在这里  
![picture 4](images/9adb4cabf7529b66bc1e27f3997e8c727d0162fb837fb4c5587ad773fa2875e8.png)  
并且加入Layout Element组件勾选这个：  
![picture 5](images/6f2f470c75c23bd7f11138d09e342c3d002f9d084a14467b9b51e6aa90eaff2f.png)  
ignore layout，把它移动到合适的位置。  