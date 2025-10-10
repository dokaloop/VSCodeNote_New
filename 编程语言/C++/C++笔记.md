### 1 . 调试：  
step into, step over, step out都是相对函数来说的。  
next line是指一行一行的走。  
### 2 . 在 C++ 中子类继承和调用父类的构造函数方法  
- 如果子类没有定义构造方法，则调用父类的无参数的构造方法。
- 如果子类定义了构造方法，不论是无参数还是带参数，在创建子类的对象的时候,首先执行父类无参数的构造方法，然后执行自己的构造方法。
  
### 3 . 拷贝构造的概念【深拷贝，浅拷贝】  
教程代码可以参考cherno和菜鸟教程。  

### 4 . 笙笙左值那节课提到。
move完是左右杂交种。  
一些函数：（1）decltype可以看类型或者表达式。  
（2）decay  
```
（3）void func(int &&a){  
         print(__PRETTY_FUNCTION__);  
}  
```
(4)
```
struct S{
    void getA(){}
}

S().getA();
```
---
小彭老师说：  
S().getA(); 等价于：  
S s = S();
s.get A();  
相当于C#里的new S()  
cpp里不需要new，new了就变成S*而不是S了。  
new S().getA();去掉new  

---
struct:
```C++
struct Books
{
   char  title[50];
   char  author[50];
   char  subject[100];
   int   book_id;
};
void printBook( Books book );//可以
//-----------------------------------------------//
void printBook( struct Books book );// 放在前面得这样。
struct Books
{
   char  title[50];
   char  author[50];
   char  subject[100];
   int   book_id;
};
```
（5）鸦鸦：为什么右值引用是两个&，是引用的引用么？  
小彭老师：并不是引用的引用。因为CPP98已经有左值引用占据&了，&&是CPP他爸随便挑的，CPP他爸很喜欢误导人是这样的。&&是一个符号，在CPP编译器眼里，不能写& &，不能有空格，必须紧挨着。他这样选可能是因为：之气那已经有“逻辑与”运算，他希望复用编译器现有的符号解析器。CPP之父是这样的，喜欢同一个关键字多个用途。  


### 5 . 形参实参值传递引用传递
（1）  
【1】实参：真实传给函数的参数  
【2】形参：形参是指函数名括号中的变量，因为形参只有在函数被调用的过程中才实例化（分配内存单元）。形参当函数调用完成之后就自动销毁了。因此形式参数只在函数中有效。  
（2）  
【1】值传递：形参的变化不会影响到实参的值。  
【2】地址传递：影响  
void swap2(int *m, int *n);  
swap2(&a,&b);  
【3】引用传递：影响  
void f(int &a);  
f(b);  
期喵群里的补充：下面这些开辟不开辟内存空间也都是扯犊子，真谈具体实现，编译器有一堆优化和黑科技。按值就是按值，复制了一份。按地址就是传进来地址。按引用就是直接操作原对象。准确来说也不叫地址传递，叫指针传递。指针不等于地址。  


### 6 . 脱去外衣语法
**【鸦鸦】**：C++有没有把单个字符的外衣脱去了的语法，比如
`'*'`脱去外衣变成乘号。  
**【小彭老师】**：需要switch case的。你这种思维适合写python。可以eval(x+op+y)其中op是`'*'`。  
因为CPP不是解释执行的语言，运行时已经没有编译器了。`'*'`实际上是一个数字，ascii码，48，这样的。  

### 7 . template  
BV1Ve4y1Y75L  
模板是C++泛型编程的一种应用，一共提供了两种模板的机制：（1）function template（函数模板）（2）class template（类模板）

（1）function template  
template不可直接使用，它只是一个框架。模板的通用并不是万能的。  
```C++
#include<bits/stdc++.h>
using namespace std;

template<typename T>
T Add(const T& a, const T& b)
{
    return a+b;
}
//返回值类型和形参的类型不具体指定

template<class T>
void bubbleSort(T a[], int len)
{
    for(int i = 0; i < len-1; i++)
    {
        for(int j = len-1; j>i; j--)
        {
            if(a[j]<a[j-1])
                swap(a[j],a[j-1]);
        }
    }
}

int main()
{
    int a = 5, b = 3;
    double c = 2.2, d = 3.3;
    int result = Add<int>(a,b);//这里要写上T的类型
    cout<<"5+3="<<result<<endl;
    double result2 = Add<double>(c,d);//这里要写上T的类型
    cout<<"2.2+3.3="<<result2<<endl;

///////

    int arr[5] = {10,100,50,20,80};
    int len = sizeof(arr)/sizeof(arr[0]);

    bubbleSort<int>(arr,len);//这里要写上T的类型
    cout<<"Bubble sort: "<<endl;
    for(auto x:arr)
        cout<<x<<" ";
            return 0;
}
```
BV1tV4y1g71o  
（2）类模板  
什么时候用类模板？比如我们有两个或多个类他们的功能是相同的，只是数据类型不同，这时候就需要考虑用class template 。  
```C++
#include<bits/stdc++.h>
using namespace std;

/*
template<class T>
class className
{
    private:
        T var;
    ... ... ...
    public:
        T functionName(T arg);
    ... ... ...
}
*/

template<class T>
class Number
{
public:
    Number(T n1,T n2):num1(n1),num2(n2) {}
    T add();
    T subtract();
    T multiply()
    {
        return num1*num2;
    }
    T divide()
    {
        return num1/num2;
    }

    void display()
    {
        cout<<"Numbers: "<<num1<<" and "<<num2<<"."<<endl;
        cout<<"add result: "<<add()<<endl;
        cout<<"subtract result: "<<subtract()<<endl;
        cout<<"multiply result: "<<multiply()<<endl;
        cout<<"fivide result: "<<divide()<<endl;
    }

private:
    T num1;
    T num2;
};

template<class T>
T Number<T>::add()
{
    return num1+num2;
}

template<class T>
T Number<T>::subtract()
{
    return num1-num2;
}

template<class T, class U, class N = char>//模板默认参数N的类型是char
class ComplexClass
{
public:
    ComplexClass(T v1, U v2, N v3):var1(v1),var2(v2),var3(v3) {}
    void print()
    {
        cout<<"var1 = "<<var1<<endl;
        cout<<"var2 = "<<var2<<endl;
        cout<<"var3 = "<<var3<<endl;
    }
private:
    T var1;
    U var2;
    N var3;
};

int main()
{
    Number<int> intNum(3,5);
    Number<float> floatNum(3.14,5.27);
    Number<unsigned int>charNum(100,10);

    intNum.display();
    floatNum.display();
    charNum.display();

    cout<<"Complex Class"<<endl;
    ComplexClass<int, double> cc(100,3.14,'a');//只用实例前两个类型
    cc.print();

    return 0;

}
```

### 8 . CPP的std::sort函数  
```C++
//https://en.cppreference.com/w/cpp/algorithm/sort
template< class RandomIt, class Compare >
void sort( RandomIt first, RandomIt last, Compare comp );
//The signature of the comparison function should be equivalent to the following:
bool cmp(const Type1& a, const Type2& b);
```

```C++
 std::array<int, 10> s{5, 7, 4, 2, 8, 6, 1, 9, 0, 3};
 std::sort(s.begin(), s.end(), std::greater<int>());
```
`greater<int>`是C++标准库中定义的一个函数对象（也称仿函数）模板。`greater<int>()`则是创建了一个`greater<int>`类型的临时对象那个。它通过重载operator()运算符来实现比较功能。函数返回布尔值。

你还可以自定义比较器:
```C++
#include<bits/stdc++.h>
using namespace std;

//自定义比较器，比较两个整数的绝对值大小
struct AbsoluteComparator{
    bool operator()(int a, int b){
    return abs(a)<abs(b);
    }
};

int main(){
    //自定义比较器的集合示例
    set<int,AbsoluteComparator>absSet={5,-2,8,-1,4};
    for(int num:absSet){
        cout<<num<<" ";
    }
    cout<<endl;
}
```
### 9 . 仿函数  
```C++
#include<bits/stdc++.h>
using namespace std;

class Greater{
public:
    bool operator()(const int& x, const int& y){
        return x>y;
    }
};

int main(){
    Greater com;//com是一个对象，它可以像函数一样去使用
    cout<<com(10,100)<<endl;//false->0

    return 0;
}
```
上面就是一个仿函数。  
在priority_queue中就使用了仿函数。  
在C++中，priority_queue模板类定义在`<queue>`头文件中，可以通过指定元素类型和比较函数来创建不同类型的优先队列。比较函数用于确定元素的优先级，可以是**函数指针、函数对象或Lambda表达式**。

### 10 . lambda表达式(C++)  
BV1fG41157Ew  
lambda表达式（Lambda Expressions），即匿名函数，有些地方也叫闭包（Closure）。字面意思就是没有名字的函数，它可以很方便的放我们随手定义函数，并把函数当做参数给别的函数调用。这样的代码写起来很简洁，读起来也直观，不用你在代码中跳来跳去。  
```C++
#include <bits/stdc++.h>

using namespace std;

int main()
{
    vector<int>vec{0,11,3,19,22,7,1,5};

    auto f = [](int a, int b)
    {
        return a < b;
    };

    sort(vec.begin(),vec.end(),f);

}
```
下面展示了Lambda的基本语法形式。  
```C++
[OuterVar](int x, int y) -> int {
    return OuterVar + x + y;
}
```
首先你要写一个方括号，里面有一些捕获变量或者为空。然后是括号包起来的参数列表。然后是箭头跟着返回类型。然后是函数的主体。  
我们再举一个具体的例子。  
```C++
    auto f = [](int a, int b)->int
    {
        return a + b;
    };

    cout<<f(1,2)<<endl;
```
方括号里面是空的，表示不捕获外围的变量。然后我们把这个匿名函数赋给了f，并且用auto让编译器自行判断f的类型。这里lambda表达式的返回值是可以忽略的，因为编译器可以自行判断它的类型。  

---
下面我们来讲变量捕获（capture clause），就是方括号的部分。这个功能的作用是，让我们的匿名函数可以访问，甚至修改函数外部的变量。
```C++
    int N = 100, M = 10;

    auto g = [N, &M](int i)
    {
        M = 20;
        return N * i;
    };
    cout<<g(10)<<endl; //打印1000
    cout<<M<<endl; //打印20
```
如果在捕获语句中只写引用符号`[&]`那么就会按照引用捕获所有的封闭范围中的变量。如果写成`[=]`形式，意思是所有的变量都按值捕获。还有一种写法`[&, =N]`可以单独指定一些变量按照值捕获，其他变量都按引用捕获。表示按值捕获N，其他变量引用用捕获。  

所以下面这几个捕获语句的效果是等价的：  
`[&N, M]　　　　　[M, &N]`  
`[&, =M]　　　　　[=, &N]`

### 11 . static 方法  
cherno第21课-static in C++  
中的一个弹幕：  
static在class以外就像是class中的private关键字，封装其作用范围只在obj中   

### 12 . C++ 条件运算符 ? :
```C++
int main ()
{
   // 局部变量声明
   int x, y = 10;

   x = (y < 10) ? 30 : 40;

   cout << "value of x: " << x << endl;
 
   return 0;
}
```
当上面的代码被编译和执行时，它会产生下列结果：  
`value of x: 40`  