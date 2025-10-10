using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState//状态接口
{
    //进入状态，退出状态
    public void OnEnter();
    public void OnExit();

    //它还需要引入Monobehaviour的update和fixedupdate函数
    public void Update();
    public void FixedUpdate();

    //状态机第一次被加载的时候执行
    public void OnInit();

    //状态机被销毁的时候执行
    public void OnDestroy(); 
}

//然后我们做一个基类
//抽象类是包含抽象方法的类。抽象方法是没有方法内容的，只有一个方法名和参数列表，并以；
//抽象类只能做父类

public abstract class AbstractState : IState
{
    public abstract void FixedUpdate();
    public abstract void OnDestroy();
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnInit();
    public abstract void Update();
}
