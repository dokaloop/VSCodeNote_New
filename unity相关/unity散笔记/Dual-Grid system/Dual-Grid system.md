# Dual-Grid system
标题：Draw fewer tiles - by using a Dual-Grid system!   
作者：jess::codes  
https://www.youtube.com/watch?v=jEWFSv3ivTg

## 1 .  3x3 tile有256种组合形式。   
假设一个tile有8个邻居。  
![picture 0](images/99f95ad9c6f500a8c5373653501de9243d8a46c8eb5555bde3402ee7356d3c91.png)  
Having a unique tile for each possible combination of neighbours would require 256 tiles!    
![picture 1](images/9e4b88f9ac8e3b8cba5ac914e6b08a184fb96df80fab8f6d84578f70f959c25a.png)  
![picture 2](images/8e8fce121b2b96e11cc71b0d1a848a25b5a5b42f8cbcb452db060afd71337cc3.png)  
![picture 3](images/54a464589492022229f08544694a96cb3e0ec96ffe70fd9ad76ab56c98b3a855.png)  
![picture 4](images/897990e2981f97d371ef7a1532900807c78d576017840526417f111ab4d856fd.png)  
![picture 5](images/495606cea43d768b0439675705b498a7dd873a2132bfe4734ed5e1085f99af9f.png)  
![picture 6](images/91b775ba26b6012897846406352a2f2658e74b549f99edc7c1f027e46b1ccf56.png)  
![picture 7](images/a6f72215172845f0635537aba7e05948cdfc4474fcebbae77bea5b3746c35a57.png)  
![picture 8](images/81f5436639f9709ea401f173a9b09518a4776ef101c87cb8ab668d422b4d94e4.png)  

## 2 . 
Today let's compare 3 commonly used tilesets, and then I'd like to show you a really cool alternative called the dual-grid system.  
![picture 9](images/cc95d5cd9177021518e1a56e29fabe55b4c25c0dc901e8f41137d44dd9a47311.png)  
![picture 10](images/431ff85e99a16c7eda1903c06c03e3ed96d2d1ea8b7daf5f8ce8a3a23606ecea.png)  
### 2.1 15-piece tileset
Let's start with the classic 15-piece tileset. Although it does not contain many tiles, it has one major problem. Because the edges are drawn through the middle of each tile,   
![picture 11](images/8e5802fec91bff4891486ccd33df3590f8e4614567992f8439f935d073076cf9.png)  
by default they don't align with the world grid. This results in ambiguous tiles.  