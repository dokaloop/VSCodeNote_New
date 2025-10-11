## TS_不会的_待查

1 .  
![picture 0](images/0f29c291c1cdfd05d6cef13777f6e3545a59d44cf17f92d603773516a70bccb1.png)  

2 . https://zhuanlan.zhihu.com/p/471293903  
```ts
interface Named {
  name: string;
}

interface Named2 {
  name: string;
  location: string;
}
let y: Named2 = { name: 'Alice', location: 'Seattle' };

interface Named3 {
  name: string;
  location3: string;
}
let x: Named3 = y as Named as Named3;
```
子类型1 转化成 子类型2 应该怎么做？   
用父类型做中转:   
相当于：  
```ts
let x: Named3 = <Named3><Named>y;
```
那两个类型间转化，每次都要找个父类型
如果两个类型间没有明确的父类型，还要新建个父类型？这样太麻烦了  
unknow 是所有类型的父类型:
```ts
A as unknow as B
```

3 .  
![picture 1](images/f82f223d879669d715d8b6128cc1733cf651e67c941b57acb425bf7674ec3063.png)  
![picture 2](images/1e75f4ac80f8bfe75f78b5ede77bfa54bca0884480a68a9b38be3e7f14cf366b.png)  

4 .  
![picture 3](images/043659114ff44b557fee5e99e4c5a5342ea044a6b1c237a694632acf1d531bd6.png)  

5 .  
![picture 4](images/34e699c9da5d88f8801cc9a2ff0b73534352bd1cea9eb78bdc71fb733ad8e2bd.png)  

![picture 5](images/2cfe50ed05d0457029281bb8ec795d52b7292aa002791cc3fea7fa5dfb7c8306.png)  

![picture 6](images/bbde93dc5c6b8cf2bd79b025c6927ea62433b898c2f17a31f4c48fa47d53587b.png)  

5 .  
![picture 7](images/72de494c0573e47cef24ef19a1f798577ecf1fec01308bb642a85361c3acaae6.png)  

6 .  
![picture 8](images/e345b3439d03c213a3ac313c8979b464246c85d38b5a4c4c6d62ffeadcdefe7e.png)  
