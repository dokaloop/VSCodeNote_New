#! https://zhuanlan.zhihu.com/p/702569799  
[TOC]
# 从“as good, if not better than”看逻辑命题

文章简介：从英语语法难点出发复习了离散数学的逻辑命题、蕴含和高考涉及充分必要条件，学习了公考涉及肯定/否定前后件部分知识点。其实主要是在玩文字游戏的感觉（也可能不是，脑壳大。

# if not = perhaps even
问题来源：老鸦在红迪看Is URP really better than the Standard Render Pipeline?[^foot1]讨论条时，  
发现这样一个句子【After changing few settings in materials my project looked the same way it did on Built-in, if not better. 】  
机翻将其中的【,if not better】翻译为【，甚至更好。】  

### 1. 查看的第一个网站:好多回答
老鸦对此查看的第一个网站是介个[^foot2]
首先是问题：
```
A is as good as if not better than B
```
OP想知道原句究竟是A≤B 还是 A≥B的意思。  
OP认为这句话中“not better than”可能有“worse than”或者“almost the same”的含义。
>【鸦鸦说】：错！！OP把not better than和no better than弄混了。not better than只有前者的含义。   
>No better than = Just or almost the same as (something bad)[^foot3]  
>He is no better than a beggar. (He has behaved like a beggar.)  
>
>We can use 'little better than' in place of 'no better than'.  
>He is no better than a beggar.= He is little better than a beggar.  
>
>He is not any better than a beggar. (He is not better than a beggar even by a small amount.)  

OP接着认为 The word "if" also has different meanings: concession and giving a hypothetical situation. 

>【鸦鸦说】：OP的concession应该是说让步状语从句（Adverbial Clause of Concession）。  
>虽然一般是even if引导，但if也能引导，表示“尽管某种不太好的状况发生还是要去做”可以替换“although”和“though”。——这里的让步应该是主语做出了非对自己最优选项。  
>1 . If it rains，we'll still go to the picnic，although we'll bring umbrellas.    
>即使下雨，我们仍然会去野餐，尽管我们会带上伞。  
>2 . If he's busy, he'll make time for you，if only for a few minutes.  
>即使他很忙，他会为你腾出时间，即使只有几分钟。  
>3 . If you don't like spicy food，you should try this dish，even though it's a little spicy.  
>即使你不喜欢辛辣食物，你应该尝试这道菜，尽管它有点辣。

#### 1.1 网站一的回答一（from:ruakh）  
"many if not most people like summer better"   
= "many people, maybe even most people, like summer better".   
听更多的版本："Most, if not all, people like the warmth of the sun"  

#### 1.2 网站一的回答二：政治正确版
网站一的回答二(from:Ashish Singh)     
用if not better是为了不让笔者的观点改变大众认知的假设的政治性正确。  
当笔者说“A as good as, if not better, than B”时，   
虽然这句话表面是在说A==B，但其实作者内心倾向于A，这句话会有暗示A更好的感觉。  

#### 1.3 网站一的回答三：truth table版
网站一的回答三(from:Daniel R. Collins)      
这个回答还蛮有意思的哈哈哈哈是从truth table分析。  
首先将原句  
```
A is as good as if not better than B
```
转为
```
If A is not better than B, then A is as good as B
```
| Relation | A > B | !(A>B) |A=B |!(A>B)->(A=B) |
|:----:|:----:|:----:|:----:|:----:|
| A = B | F | T |T |T |
| A > B | T | F |F |T |
| A < B | F | T |F |F |

这个表格主要看后三列，层主把!(A>B)当成P，A=B当成Q。P->Q 是最后一列，最后一列中的T是当A=B或是A>B。 
>【鸦鸦说】：  
（1）The **conjunction** of p and q (read: p and q) is the statement p ∧ q  
（2）The **disjunction** of p and q (read: p or q) is the statement p ∨ q  
（3）The **implication** p → q (read: p implies q, or if p then q).  
The statement p is called the hypothesis of the implication, and the statement q is called the conclusion of the implication.  
(4)The **biconditional** or **double implication** p ↔ q (read: p if and only if q)

| p | q | p ∧ q |p ∨ q |p → q |p ↔ q|
|:----:|:----:|:----:|:----:|:----:|:----:|
| 0 | 0 | 0 |0 |1 |1 |
| 0 | 1 | 0 |1 |1 |0 |
| 1 | 0 | 0 |1 |0 |0 |
| 1 | 1 | 1 |1 |1 |1 |

主要看倒数第二列  

倒数第二列是p → q，当前件为假，整个命题为真，这一点我老是理解不了。它其实是数学上一个概念叫  
vacuous truth，除了看wiki正文也可以看看wiki里面的参考链接。  
https://en.wikipedia.org/wiki/Vacuous_truth


#### 1.4 网站一的回答四：先满足条件版   
网站一的回答四(from:Sven Yargs)   
(1) . 答主认为 "as good as if not better than"  
逻辑上的含义是：   
"at least equal to but possibly greater than"，  
符号上的含义是：≥。  
数学家和逻辑学家自然接受“if”是premise。
不过有些人可能会用错，和逻辑上的冲突，我们也不应该苛求他们。因为他们用了传统觉得if是“though”或“but”之意。

(2) . 举例在口语中if的使用有 "though" 或 "but"之意 ：

> And a right good [cricket] club we had, though Lord's would scoff at us, and "The Oval" might smile at our style ; but didn't we just smash the Brazen-nose first eleven, and send them back in their four-in-hand to Oxford sadder if wiser men!
 
//上面那句话鸦也没读懂，其实看懂最后四个词就行。  
答主说：Jack the Shepherd is not saying here that the Brazen-nose first eleven returned to Oxford sadder only if they first satisfied the condition of being wiser,   
//看“satisfied”这词，是不是有“sufficiency and necessity”(充分性和必要性)的sufficiency那味了？  

答主说：; to the contrary, he is saying that they returned sadder though [or but] wiser.   
(鸦翻：恰恰相反，他是在说，它们回来虽然更伤心，但是更聪明了。)  
In this construction, wiser is a counterpoint to sadder—a benefit to set against the disadvantage of being sadder—not a condition precedent to achieving sadness.  
(鸦翻：在这种结构中，wiser和sadder是同地位对应物，wiser是在being sadder这种劣势下获得的的补偿好处，wiser不是实现sadness的先决条件。)   

(3) . 
```
A is as good as if not better than B
```
将 if 转为 "though" or "but"
```
If A is not better than B, then A is as good as B
```
这句话的意思是 "A is equal to B, but it is not under any circumstances greater than B."  
非数学家和逻辑学家可能这么理解。

#### 1.5 蕴含的补充
对1.3部分的延伸  
1 . 在公考中的口诀解释：  
(1)前件为假，命题为真。  
后边为真，命题为真。  
[^foot6]中有讲，但是他明显没解释清楚。为什么两者矛盾，我可以继续问下去。
![](https://pic4.zhimg.com/80/v2-a43ad371e46995337dc0b3edaabd47d5.png)
¬A ∨ B 当A为假，¬A为真。  
只要满足¬A为真或B为真就行，就是说：两个之中有一个为真就行。  
| p | q |p → q |
|:----:|:----:|:----:|
| 0 | 0 | 1 |
| 0 | 1 | 1 |
| 1 | 0 | 0 |
| 1 | 1 | 1 |

只看p → q为真的，也就是第1，2，4,行。  
满足：前件为假，命题为真。  
后边为真，命题为真。 

（2）否后必否前  
肯前必肯后  
否前后不定  
肯后前不定  
| p | q |p → q |
|:----:|:----:|:----:|
| 0 | 0 | 1 |
| 0 | 1 | 1 |
| 1 | 0 | 0 |
| 1 | 1 | 1 |

（否后必否前）成立的前提条件就是（命题是真的），所以只看三行。
只看p → q为真的，也就是第1，2，4,行。  

2 . 以前玩的游戏的一个问题
![](https://pic4.zhimg.com/80/v2-9f2c367a966884885f1063f9d9450d5d.png)
![](https://pic4.zhimg.com/80/v2-9e9e89d9daecbd015652339559c0fb19.png)  
鸦鸦的做法：
找那张会出错卡片（语言贫瘠的鸦）
![](https://pic4.zhimg.com/80/v2-466d339eaae52136f65037e2364cdb75.png)
期喵对这个方法的解说：  
重新组织语言的话  
命题是：对于任意一张卡片，一面是方→另一面是奇数  
我如果想证明，会利用反证法  
如果存在一张卡片，一面是方，另一面不是奇数，则证明命题不成立   

期喵之前的做法：验证逆反命题
truth table  
![](https://pic4.zhimg.com/80/v2-5ad9df8bbe247488b7ae0ef5d40f8f2f.png)  
看最后两竖列。   
整个命题错的话，需要（条件对 且 结果错）  
所以验证“条件对”【正面方】看反面是否为“结果错”，和“结果错”【正面2】看反面是否为“条件对”

3 . 一些参考  
（1）好像是国外某大学的教材关于逻辑这一块内容的（英文）[^foot9]  
（2）关于否后必否前的公考例题解说：[^foot12]  
（3）高考：充分条件假言判断的逻辑关系（相关举例推理的有效式）[^foot13]  
//上面高考和国外教材那两个网站里真值表有些有错，其他网站的真值表没仔细看都注意一下吧。


#### 1.6 充分性必要性的补充
在1.4的回答中，答主认为：   
if A, then B. 中A是需要被先满足的，才能发生后面的B。【这样想不知道严不严谨】  
由这里我想到了充分性和必要性。那么我们来复习一下吧>w<  
P->Q  
The statement P are called premise, and the statement Q is called conclusion.  
所以简写为P，不知道结论简写为Q是因为什么？  
![](https://pic4.zhimg.com/80/v2-6204b6dda815abfbfba3f5ac71eb7fc3.png)
![](https://pic4.zhimg.com/80/v2-a05d4bbfc1b3ecbf008a05580877d134.png)
![](https://pic4.zhimg.com/80/v2-2e483fc5a03455b0b001d3bfe9591855.png)
![](https://pic4.zhimg.com/80/v2-e90b02d3054ba50cdd1a740d7aaefefa.png)

以上的参考来自于：  
1 . ![小红书文氏图](https://pic4.zhimg.com/80/v2-b3aaf0130da8c65e7311ef803a8e6e1b.png)  
2 . [^foot4] 知乎文氏图   
3 . [^foot5] 陈越姥姥泡面说  
4 . 公考题：  
（1）[^foot6]当警察题：视频 的 15：41   
（2）[^foot7]欧洲杯比赛：视频 的 06：07   
5 . [^foot8]高中题：视频 的 11：26
![](https://pic4.zhimg.com/80/v2-358788624522cb15ef6c1d82ae8d3c12.png)  
同时讲了数轴上，P->Q，P在Q里面。  
6 . 英文维基百科Necessity_and_sufficiency[^foot10]  
7 . 充分必要条件的中文wiki[^foot11]  

### 2.第二个网站：加不加than
何时用if not better何时用if not better than 网址：[^foot14]  
例题：  
John plays football as well as ,if _____, David  
a. not better than  
b. not better  
这道题选A。因为和结尾的David做比较所以需要“than”。如果要不用"than"的话，要先提到David。例如：David plays football well, but John plays just as well, if not better.  
还有这句话The slower drive will do just as well if not better. 能读通，是因为它暗示我们前面已说了the faster drive。  

### 3.第三个网站：是but还是逻辑家
这个网站讨论的其实跟1.4差不多，OP分不清if not better何时把if看成but，何时按数学家逻辑家一样看成perhaps even better.  
网址：[^foot15]  
（1）  
```
He appeared very happy, if not exuberant, at her arrival.
```
有FumbleFingers回答说：we can choose for ourselves how to read it. In both cases he's not actually exuberant. OP:upbeat - he's nearly exuberant. You:downbeat - he's only very happy.  
>鸦鸦说：我不是很认同上面这个评论区里的回答。因为在句式【if非超高兴，那么高兴。】句式中，如果if后的条件为真，那么只是单纯高兴。如果if后的条件为假，是可以超高兴的（exuberant）。他说两种都不可能是真的超高兴是错的。   
可以看这句话：“如果他没有1000元，他也有800元。”    
这个人可以有1000元，也可以只有800元。  
如果改成“如果他没有1000元，他起码也有800元。”  
这个人有800<=x<=1000元。

（2）LynGuistics回答说：
```
I feel good if not very mobile.
```
如何分辨是哪一种情况看not依附于哪个词：  
【1】 [if] [not very mobile]  
这种情况 [if] 的意思是 'although' 或 'albeit'  
【2】 [if not] [very mobile]   
这种情况[if not] 的意思是 'and perhaps even' 或 'almost'.
>鸦鸦说：是不是只有第【2】情况才能把if提前，变成蕴含句式。A → B  
if not very mobile, then I feel good. 

### 4.第四个网站：探究if not这样简写的起源
网址：[^foot16]  
（1）Damkerng T.的回答  
```
If N is not so great as Z (or any quantity > Y), it is = Y
```
这样说太冗长了，所以英语简写成
```
N = Y if N ≠ Z  
或  
N is Y, if not Z
```
（2）Jason Patterson和Jay的回答融合
```
There are millions, if not billions, of bacteria on every inch of our skin.
```
是说
```
If there are not billions, there are certainly millions ...
```
这句话先说它可能是一个比较大的事物，如果不是，那么它就是一个小的事物。  
但这样可能会让人失望，本来可能有这么多，结果只有这么点。所以把小的事物提前。  

>鸦鸦说：感觉这种说法像是在数轴上millions <= x <= billions的不确定x是哪一个点，所以这么说。

### 5.总结
"B,if not A"这句话是离散数学中的蕴涵(implication)，  
更数学的写法是if not A, then B.  
根据1.3中的真值表可知，当前件为假，命题整体为真（vacuous truth）。  
在英语口语书写表达中，A通常是一个更优秀的数量值或抽象概念。  

在语言表述中，类似的句式因为多加一些词少加一些词的细微差别可以表示：  
（英文我非母语者体会不出细微差别所以用中文举例。）  
（1）非A即B (二者取其一)  e.g. 他如果没有1000元，就有800元。（只有1000元，800元两种可能性结果）  
（2）表示一个区间A <= x <= B   e.g.他就算没有1000元，起码也有800元。（800 <= x <= 1000）


[^foot1]:https://www.reddit.com/r/Unity3D/comments/12o5qzw/is_urp_really_better_than_the_standard_render/

[^foot2]:https://english.stackexchange.com/questions/293708/a-is-as-good-as-if-not-better-than-b

[^foot3]:https://english.stackexchange.com/questions/290509/no-better-than-vs-not-better-than

[^foot4]:https://www.zhihu.com/question/410611160/answer/3436158511

[^foot5]:https://www.zhihu.com/question/644235475/answer/3403456518

[^foot6]:https://www.bilibili.com/video/BV1Pt421a7pR

[^foot7]:https://www.bilibili.com/video/BV1Ra4y1y7ug

[^foot8]:https://www.bilibili.com/video/BV18W4y1v7PG

[^foot9]:https://www.math.uvic.ca/faculty/gmacgill/guide/Logic.pdf

[^foot10]:https://en.wikipedia.org/wiki/Necessity_and_sufficiency 

[^foot11]:https://zh.wikipedia.org/wiki/%E5%85%85%E5%88%86%E5%BF%85%E8%A6%81%E6%9D%A1%E4%BB%B6

[^foot12]:https://baijiahao.baidu.com/s?id=1792649903107462505&wfr=spider&for=pc

[^foot13]:http://www.xxwdw.com/news-id-5835.html

[^foot14]:https://forum.wordreference.com/threads/if-not-better-if-not-better-than.3027204/

[^foot15]:https://english.stackexchange.com/questions/58646/usage-of-if-and-if-not-to-mean-and-perhaps-even-also

[^foot16]:https://ell.stackexchange.com/questions/38290/how-does-if-not-mean-perhaps-even