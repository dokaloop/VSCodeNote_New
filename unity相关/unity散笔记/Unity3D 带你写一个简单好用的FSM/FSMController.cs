using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//状态控制器
public class FSMController : MonoBehaviour
{
    [SerializeField] string defaultState; //指定默认状态

    private class StateData {
        public IState State;
        public bool IsRunning = false;

        public StateData(IState state, bool isRunning) {
            State = state;
            IsRunning = isRunning;
        }
        public StateData() { }
    }

    //声明一个字典来存储状态，这个“键”肯定是类型，这个“值”一方面要存储状态本身我们要调用它的方法，
    //另一方面我们也要管理它是否运行的状态
    private Dictionary<Type,StateData>states = new Dictionary<Type,StateData>();


    //因为Type没法约束传入类型所以写成泛型
    public bool IsRunning<T>() where T : IState => IsRunning(typeof(T));
    public void Enter<T>() where T : IState => Enter(typeof(T));
    public void Exit<T>() where T : IState => Exit(typeof(T));
    public void ForceEnter<T>() where T : IState => ForceEnter(typeof(T));

    void CheckAddState(Type type) {
        //这个方法的作用是：如果有这个状态那就不做什么，如果没有，那就添加

        if (states.ContainsKey(type)) return;

        StateData state = new StateData();
        state.IsRunning = false;
        state.State = (IState) Activator.CreateInstance(type);
        state.State.OnInit();
        states.Add(type, state);
    }


    //我们需要判断一个状态是否正在运行
    bool IsRunning(Type type) {
        if (states.ContainsKey(type)) {
            if (states[type].IsRunning) return true;
        }
        return false;
    }
    void Enter(Type type)
    {

        //与ReEnter不同，如果状态正在运行，这个方法就无效
        if (IsRunning(type)) return;
        ForceEnter(type);
    }

    void ForceEnter(Type type) {
        //这里还有一个问题就是：状态能否强制进入的问题
        //也就是说如果当前状态正在运行，再一次执行进入状态。
        CheckAddState(type);//没有状态如果想要进入这个状态那我们就需要添加一个状态CheckAddState
        StateData state = states[type];
        state.State.OnEnter();
        state.IsRunning = true;
    }

    void Exit(Type type)
    {
        if (!IsRunning(type)) return;

        StateData state = states[type];
        state.IsRunning = false;
        state.State.OnExit();
    }

    public void ExitAll() {
        //首先还是遍历所有的状态，判断当前状态是否正在运行
        //如果正在运行就退出这个状态
        foreach (var state in states) {
            if (state.Value.IsRunning) Exit(state.Key);
        }
    }

    //引入Unity的生命周期，定义Update方法和FixUpdate方法和OnDestroy方法这些在IState接口都是有定义的
    private void Update()
    {
        //遍历状态列表，判断每一个状态是否正在运行
        //如果正在运行，调用状态的生命周期
        foreach (var state in states) {
            if(state.Value.IsRunning) state.Value.State.Update();
        }
    }
    private void FixedUpdate()
    {
        foreach (var state in states)
        {
            if (state.Value.IsRunning) state.Value.State.FixedUpdate();
        }
    }
    private void OnDestroy()
    {
        //我们首先需要退出所有的状态，
        //因为现在的状态控制器已经销毁，我们单独写一个退出所有状态的方法ExitAll
        //鸦问：已经销毁，在哪一步销毁的13:44
        ExitAll();

        //退出所有状态之后，我们遍历这些状态清空状态列表
        foreach (var state in states) {
            state.Value.State.OnDestroy();
        }
        states.Clear();
    }

}
