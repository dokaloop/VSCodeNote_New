### Unity新手进阶教程：一小时搞懂C#反射的内部原理  
BV1AP4y1S7HX  
#### 1 . C#对象的内存布局
- 类：是一种类型描述，描述了这个类型由哪些数据组成，同时描述一些成员函数。
- 类的实例：new 类(); 集体的内存对象---》一块内存【age(int),sex(int),name(string)】  
  这块内存是所有数据成员的集合。  
  类的数据成员所有数据组成一个类的实例。p-->一块内存，编译器会定死一个偏移量，age在对象实例里面内存偏移多少。  
- 类的成员函数会到哪里去？  
  类的成员函数属于代码指令，编译完成以后，会变成代码指令，全局只有一份，所有的类的实例共用一份代码指令。  
  存入到我们的代码段：编译器---》代码---》.exe执行文件---》运行这个文件的时候，会把里面的所有代码加载到内存的代码段；
- this实例的概念  
  成员函数里面，如果我们使用this，指的就是当前的对象实例。  
  调用这个成员函数的时候，我们会自动给成员函数，把当前的对象实例作为this传入进去。 
```C#
class Person
{
    private int age, sex;
    private string name;
    public void test3(int age, int sex, string name) {
        this.age = age;
        this.sex = sex;
        this.name = name;
    }          
}
static void Main(string[] args)
{
    Person p = new Person();
    p.test3(37, 1, "Blake");
}
```
- 【重要】当我们编写好一个类型以后，  
（1）我们得编译器会知道每个数据的相对于对象实例内存块的偏移;  
（2）我们编译器也会知道，每个类的成员函数在代码段偏移位置;--->运行的时候，就可以让指令直接跳转到这里。这就是函数调用。

#### 2 . 什么是反射，反射有什么用；  
Unity游戏引擎为例，来看反射的作用。  
Unity:编辑器挂脚本，我们给脚本初始化数据。  
编辑完了以后---》保存到场景文件里面；  
运行的时候，我们根据场景文件里面的内容，游戏引擎把这个节点和组件实例new出来；  

//业务开发者  
GameApp  
GameMgr  
//end  

//Unity引擎底层开发  
step1:加载场景文件，读取数据；  
step2:根据判断组件的名字是哪种类型，然后就new出这种类型实例。
``` 
//不太好的方法：
if(name == "GameApp"){
  gameObject.AddComponent<GameApp>();
}
else if (name == "GameMgr"){
  gameObject.AddComponent<GameMgr>();
}
////////////
//好的方法：反射方法：
string name = "从文件读取当前组件的名字"  
Type t = System.Type.GetType(name);
gameObject.AddComponent(t);
```
我的业务逻辑每增加一个类，底层代码就要改一次。反射就是为了解决这个矛盾。 

反射来做;  
上面我们描述一个类，每一个类是一种类型，都有自己独立的描述;所以我们新加一个类，就会有多的一种方式来描述;  
主要矛盾：我们没办法用统一的方式来处理不同的类或类的实例。 

要解决上述我们问题的本质矛盾是什么?  
需要用一种方式来描述任意的类;  

解决方案：  
任意的类，都可以转化成这样一种描述：  
a:类的实例是一个内存块，内存块的大小就是这个类的所有数据成员的大小--->类的实例的内存块大小;  
b:类有哪些数据成员，我可以把这些数据成员的名字，通过数组等其它方式保存起来;  
数据成员数组：  
{ "name", type string,在对象偏移8个字节}  
{"age", type int，在对象里面偏移为0个字节}  
{ "sex", type int,在对象里面偏移为4个字节}  
c:类有哪些成员函数  
{"test", type 成员函数(静态函数)，在代码段的位置.... }  
{ "test2", type 成员函数,在代码段的位置}  
{"test3", type 成员函数，在代码段的位置}  

#### 3 . 类型描述 对象实例（Type）是什么；
每个类，我们的编译器都知道数据成员的偏移，函数代码段的位置,    
运行的时候，我们的C#系统会为我们每个类----》描述实例（Type实例）（它的类型是Type类型），属于System名字空间；  
【伪代码】：  
```C#
class FiledData {
string filedName;
int type; 类型
int filedSize;//这个字段的内存大小;
int offset;//在内存对象中的内存偏移
}
class MethodData {
string methName;
int type;//静态的还是，普通的;
int offset; //函数代码指令的地址;
}

class Type {
int memSize;//当前类的实例的内存大小;
List<FiledData> datas;//当前这个类的数据成员;
List<MethodData> funcs;//当前这个类的所有成员函数。
}
```
我要描述MyTest;
```C#
Type t = new Type();
t.addFiled("age" ,0);
t.addFiled("sex" , O);
t.addFiled("name","");
t.addMethod("test"，成员方法，地址);
t.addMethod("test",成员方法，地址);
```
编译完成了以后，我们就可以根据我们的编译信息，来为每个类，来生成一个类型描述对象的数据;数据存起来，一起写入.exe;

我们的就可以使用了Type的方式来获得一个类的描述;  
底层就可以根据类的描述来构建实例，调用方法，和成员了;  
怎么构建实例：调用底层OS的API来分配一个xxxx大小（上文的memSize）的内存出来;作为对象实例的内存;  
调用构造函数，将这个内存块传递给构造函数，构造函数就会帮我们初始化对应的数据。 

---
上面这些都会有API帮我们做。  
(1):编译每个类的时候，我们会为每个类生成一个全局数据，这个全局数据Type类型，里面存放一个类的描述数据;  
APl System.Type.GetType("类型的名字") typeof(T) 根据类型或类型名字来获取我们的类型描述对象实例;  
（2）: Type类型系统已经给我们定义好了;  
FieldsInfos: 数据成员信息;  
MethodInfos;  
（3）:通过反射来实例化一个对象:API: Type t --->实例化一个对象出来;   
Activator.Createlnstance  
(4):我们Type里面存放了每个数据成员的偏移，和大小，所以用这两个数据，就能从对象的内存里面读取/设置成员的数据  
【1】 t--->类型的描述FieldInfo，大小，偏移;  
【2】结合这个实例，【偏移，大小】---》取出来就是数据的值了;--->SetValue/GetValue;  
(5):每个Type里面都存放了我们成员函数地址;  
methodInfo = t.getMethod("名字");  
Object returnObject = methodInfo.Invoke(instance,参数列表);  
```C#
using System.Diagnostics;
using System.Reflection;//加
using System.Security.Cryptography.X509Certificates;
using System;//加

class MyTest
{
    public int age;
    public int sex;
    public string name;

    public int test3(int age, int sex, string name) {
        this.age = age; 
        this.sex = sex;
        this.name = name;
        return -1;
    }
}
//注意MyTest的类在namespace的外面，俺也不知道为什么不能放在class Program里面
namespace SeniorObject
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // step1: 获取MyTest的类型描述对象实例
            Type t = System.Type.GetType("MyTest");
            // end

            // step2: 利用描述对象实例，构建一个对象出来
            var instance = Activator.CreateInstance(t);
            // end

            // step3: 利用我们存放的数据成员的信息给他们设值
            // instance + ( 偏移 + 大小 )
            FieldInfo[] fields = t.GetFields();
            FieldInfo ageInfo = t.GetField("age");
            //对象实例，ageInfo,偏移+大小
            ageInfo.SetValue(instance, 4);

            //test
            Console.WriteLine((instance as MyTest).age);

            // 调用成员函数
            // 获取MethodInfo
            MethodInfo m = t.GetMethod("test3");
            //参数是Object的数组
            System.Object[] funcParams = new System.Object[3];
            funcParams[0] = 37;
            funcParams[1] = 2;
            funcParams[2] = "Blake";
            System.Object ret = m.Invoke(instance,funcParams);//要传递this，所以把instance传递给它
            Console.WriteLine(ret);
            //end
        }
    }
}
```
**【注意】**MyTest的类在namespace的外面，俺也不知道为什么不能放在class Program里面  
这个up在演示的时候，是：
```C#
class MyTest
{
  //...
}

public class GameApp:Monobehavior{
//getType()哪些
}
```
