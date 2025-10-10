using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState//״̬�ӿ�
{
    //����״̬���˳�״̬
    public void OnEnter();
    public void OnExit();

    //������Ҫ����Monobehaviour��update��fixedupdate����
    public void Update();
    public void FixedUpdate();

    //״̬����һ�α����ص�ʱ��ִ��
    public void OnInit();

    //״̬�������ٵ�ʱ��ִ��
    public void OnDestroy(); 
}

//Ȼ��������һ������
//�������ǰ������󷽷����ࡣ���󷽷���û�з������ݵģ�ֻ��һ���������Ͳ����б����ԣ�
//������ֻ��������

public abstract class AbstractState : IState
{
    public abstract void FixedUpdate();
    public abstract void OnDestroy();
    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnInit();
    public abstract void Update();
}
