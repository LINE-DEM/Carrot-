﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPState : MonoBehaviour
{
    //public enum PersonState
    //{
    //    EatMeals,
    //    Work,
    //    Sleep
    //}

    //public PersonState personState;

    void Start()
    {
        //personState = PersonState.Work;
        //if (personState == PersonState.Work)
        //{
        //    Debug.Log("我们正在工作");
        //}
        //else if (personState == PersonState.EatMeals)
        //{
        //    Debug.Log("我们正在吃饭");
        //}
        //else
        //{
        //    Debug.Log("我们正在睡觉");
        //}

        Context context = new Context();
        context.SetState(new EatMeals(context));//设置当前的状态机
        context.Handle();
    }

}


public interface IState
{
    void Handle();


}

public class Context //状态机
{
    private IState mState;//当前状态

    public void SetState(IState state)
    {
        mState = state;
    }

    public void Handle()
    {
        mState.Handle(); //当前状态下需要执行的方法
    }
}

public class EatMeals:IState
{
    private Context mContext;

    public EatMeals(Context context)
    {
        mContext = context;
    }

    public void Handle()
    {
        Debug.Log("我们正在吃饭");
    }

}

public class Work : IState
{
    private Context mContext; 

    public Work(Context context)
    {
        mContext = context;
    }

    public void Handle()
    {
        Debug.Log("我们正在工作");
    }

}

public class Sleep : IState
{
    private Context mContext;

    public Sleep (Context context)
    {
        mContext = context;
    }

    public void Handle()
    {
        Debug.Log("我们正在睡觉");
    }

}
