## dot product
### 一. 点乘概括来讲

1 . 在网页：https://amirazmi.net/dot-products-in-games-and-their-use-cases/  
中提到：  
(1)magnitudes & directions  

The dot product as **Allen Chou**, a gameplay programmer at Naughty Dog sums it up really well by saying, “The dot product is a simple yet extremely useful mathematical tool. It encodes the relationship between two vectors’ **magnitudes** and **directions** into a single value.”  
【p.s. Allen Chou大佬的博客也不错】  

(2)只能向量乘向量么？  
we can only take the dot product of vectors! We can not take dot products of points! It does not mean anything!  

【鸦补充：这句话其实不太严谨，SAT碰撞算法中运用了向量去点乘点】  

2 . 在网页： https://betterexplained.com/articles/vector-calculus-understanding-the-dot-product/  
中提到：  
（1）energy比喻法  
![picture 0](images/4f4ce399e92b7f083585d13f83efc5645623940a3a70ebdd9b39c372d628f28d.png)  

3 . 这个reddit网页汇聚了很多点乘的应用，以及他们推荐的教程。  
https://www.reddit.com/r/learnmath/comments/8jbtcw/what_does_the_dot_product_tell_you/   

4 . 乐乐书上的几点补充  
（1）任何两个矢量的点积**a·b**等同于**b**在**a**方向上的投影值，再乘以**a**的长度。  
![picture 1](images/063dab90d5bf42be4ff7414f195634194f8fe09664deb7437725989712295353.png)  

(2)一个矢量和本身进行点积的结果，是该矢量的模的平方。    
![picture 2](images/643d5313aa496f93bf85f04d4df6d1b75ffb1c31802dfcbc0a92d2359db5b9ba.png)  
means：如果只是比较两个矢量的长度大小，直接使用点积结果，不用使用模的计算公式去开平方，节省性能。  

5 . 这个网页：  
https://gamedev.stackexchange.com/questions/89831/how-do-i-interpret-the-dot-product-of-non-normalized-vectors  
提到：  
This is helpful for rewriting a vector from one coordinate system in terms of a different basis, or for removing/reflecting the component of a vector that's parallel to a particular direction while keeping the perpendicular component intact. (eg. zeroing the component of a velocity that would take an object through a barrier, but allowing it to slide along that barrier, or rebounding it away)  

联想到：在斜坡滑动（slope slide）  

发现常提到的碰撞检测有：AABB，和SAT  

联想到 五 . Collide and Slide算法  

### 二. Starting with SAT  
SAT网址1：https://programmerart.weebly.com/separating-axis-theorem.html    
SAT网址2：https://dyn4j.org/2010/01/sat/  

godot项目代码是follow的网址1写的，网址里面的代码在这里有点小错误。  
![picture 3](images/5f67a1f29fdf92162c969b658a07b412d61e88399bf0aaf62bc6806b254ad84a.png)  

网址1中的坐标系如下图：  
![picture 4](images/c126da3338dbde135812cda1b213a74abd5674a9de2b2101a461b27cced05419.png)  
godot的Custom drawing in 2D的坐标系如下图：  
![picture 5](images/009435a976941e791278bc0137c5001fac694fa2c8e8177fb98bda39a51e8f04.png)  

可以看到两者视觉上原点位置不同，那么需要修改网址1的代码转一下坐标系么？
答案是不需要，因为数学逻辑里是一样的，虽然表现的视觉不一样。  

为了搞清楚为什么SAT算法中：点·向量的数学含义，做了一下小小的考古。  

### 三.考古点乘  
![picture 6](images/412161d65cc30080c782615fd9ea982e06f7bb3b5f3888d52e6b1e215f96b783.png)  

![picture 7](images/1c0676ce11d12f82bf981ef98e276e4aa7194fde1434469b5d380cddb15345cc.png)  

里面的ref是：https://math.stackexchange.com/questions/62318/origin-of-the-dot-and-cross-product

小彭老师评价：x是叉乘吧，·是点乘。  
鸦回复：我瞎写的，不太严谨。  

接着小彭老师分享了他的思路。但是我想说这种思路和乐乐书上一样，都是已知x乘x+y乘y这个公式去寻找和模长模长cos的关系。但是历史发展来说，你一开始是不知道x乘x+y乘y的。  
![picture 8](images/9c660b312068563a28cb40b84dddfe72d0f796f785ef75953783cd1f79b5c007.png)  

### 四 . AABB碰撞检测
![picture 9](images/73dd79c594643b36ecefcfc4eceef569892ef9284b566a2b969153728f32bdc1.png)  
ref: learnOpenGL  
多边形的边界，x轴是否重合，y轴是否重合。都是true则是碰撞。  

https://kishimotostudios.com/articles/aabb_collision/  
这个网站是互动教学该算法：  
![picture 10](images/2b7ab1ec69b95c945db6de0be844f83c9eb3983f9b7fd3c085c70860d08fa6cd.png)  
![picture 11](images/ccf70274652b0cdd7a44df226ae1726b6512762bd4386a96c6245187631acf74.png)  
左上角有检测true false。  

圆和圆之间的碰撞检测：  
![picture 12](images/2f385166e91ab7888765d9e17139ac3e3715ffd430f88e39474e086a121f4d05.png)  

![picture 14](images/e0fdf7069fee66a70402c8469b56a586a527afc83f7eb8879aba6c33d3d67e45.png)  

![picture 15](images/da5f8dc2b4850dafc33d36ed9753179cc47033808f84ad0f0d84b96a3c5064dc.png)  
collision detection 也叫 collision response

### 五 . Collide and Slide算法    
由 一.5 引出。  
视频tutorial：https://www.youtube.com/watch?v=YR6Q7dUz2uk&t=105s
![picture 16](images/76d87b54e04f98b5aaf3b6b9416c83e6d60002da0ac71b8d41f43898b833c5af.png)  
蓝框代码如下：  
![picture 17](images/e4608a185829e74b1e3de4517b48d8ec23092656cd5870e1c0dccd5bae7c6a8b.png)  
 
![picture 20](images/18426d9713391e5130c74e927c76a8246948d6d75b3823111a62ed72b85496df.png)  

![picture 18](images/f0f6c58ba8039c0c3a8f667585f01202b61e1ab44f8a630fc211af4cec46e614.png)  
![picture 19](images/c8546efc32fa4971c5508bad13ba8b01de89641a08186fca0c293944e86da8d3.png)   
【！！！待研究！！！】   
感觉这条评论有问题，我回头再看看。  
他的意思是projectandscale函数里包含了先normalize再mag，然后scale变量里面也包含了normalize，重复了。  
但是我感觉两个normalize不是一个意思。  

顺便scale = 1 - 那一坨  
的含义是：  
那一坨是 相当于单位矢量x单位矢量是 cos的值。  
当角色冲墙壁的时候cos值 = 1。
scale = 1-1 = 0。此时角色冲不进墙里。
沿着墙壁的时候：  
那一坨 = 0 （直角）  
scale = 1-0 = 1  
角色移动速度 = 原速度。  

联想到khan academy的这节课，其实好像没啥关系哈哈哈哈哈。  
https://www.youtube.com/watch?v=27vT-NWuw0M&list=LL&index=20  
《投影简介》中的  
![picture 21](images/a3b3f26034c061a83d3814c3d7df92f47fe73d442ec41ff6910c135d2b45c430.png)  
浅粉色通过x向量减投影获得：  
![picture 22](images/da999ad30603416b280e984d0f8dabfb6c7d5093970acc9ebc3c550fc42ac3c5.png)  
或者直接求其垂直向量-->即颠倒x,y位置，再取x的负  
![picture 23](images/4f521d8d85972ceea790011900afcdd074bdc046ed56410fdb6848c69d39fb19.png)  
ref: SAT网址1  