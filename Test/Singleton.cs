using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    ////饿汉式单例
    //private static Singleton _instance;

    //public static Singleton Instance { get => Instance; set => Instance = value; }


    //private void Awake()
    //{
    //    _instance = this; 
    //}

    //懒汉式单例
    private static Singleton _instance;

    public static Singleton Instance
    {
        get
        {
            if (_instance)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
        set
        {

        }
    }

    
}

//单例模板类
public abstract class SingletonTemplate<T>:MonoBehaviour where T:MonoBehaviour
{
    private static T _instance;

    public static T Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        _instance = this as T;
    }
}
