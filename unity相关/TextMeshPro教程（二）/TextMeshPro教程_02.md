## TextmeshPro教程_02
### 七 . Display button prompts with sprites in TextMesh Pro
In this tutorial, I will show you how you can add button prompts to your text boxes based on your input system.  
![picture 0](images/44857703fb28348ecd4ef0e98ac319403153759d2bf59077f2e274f1e311b3f3.png)  

#### 1 . 做成spritesheet
对于这个网址：https://codeshack.io/images-sprite-sheet-generator/  
把图片拽过来：  
点击这个生成sprite sheet：  
![picture 1](images/2f20c94d72493f2ff514ed01195e479dc7bf001e60a9b27440b8e383d2dccecb.png)  
![picture 2](images/7cada04ce1448ef531217c606294ef0aa205c6ea75a5ef763ef87c9d2c408b13.png)  

#### 2 . 处理图片  
![picture 3](images/0b9f4c481f3bd00a86673f00445e34fc9eb7769eb464ebb51c7df96b5efa6b99.png)  
![picture 4](images/e10386857cb2e176ef1ad52374b3405b4f5615a424eb9bda1a4e7330f4d6316e.png)  

再生成sprite asset  
![picture 5](images/64ce00ebeb3bb057f5005ec10033578265fe6cbcf45e2a334e9a7a401153c50d.png)  

在sprite asset里面改名字：  
![picture 6](images/fa39b5d65fa0b8c00c8f2b973a347be586adf7b0667740c31b888f73b700e5b3.png)  

![picture 7](images/2262e78ea81369e0faeeb071fad437732cd6e6e144f5aa90b01a550698bcdff8.png)  

把它们两个移动到tmp的sprite assets文件夹中：  
![picture 8](images/32fb49c3e46da135549452f54c8ec3cf88c9cf89df259166497d4ae80d8e2913.png)  

#### 3 .   
First,let's see how to achieve it with the old and static input system.  
![picture 9](images/8fa3866d4c305ba66351bf6805dfd0f4dce611cde4694723b057cd4a6482ed6e.png)  
```
Press<sprite="spritesheet_xbox" name="Button_A"> to pick up your magic wand.  
```
![picture 10](images/7be6e7c44f40f31a12daf8e48bff14ff14aec7077f62ebcf73f66c3f798ce573.png)  

时间轴2:44有讲input system的事情：  
她推荐的input system视频：  
![picture 11](images/f34478bd6c5bb3bab32204ee5e9ac3f345f570cf5626bf3f4b9203d087d536c8.png)  
