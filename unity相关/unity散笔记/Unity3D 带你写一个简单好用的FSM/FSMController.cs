using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//״̬������
public class FSMController : MonoBehaviour
{
    [SerializeField] string defaultState; //ָ��Ĭ��״̬

    private class StateData {
        public IState State;
        public bool IsRunning = false;

        public StateData(IState state, bool isRunning) {
            State = state;
            IsRunning = isRunning;
        }
        public StateData() { }
    }

    //����һ���ֵ����洢״̬������������϶������ͣ������ֵ��һ����Ҫ�洢״̬��������Ҫ�������ķ�����
    //��һ��������ҲҪ�������Ƿ����е�״̬
    private Dictionary<Type,StateData>states = new Dictionary<Type,StateData>();


    //��ΪTypeû��Լ��������������д�ɷ���
    public bool IsRunning<T>() where T : IState => IsRunning(typeof(T));
    public void Enter<T>() where T : IState => Enter(typeof(T));
    public void Exit<T>() where T : IState => Exit(typeof(T));
    public void ForceEnter<T>() where T : IState => ForceEnter(typeof(T));

    void CheckAddState(Type type) {
        //��������������ǣ���������״̬�ǾͲ���ʲô�����û�У��Ǿ����

        if (states.ContainsKey(type)) return;

        StateData state = new StateData();
        state.IsRunning = false;
        state.State = (IState) Activator.CreateInstance(type);
        state.State.OnInit();
        states.Add(type, state);
    }


    //������Ҫ�ж�һ��״̬�Ƿ���������
    bool IsRunning(Type type) {
        if (states.ContainsKey(type)) {
            if (states[type].IsRunning) return true;
        }
        return false;
    }
    void Enter(Type type)
    {

        //��ReEnter��ͬ�����״̬�������У������������Ч
        if (IsRunning(type)) return;
        ForceEnter(type);
    }

    void ForceEnter(Type type) {
        //���ﻹ��һ��������ǣ�״̬�ܷ�ǿ�ƽ��������
        //Ҳ����˵�����ǰ״̬�������У���һ��ִ�н���״̬��
        CheckAddState(type);//û��״̬�����Ҫ�������״̬�����Ǿ���Ҫ���һ��״̬CheckAddState
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
        //���Ȼ��Ǳ������е�״̬���жϵ�ǰ״̬�Ƿ���������
        //����������о��˳����״̬
        foreach (var state in states) {
            if (state.Value.IsRunning) Exit(state.Key);
        }
    }

    //����Unity���������ڣ�����Update������FixUpdate������OnDestroy������Щ��IState�ӿڶ����ж����
    private void Update()
    {
        //����״̬�б��ж�ÿһ��״̬�Ƿ���������
        //����������У�����״̬����������
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
        //����������Ҫ�˳����е�״̬��
        //��Ϊ���ڵ�״̬�������Ѿ����٣����ǵ���дһ���˳�����״̬�ķ���ExitAll
        //ѻ�ʣ��Ѿ����٣�����һ�����ٵ�13:44
        ExitAll();

        //�˳�����״̬֮�����Ǳ�����Щ״̬���״̬�б�
        foreach (var state in states) {
            state.Value.State.OnDestroy();
        }
        states.Clear();
    }

}
