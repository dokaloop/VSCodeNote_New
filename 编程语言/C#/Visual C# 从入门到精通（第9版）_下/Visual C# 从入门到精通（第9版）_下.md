## Visual C# 从入门到精通（第9版）_下
从第6章开始都是挑选着记录。  
### CHP3
#### 7.3
所谓“类的实例”，更通俗的说法就是“对象”。

#### 7.4.2
字段和参数重名，区分用this关键字。

如果方法从属于一个类，而且操纵的是类的某个实例的数据，就称为**实例方法**。以下练习为Point类添加实例方法DistanceTo，用于计算两点之间的距离。  

#### 7.4.3 解构对象
除了解构器，还有其他方式获取对象中的字段的值。第15章讲述了传统做法，用“属性”做同样的事情。

#### 7.5 连接静态方法和数据
省略

### CHP8
#### 8.1
C#的string实际是类类型。由于字符串大小不固定，所以更高效得策略是在程序运行时动态分配内存，而不是编译时静态分配。 

深拷贝浅拷贝与值类型引用类型有关：省略。

#### 8.2.1 空条件操作符
```C#
Circle c = null;

if (c != null) {
    Console.WriteLine($"The area of circle x if {c.Area()}");
}
//等价于：
Console.WriteLine($"The area of circle x if {c?.Area()}");
```

#### 8.2.2 使用可空类型

值类型，可空类型（可空值类型，可空引用类型），引用类型

#### 8.3 使用ref和out参数
虽然可以通过参数类修改实参引用的对象，但不可能修改实参本身（例如，无法让它引用不同的对象）。

#### 8.4 计算机内存的组织方式
所有的值类型都在栈上创建，所有的引用类型的实例（对象）都在堆上创建（虽然引用本身还是在栈上）。**可空类型实际是引用类型**，所以在堆上创建。

### CHP9
本章将讨论图和创建自己的值类型。C#支持两种值类型：**枚举**和**结构**。

#### 9.2 使用结构
第8章讲过，类定义的是引用类型，总是在堆上创建。有时类只包含极少数据，因为管理堆而产生的开销不合算。这时更好的做法是将类型定义成结构。结构是值类型，在栈上存储，能有效减少内存管理的开销（当然前提是该结构足够小）。

#### 9.2.1 声明结构
复制值类型的变量将获得值的两个拷贝。相反，复制引用类型的变量，将获得堆同一个对象的两个引用。总之，对于简单的、比较小的数据值，如复制值的效率等同于或基本等同于复制地址的效率，就使用结构。但是，较复杂的数据就要考虑使用类。这样就可选择只复制数据的地址，从而提高代码的执行效率。

### CHP10
#### 10.1.2
由于数组实例的内存动态分配，所以数组实例的大小不一定是常量；而是可以再运行时计算，如下列所示：
```C#
int size = int.Parse(Console.ReadLine());
int[] pins = new int[size];
```

#### 10.1.10 创建交错数组
练习题：用数组实现扑克牌游戏  
给4个人每个人发13张牌。  
```C#
namespace Test00
{
    enum Value { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace}

    enum Suit {Clubs, Diamonds, Hearts, Spades }

    enum Direction {North, South, East, West }

    class  PlayingCard{
        private readonly Suit suit;//花色
        private readonly Value value;//点数

        public PlayingCard(Suit s, Value v)
        {
            this.suit = s;
            this.value = v;
        }

        public override string ToString() {
            string result = $"{this.value} of {this.suit}";
            return result ;
        }

        public Suit CardSuit() {
            return this.suit ;
        }

        public Value CardValue() {
            return this.value ;
        }
    }

    class Pack {
        public const int NumSuits = 4;
        public const int CardPerSuit = 13;
        private PlayingCard[,] cardPack; //第一维指定花色，第二维指定点数
        private Random randomCardSelector = new Random(); //将利用randomCardSelector洗牌

        public Pack()//用一整副排好序的牌填充cardPack数组
        { 
            this.cardPack = new PlayingCard[NumSuits, CardPerSuit];
           
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++) {
                for (Value value = Value.Two; value <= Value.Ace; value++) {
                    this.cardPack[(int)suit,(int)value] = new PlayingCard(suit, value);
                    //数组索引只能使用整数值。suit和value变量是枚举变量。但枚举基于整型，所以可安全转型为int。
                }
            }
        }

        public PlayingCard DealCardFromPack() { 
            //该方法从一副牌中随机挑选一张牌，从牌墩中移除这张牌以防它再次被选中，最后作为方法返回值返回
            Suit suit = (Suit)randomCardSelector.Next(NumSuits);//生成0到NumSuits-1的值
            while (this.IsSuitEmpty(suit)) //检查牌墩中是否还有指定花色的牌
            { 
                suit = (Suit)randomCardSelector.Next(NumSuits);//没有这个花色，选择另一个花色
            }

            Value value = (Value)randomCardSelector.Next(CardPerSuit);
            while (this.IsCardAlreadyDealt(suit, value)) {
                value = (Value)randomCardSelector.Next(CardPerSuit);
            }

            PlayingCard card = this.cardPack[(int)suit, (int)value];
            this.cardPack[(int)suit, (int)value] = null; 
            return card;
        }

        private bool IsSuitEmpty(Suit suit) {
            bool result = true;
            for (Value value = Value.Two; value <= Value.Ace; value++) {
                if (!IsCardAlreadyDealt(suit, value)) {
                    result = false; 
                    break;
                }
            }
            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
            => (this.cardPack[(int)suit, (int)value] == null);

    }

    //将所选的牌添加到一手牌
    class Hand {
        public const int HandSize = 13;
        private PlayingCard[] cards = new PlayingCard[HandSize];
        private int playingCardCount = 0; //代码可在填充一手牌期间跟踪牌的数量

        public override string ToString()
        {
            string result = "";
            foreach (PlayingCard card in this.cards) {
                result += $"{card.ToString()}{Environment.NewLine}";//Environment.NewLine常量指定换行符
            }
            return result;
        }

        public void AddCardToHand(PlayingCard cardDealt) {
            if (this.playingCardCount >= HandSize) {
                throw new ArgumentException("Too many cards");
            }
            this.cards[this.playingCardCount] = cardDealt;
            this.playingCardCount++;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pack pack = new Pack();
                int NumHands = 4;//4手牌
                Hand[] hands = new Hand[NumHands];
                for (int handNum = 0; handNum < NumHands; handNum++) {
                    hands[handNum] = new Hand(); //new Hand()为13个牌牌

                    for (int numCards = 0; numCards < Hand.HandSize; numCards++) {
                        PlayingCard cardDealt = pack.DealCardFromPack();
                        hands[handNum].AddCardToHand(cardDealt);
                    }
                }

                for (int handNum = 0; handNum < NumHands; handNum++) {
                    Console.WriteLine($"【{(Direction)handNum}】");
                    Console.WriteLine(hands[handNum].ToString());
                }
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }

        }
    }
}
```

#### 10.1.11 访问包含值类型的数组
返回值可以是ref  
//至于方法结束后仍然存在的数据（比如数组元素）才能返回对它的引用。
e.g.   
```C#
ref Person findYoungest(){
    int youngest = 0;
    return ref family[youngest];
}
//调用：
ref var mostYouthful = ref findYoungest();
```

### CHP13
#### 13.1.7
记住，显式实现接口时，只有通过接口引用才能使用接口定义方法。  

### CHP14
#### 14.1.2
析构器只有在对象被垃圾回收时才运行。  
记住，调用析构器的过程的顺序是得不到任何保障的。

### CHP15
#### 15.3 理解属性的局限性
不能将属性ref或out参数传给方法；但可写的字段能作为ref或out参数传递。这是由于属性并不真正指向一个内存位置；相反，它指向的是一个访问器的方法，例如：  
```C#
MyMethod(ref location.X);//编译时错误
```
#### 15.4 在接口中声明属性
接口除了能定义方法，还能定义属性。  

### CHP18
#### 18.3
第3章曾用=>操作符定义表达式主体方法。为同一个操作符赋予多种含义的确容易使人混淆。虽然概念上有些相似，但表达式主体方法和Lambda表达式无论语义还是功能都截然不同。两者不要弄混了。