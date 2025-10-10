### git教程笔记
#### mentor带着时的笔记
1 . 看这个文件夹里有没有ssh  
`C:\Users\DragonPlus\.ssh`

在git bash cd定位到这个文件夹  
再用这条口令生成ssh   
ssh-keygen -t rsa -C "xxxxx@mail.com"  

再在github里添加public的那个key。 

然后在cmd里：  
![picture 4](images/39398a537d9169fb11149cbfc52bed249ea4d6b4dd82532cee913e88f0df78ec.png)  

![picture 7](images/21469613ef44979d2d2ced21af34ec8c300a4fc7c753249fb61c08f0eda637a5.png)  
![picture 5](images/8060bb125708685e10be911123ef0c5077feb88968edfedefc913affce200de0.png)  
SSH 免密登陆以及中间人攻击  
https://zhuanlan.zhihu.com/p/634497921  
那一串乱七八糟的字符串应该是github的公钥指纹。


2 . smart git的这里的设置默认和我们用的不同，要调整一下。  
![picture 0](images/36d0bed7277fd92ed0fe9aa38fce016aa44ba9f5ec4fd9287e591111f9a32e35.png)  
![picture 1](images/55efd41012765de4c698fbdd6c733a1667ee8e2ab024c0f1d9e4a8cdb275efe5.png)  



3 . https://www.youtube.com/watch?v=Aj-sZ2JWnj4&t=75s  
Version Controlling with SmartGit and Github!  
（1）  
![picture 2](images/3793d3035d0de10d4c12436bcc7e0b813d44972710a131e395bbb77189094c03.png)  
复制的是github上SSH的那个地址。  
![picture 3](images/f7a3a8191aa259f093adbf043227cf34240feabaf013d2b847e9201bcf702a77.png)  

在文件夹里添加文件：  
![picture 8](images/503cf54f2ef3bee783421d6e6c66d810f3525d131212c12685a191b0ebb5b9f1.png)  
```html
<!DOCTYPE html>
<html>
<head>
	<title>Hello World</title>
</head>
<body>

</body>
</html>
```

4 .   
先点击暂存  
再点击commit  
![picture 9](images/9c91af8ab7077fb099f95413fb6940bd9ee584bde6f94bc61b094e9cfaa77fcc.png)  
在仓库->设置里可以修改。  
![picture 10](images/280d540db37edd1abc664eba7af2620e114a1686da8dc10c5fe5c484ee743d00.png)  

选中  
![picture 11](images/73d4ffa21849bd37af894c064f2033fe07ae0d6a05a772c75cc50fa42946634e.png)  

5 . 
第一次拉取要点击这里    
![picture 12](images/9cc92092e0708316d795067cf73a05f9e090b1fd9758a7e91be5541fcfbf920a.png) 

6 . 一开始FindTM4项目默认是main分支只有一个README.md在本地仓库中，在smart git中切换到dev分支后，就有了其他文件夹。  
把这个打开可以显示这个文件夹。  
![picture 13](images/d32b70ca89a1e835343a43afca8d1c8ed4824c4584c3dc0022abdbdeaa0ce698.png)  

#### Git入门图文教程(1.5W字40图)🔥🔥--深入浅出、图文并茂【的笔记】
https://www.cnblogs.com/anding/p/16987769.html  
1 .   
头（HEAD）	HEAD类似一个“指针”，指向当前活动 分支 的 最新版本。   

HEAD：指向本地分支的指针，可以想象为当前分支的别名.分区本地和远程HEAD，本地在.git/HEAD，远程在.git/refs/remotes/origin/HEAD    

![picture 18](images/362725e5707da19635d11eb338ec49007ebc99b4554dbbc4805e5a75dac0856e.png)  


2 .  
- 项目根目录下隐藏的`.git`目录就是Git本地仓库目录了，存放了所有Git管理的信息。  
- `index`文件就是存放的暂存区内容。  
![picture 14](images/947c99940a11d04529d367384c387e3e9b8ff40da8d22fd79e8ce3432ffb71f9.png)  

3 .   
`git checkout .`、`git checkout [file]` 会清除**工作区**中未添加到暂存区的修改，用暂存区内容替换工作区。  

![picture 15](images/251a5dfdf7ebb93f8bad4466c19b165d6329aff1f1e1ab68ca061d2d3dff111e.png)  


`git checkout HEAD .`、`git checkout HEAD [file]` 会清除工作区、暂存区的修改，用HEAD指向的当前分支最新版本替换暂存区、工作区。

4 .   
在 Git 中，文件的状态通常分为三个阶段：已修改（modified）、已暂存（staged）和已提交（committed）。

以下是对这三个状态的简要说明：

- 已修改（modified）：
指的是自上次提交以来已对文件进行了更改，但尚未将这些更改添加到暂存区域。这些文件在 `git status` 命令的输出中将显示为 “modified”。
- 已暂存（staged）：
指的是已经通过 `git add` 命令将文件的内容放入暂存区域，准备下一次提交。这些文件在 `git status` 命令的输出中将显示为 “staged”。
- 已提交（committed）：
指的是已经通过 `git commit` 命令将暂存区的更改永久保存在仓库的历史记录中。这些文件在 `git status` 命令的输出中将不再出现，因为它们已经是历史记录的一部分。

`git diff` 命令可以用来查看已暂存和已修改的文件之间的差异。即查看暂存区和工作区的差异。  
如下图：可以比较不同的分支和区域。  
![picture 19](images/b505652b80f9f1cb7a2cf9ba139122400402ae6d139389703ab29e49a8c6d782.png)  


5 .   
提交commit记录：  
每一次提交（commit）就会产生一条记录：id + 描述 + 快照内容。  
**快照**：就是完整的版本文件，以对象树的结构存在仓库下`\.git\objects`目录里。   

多个提交就形成了一条时间线，每次提交完，会移动当前分支`master`、`HEAD`的“指针”位置。  
![picture 16](images/a1f0e18f32fbf137bd31774e38273ca617bb6fdc709e35d805d7772f39ae267d.png)  

`git commit --amend -m`	使用一次新的commit，替代上一次提交，会修改commit的hash值（id）  

6 .   
Git中最重要的就是**提交记录**了，其他如标签、分支、HEAD 都对提交记录的“指针”引用，指向这些提交记录，理解这一点很重要。   
![picture 17](images/0a2a2ea13b57b3c8ea7ba07b20202548b963818891fe9375ddb721e31d3fedfd.png)  

上图中：

- HEAD始终指向当前活动分支，多个分支只能有一个处于活动状态。
- 标签t1在某一个提交上创建后，就不会变了。而分支、HEAD的位置会改变。  


```
# HEAD指向当前活动分支
$ cat .git/HEAD
ref: refs/heads/main
 
# 切换到dev分支，HEAD指向了dev
$ git switch dev
Switched to branch 'dev'
$ cat .git/HEAD
ref: refs/heads/dev
```

7 . 远程用户登录    
Git服务器一般提供两种登录验证方式：

- HTTS：基于HTTPS连接，使用用户名、密码身份验证。
	- 每次都要输入用户名、密码，当然可以记住。
	- 地址形式：https://github.com/kwonganding/KWebNote.git
- SSL：采用SSL通信协议，基于公私钥进行身份验证，所以需要额外配置公私秘钥。
	- 不用每次输入用户名、密码，比较推荐的方法。
	- 地址形式：git@github.com:kwonganding/KWebNote.git

8 . fetch与pull有什么不同？  
两者都是从服务端获取更新，主要区别是`fetch`不会自动合并，不会影响当前工作区内容。

```
`git pull` = `git fetch` + `git merge`
```
![picture 20](images/d38ffdb2dcd02b433f285d0aef5d370e061738844c1c8620501222ac75962b11.png)  

9 . Branch  
新建的分支对应的是你的commit（蓝色部分）  
而不是当前工作区（红色框框）  
![picture 21](images/7a06b1275235be59a238e737c3c6ae8e0b83cd1befe09c7738ccff148b5a6ebc.png)  

使用 git checkout dev切换分支时，干了两件事：

①、HEAD指向dev：修改HEAD的“指针”引用，指向dev分支。  
②、还原工作空间：把dev分支内容还原到工作空间。  

合并dev到master，注意要先切换到master分支，然后执行`git merge dev`，把dev合并到当前分支。  

标签总是和某个commit挂钩。**如果这个commit既出现在master分支，又出现在dev分支**，那么在这两个分支上都可以看到这个标签。  

10 . 工作中的Git实践  
其他开发分支：dev-xxx，开发人员可以针对模块自己创建本地分支，开发完成后合并到dev开发分支，**然后删除本地分支**。  