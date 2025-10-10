## GDScript Callables & Lambdas
### 视频一：GDScript Callables & Lambdas Deep Dive | Godot 4 Tutorial
https://www.youtube.com/watch?v=56I72m5wDj4   
 
#### 0 . 视频大致内容
1 . GDScript / Godot 4 "Callables"（AKA First Class functions）  
2 . Lambda functions (AKA anonymous functions)  
3 . Practical scenarios (signals and more!)  

#### 1 . “函数名字”是callable
![picture 0](images/ccea87c8cc8c17d19dc0fc614327ca5ddd2060fe496e592fac2f45415bee3fb1.png)  
“函数名字”是callable。  
What we're printing out here is not a string, but the callable. If we were to call the function, call the callable.  
![picture 1](images/8894e1df1f2f5c740650f12eab14a3a3df52119bec175e7a0b7518994dd26a54.png)  
输出：  
```
true  
```

#### 2 . callable是object可以被赋值给variable  
Callables in Godot are just like any other object in Godot. e.g. Vector3 , Node3D. You'll notice that it's highlighting these green, just like a highlights, callable green.  
That's because the Callable is an object in Godot.  
![picture 2](images/153c95fc109931d8f3a01dc1349dc4afb9c4aefd78d770ba1db2ebb771b4083a.png)  
That's what the term first-class functions means is that: Functions are just objects in Godot just like anything else, just like a vector3, or a string, or a node.  

所以我们可以assign our functions to variables.   
![picture 3](images/8178129c91256bbb7263a926e6868db1b39f803dc990e2e881a318666cfe946d.png)  

#### 3 . syntactic sugar
The way that 'Callables' work in Godot is that : normally, if you want to call a callable, you actually have to call this `call` function.  
![picture 5](images/3d41b070309ea362d7e2f630895b447b775441e1540d1a61110ae8e1996454db.png)  
Godot has some kind of helper **syntactic sugar** to make this look like regular function. 但是这样也行：  
![picture 6](images/7fa131492221ffdbb3b3a8fbba5cb358c0a0123ef04df2e448d236393c4d413f.png)  

#### 4 . 让func作为参数传给func
But where callables really come in handy is with functions that take other functions as arguments .   
![picture 7](images/afc0e726caf8794d8f494cb48417644721ccba557b70dbf2687a9a6dc40f08a5.png)  
【输出】：  
```
2575
```

#### 5 . 当callable有参数时用func(): ,匿名函数 
![picture 8](images/a446af709b10cfdd1d3a9309550097e7b7f5a89da95a21126be60175451e655b.png)  
We've got this glaring problem here which is that we only can pass in functions that don't take any arguments.   
![picture 9](images/15beb04dfbe94b90686d3ea66e39630e4e48ae44ce0621e35e00ceb49f38ec2e.png)  
这样就行了：  
![picture 10](images/96b3a8c0fce8c20f46ea87a372dc32b93bf5c2eef6efd7c1b59a2e6b3da8055e.png)  

但是这样很麻烦，this is where **lambda functions** come in .  
Instead of `create_jim_greeting`, creating this an argument, we're going to type `func()`:  
![picture 11](images/d05369bb9b28118f8dbb3f1419c43f6ff6986b5bea539025e6bced739a823d41.png)  
一开始不是说callable后面不能加括号？  
但是我们没有calling the function. We're defining a new function . 

`func(): create_greeting("jim")` 等价于 `create_jim_greeting` 。It's the exact same thing. It's just anonymous. It doesn't have a name.   
![picture 12](images/3ab3f52817f95de807331f8e0da90bd1848f46d0c2a40804d28bf1a7850abc78.png)  

代码：  
![picture 13](images/2bdde8e133cb5b6b819ee2fd77d7815a1bb32333a74b7cc0ff65d6113772bff2.png)  
输出：  
```
hello jim!
```

![picture 14](images/b9f93e7ff10144f8b730c0a84884023c7e6d92db04c9e0fc951d7c7d506ff026.png)  

#### 6 . callables in conjunction with signals
How we use callables in conjunction with signals .   
例子1：  
代码：    
![picture 15](images/6cf38c9f7e87a3571222fb09ac82d5de194a37108f4950a70c85dadb0bf8a0f5.png)  
![picture 16](images/51eec7fa36fdfc9ef0ee27c7be03d471d3ea0dca64d5bb962414bef3399516bc.png)  
输出：  
每隔1s蹦一个输出。  
![picture 17](images/be9a0b0b3077262dc5f4692950e130b04f8aaa174d980ee14b2a8f20fc270529.png)  

例子2：包装成function  
代码：  
![picture 18](images/96e7e41c1323a09bfedba3f8a1d3d6f63ca0c1e953d6b47d73806d0e65a20d1a.png)  
![picture 19](images/cf1aea01bc1010e6f4f91fa7dcd5c1125ef8f3404195aa34fec63deb3f9dd0ed.png)  
![picture 20](images/cc93d2498c9a0c87bdbce576d056c5e83a220644a40f5bf90235c098e67b392e.png)  

例子3：包装成script  
new一个script  
![picture 21](images/a9df4cef8767b6bf67254eb7419919f9d2c71ec1d16227594c26112e90a6d9f2.png)  
![picture 22](images/4e7be0a41187229e0758cc57efc5a6cdc91f795c0ba2873e4899ba0f8b63e107.png)  
![picture 24](images/8154943e8a2fd4449d781e3710698db3d6388fe63f329c97a0cf08abcff035d7.png)  
像unity的invokeRepeating()  

#### 7 . Using callables to basically modify arrays.  
![picture 25](images/33ea9176a4edd8cd6b573d6ea6c665bd4df4a2ffec6663019f1115b02014b41c.png)  

例子1：  
代码：  
![picture 26](images/29a02284f76b75dc3c84f026e2fde2404201f9380eeb2089a96e6d2c82370204.png)  
![picture 27](images/2741a4ae25b34f5f0d5daa696bd7ab5882ced1cc7de8e193051ea7e011fa0ca7.png)  
![picture 28](images/908b85f17374dd17415efd0a0dad30182668237eb936ca307d18cbd06dd9d91e.png)  
输出：  
![picture 29](images/d8ec25658fd2a761d7d944094fa75c35d7080c9f49785b371eaa28161a4a5772.png)  

例子2：  
![picture 27](images/2741a4ae25b34f5f0d5daa696bd7ab5882ced1cc7de8e193051ea7e011fa0ca7.png)  
![picture 30](images/73e609f1723eb5f1e1122ef7817f9e1b673d693a5da816dffa57626d020e1ead.png)  

例子3：  
![picture 31](images/b05a057766a488bbfc011a5271f4b920d5c99218b5d9ca18207aa0602b5ba4c0.png)  
![picture 27](images/2741a4ae25b34f5f0d5daa696bd7ab5882ced1cc7de8e193051ea7e011fa0ca7.png)  
![picture 32](images/4fd8ae34ba10105cb42b5a3bdfe2d4cff7c42c839ae607b7975fa770b6b2941d.png)  

### 视频二：Greatly Improve Workflow With Lambda Functions | Godot Tutorial
https://www.youtube.com/watch?v=slinXW6qzm0&t=1374s

#### 0. 目录  
![picture 33](images/aac0fbd21b1505b62e37951385bcacc44e92a20a14239c5ddb7a99d54303c8c0.png)  

#### 1 . What are lambda functions?
Lambda functions are functions but they aren't functions that are declared in the global class scope.  
In other words, it's like a oneline method that maybe needed at a certain spot within the script.  
![picture 34](images/8225c7561a372adecc0bc072206b09d144127201366ce89692a09b9f09c1e42e.png)  

But the real magic of Lambda functions are when we make them into reusable undefined functions. This is done through callable since lambdas are used to create callables.   

Creating a variable which basically just stores a function . We can then easily call this and use this function all throughout the script.  
![picture 35](images/a84e4594cb83148f3277f77bb100876072745e0724bc0fe0a3577165b10a33f8.png)  

But we can then take this a step further. So maybe you have a calculate function which could call for different operations. Those different operations can be stored within callables and easily pass through to the calculate function by just passing that callable variable.  
![picture 36](images/18d10ff037750a9f70aba32facef3ae3c087b51ca3e1cc1f53fec3354acaa092.png)  

#### 2 . Why do we use lambda functions?  
（1）  
![picture 37](images/4212a83eccd8adf021876b2d898ed41621f28fe1ef51121c03a0648a1ac7c7af.png)  

【1】 it's much quicker to create a lambda function for a specific need than an entire function  
【2】 it also saves clutter in our script and in the class's scene tree as the Lambda functions won't exist at the class level like other functions.  
【3】 The big one. It'll help make our script more modular

（2）lambda functions are also really going to help you to keep your scripts organized and keep different methods and information in one place as we will learn about creating `local lambdas` .  

#### 3 .  Basics of Callables/Lambdas  
![picture 38](images/288e9755a0b62173093810f6b821f8e740d5aced7ecfda46e9a0085244d99a68.png)  
【鸦提示】：.call的括号里也能写参数。第一个教程没有提到。  
![picture 39](images/fd8ab6325041224761981e5b9f1ba42c67fc4d3e11c11a5b27df14ddd6537b6b.png)  

#### 4 . Lambda Functions Tutorial - Within Parameters 
![picture 40](images/4d677de8399916bd97b37a19975bb7dfab3beb47466bf7eb5cbfedf537755232.png)  

wrap挺多次的，感觉是两次 

#### 5 . Lambda Functions Tutorial - Using With Other Functions 

We think of lambda functions as one line.  
I hope that you're not thinking of it just as being one line . 
Because whenever it's done within a callable here, it can actually be as long as you want it to be.  

![picture 41](images/4379e98d7be73687bab1fc0b93d9bbe513ecad14557318626de83d78ff65d183.png)  

它这的逻辑有点复杂了：    
![picture 42](images/7e30ee2cdc2668f3876725b2dfabc076d25d31065f6a34d9a53df76bf7aae0e5.png)  
可以直接改成：  
```py
if player_health + amount > player_max_health
```
#### 6 . Lambda Functions Tutorial - Local Lambdas

![picture 43](images/48d0ac3eba742c1316671b8a65a980aeb1169ba08fd8934ff26e52df41a748e2.png)  

Local Lambdas就是在function内部定义的lambda。  