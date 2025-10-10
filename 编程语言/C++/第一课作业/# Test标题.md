#! https://zhuanlan.zhihu.com/p/647824492
# 第一课作业
## OPENCV
### 1 . 先画出三个圆
**思路如下**  
![R = 2/4。Opengl宽2，宽4R](https://pic4.zhimg.com/80/v2-cfd6172869b20a66373589c7d5a93f4c.png)
**代码**  
```C++
void donut(float o_x, float o_y) { //o_x代表一个圆的中心x坐标，下面的点加上o_x为移动后的坐标
    glBegin(GL_TRIANGLES);
    constexpr int n = 100;
    constexpr float pi = 3.1415926535897f;
    float radius = 0.5f;
    float inner_radius = 0.25f;
    for (int i = 0; i < n; i++) {
        float angle = i / (float)n * pi * 2;
        float angle_next = (i + 1) / (float)n * pi * 2;
        glVertex3f(radius * sinf(angle)+o_x, radius * cosf(angle)+o_y, 0.0f);
        glVertex3f(radius * sinf(angle_next) + o_x, radius * cosf(angle_next) + o_y, 0.0f);
        glVertex3f(inner_radius * sinf(angle) + o_x, inner_radius * cosf(angle) + o_y, 0.0f);

        glVertex3f(inner_radius * sinf(angle_next) + o_x, inner_radius * cosf(angle_next) + o_y, 0.0f);
        glVertex3f(inner_radius * sinf(angle) + o_x, inner_radius * cosf(angle) + o_y, 0.0f);
        glVertex3f(radius * sinf(angle_next) + o_x, radius * cosf(angle_next) + o_y, 0.0f);
    }
    CHECK_GL(glEnd());
}


static void render() {
    constexpr float R = 0.5f; //R = 2 / 4 Opengl宽2，宽4R。见图
    donut(0, R);
    donut(-R, -(R - 0.268f * R));
    donut(R, -(R - 0.268f * R));
}
```
**效果**  
![](https://pic4.zhimg.com/80/v2-8fcd34c9477379028daee77590ad4f03.png)

### 2 . 缩小一下
![](https://pic4.zhimg.com/80/v2-de93b81f2540b76b3fff6176e5ecf3ad.png)
如图粉色的坐标，要把圆心的坐标 转化为 坐标系原点在左上角的坐标 计算完缩小多少倍后 再转化为坐标系原点屏幕中心的坐标。另外R(外圈圆半径)和r（内圈圆半径）要乘以缩小的倍数。    
**代码：**  
```C++
void donut(float o_x, float o_y) { //o_x代表一个圆的中心x坐标，下面的点加上o_x为移动后的坐标
    glBegin(GL_TRIANGLES);
    constexpr int n = 100;
    constexpr float pi = 3.1415926535897f;
    float radius = 0.5f;
    float inner_radius = 0.25f;

    o_x = o_x / 2.0f + 0.5f;
    o_y = (-1.0f) * o_y / 2.0f + 0.5f;//要把圆心的坐标 转化为 坐标系原点在左上角的坐标

    o_x = 3.0f * o_x / 4.0f;
    o_y = 3.0f * o_y / 4.0f;//计算完缩小多少倍后
    radius = 3.0f * radius / 4.0f;
    inner_radius = 3.0f * inner_radius / 4.0f; //R(外圈圆半径)和r（内圈圆半径）要乘以缩小的倍数

    o_x = (o_x - 0.5f) * 2.0f;
    o_y = (o_y - 0.5f) * (-2.0f);//再转化为坐标系原点屏幕中心的坐标。

    for (int i = 0; i < n; i++) {
        float angle = i / (float)n * pi * 2;
        float angle_next = (i + 1) / (float)n * pi * 2;
        glVertex3f(radius * sinf(angle)+o_x, radius * cosf(angle)+o_y, 0.0f);
        glVertex3f(radius * sinf(angle_next) + o_x, radius * cosf(angle_next) + o_y, 0.0f);
        glVertex3f(inner_radius * sinf(angle) + o_x, inner_radius * cosf(angle) + o_y, 0.0f);

        glVertex3f(inner_radius * sinf(angle_next) + o_x, inner_radius * cosf(angle_next) + o_y, 0.0f);
        glVertex3f(inner_radius * sinf(angle) + o_x, inner_radius * cosf(angle) + o_y, 0.0f);
        glVertex3f(radius * sinf(angle_next) + o_x, radius * cosf(angle_next) + o_y, 0.0f);
    }
    CHECK_GL(glEnd());
}


static void render() {
    constexpr float R = 0.5f; //R = 2 / 4 Opengl宽2，宽4R
    donut(0, R);
    donut(-R, -(R - 0.268f * R));
    donut(R, -(R - 0.268f * R));
}
```
**效果：**  
![](https://pic4.zhimg.com/80/v2-de001e3d3ba26a3d75c410b9dbd09c1f.png)

### 3 . 把圆环之间留出空隙
![](https://pic4.zhimg.com/80/v2-1830ca3c2981b35e68f9d8dd639ce308.png)
![](https://pic4.zhimg.com/80/v2-083fdfb386de9d0106534924ac1aea02.png)

### 4 . 画出内切三角形。
![](https://pic4.zhimg.com/80/v2-a8e684e7388d98b3876c4f4bc78c81f8.png)
```C++
void donut(float o_x, float o_y,int startAngle,int endAngle) { //o_x代表一个圆的中心x坐标，下面的点加上o_x为移动后的坐标
    //////……这里加上int startAngle,int endAngle
    glBegin(GL_TRIANGLES);
    constexpr int n = 360;//////……这里变成360，因为方便计算角度
    constexpr float pi = 3.1415926535897f;
    float radius = 0.45f;
    float inner_radius = 0.225f;

    o_x = o_x / 2.0f + 0.5f;
    o_y = (-1.0f) * o_y / 2.0f + 0.5f;//要把圆心的坐标 转化为 坐标系原点在左上角的坐标

    o_x = 3.0f * o_x / 4.0f;
    o_y = 3.0f * o_y / 4.0f;//计算完缩小多少倍后
    radius = 3.0f * radius / 4.0f;
    inner_radius = 3.0f * inner_radius / 4.0f; //R(外圈圆半径)和r（内圈圆半径）要乘以缩小的倍数

    o_x = (o_x - 0.5f) * 2.0f;
    o_y = (o_y - 0.5f) * (-2.0f);//再转化为坐标系原点屏幕中心的坐标。

    for (int i = 0; i < n; i++) {
        if (i<startAngle || i >= endAngle) {//////……这里变成这样，仔细想一下紫色的线
            float angle = i / (float)n * pi * 2;
            float angle_next = (i + 1) / (float)n * pi * 2;
            glVertex3f(radius * sinf(angle) + o_x, radius * cosf(angle) + o_y, 0.0f);
            glVertex3f(radius * sinf(angle_next) + o_x, radius * cosf(angle_next) + o_y, 0.0f);
            glVertex3f(inner_radius * sinf(angle) + o_x, inner_radius * cosf(angle) + o_y, 0.0f);

            glVertex3f(inner_radius * sinf(angle_next) + o_x, inner_radius * cosf(angle_next) + o_y, 0.0f);
            glVertex3f(inner_radius * sinf(angle) + o_x, inner_radius * cosf(angle) + o_y, 0.0f);
            glVertex3f(radius * sinf(angle_next) + o_x, radius * cosf(angle_next) + o_y, 0.0f);
        }
    }
    CHECK_GL(glEnd());
}


static void render() {
    constexpr float R = 0.5f; //R = 2 / 4 Opengl宽2，宽4R
    donut(0, R,150,210);//////……这里变成这样，如图
    donut(-R, -(R - 0.268f * R),30,90);//////……这里变成这样，如图
    donut(R, -(R - 0.268f * R),270,330);//////……这里变成这样，如图
```
**效果：**  
![](https://pic4.zhimg.com/80/v2-d9e5d9c02eafa4c94c4039cc9cbc571a.png)