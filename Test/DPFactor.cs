using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 比如子弹每次销毁后再创建都要再赋值获取索引之类的
/// </summary>
public class DPFactor : MonoBehaviour
{
    private void Start()
    {
        FactoryIPhone8 factoryIPhone8 = new FactoryIPhone8();
        factoryIPhone8.CreatIPhone();
        factoryIPhone8.CreateIPhoneCharger();
        FactoryIPhoneX factoryIPhoneX = new FactoryIPhoneX();
        factoryIPhoneX.CreatIPhone();
        factoryIPhoneX.CreateIPhoneCharger();
    }
}

//工厂模式分为 简单工厂模式 工厂方法模式    抽象工厂模式

//抽象工厂模式
//手机
public interface IPhone
{
    
}

public class IPhone8 : IPhone
{
    public IPhone8()
    {
        
    }
}

public class IPhoneX : IPhone
{
    public IPhoneX()
    {

    }
}

//充电器
public interface IPhoneCharger
{

}

public class IPhone8Charger : IPhoneCharger
{
    public IPhone8Charger()
    {

    }
}

public class IPhoneXCharger : IPhoneCharger
{
    public IPhoneXCharger()
    {

    }
}


public interface IFactory
{
    IPhone CreatIPhone();
    IPhoneCharger CreateIPhoneCharger();
}

public class FactoryIPhone8 : IFactory
{
    public IPhoneCharger CreateIPhoneCharger()
    {
        return new IPhone8Charger();
    }

    public IPhone CreatIPhone()
    {
        return new IPhone8();
    }
}

public class FactoryIPhoneX : IFactory
{
    public IPhoneCharger CreateIPhoneCharger()
    {
        return new IPhoneXCharger();
    }

    public IPhone CreatIPhone()
    {
        return new IPhoneX();
    }
}


//简单工厂模式
//public class IPhone
//{
//    public IPhone()
//    {

//    }
//}

//public class IPhone8 : IPhone
//{
//    public IPhone8()
//    {

//    }
//}

//public class IPhoneX : IPhone
//{
//    public IPhoneX()
//    {

//    }
//}

//public interface IFactory
//{
//    IPhone CreatIPhone();
//}

//public class FactoryIPhone8 : IFactory
//{
//    public IPhone CreatIPhone()
//    {
//        return new IPhone8();
//    }
//}

//public class FactoryIPhoneX : IFactory
//{
//    public IPhone CreatIPhone()
//    {
//        return new IPhoneX();
//    }
//}


//使用工厂模式的原因
//public class BullectOne : MonoBehaviour
//{
//    private AudioClip audioClip;
//    private AudioSource audioSource;
//    private void Start()
//    {
//        audioClip = Resources.Load<AudioClip>("*****");
//        audioSource.clip = audioClip;
//        Destroy(gameObject, 4);
//    }
//}

//public class BullectTwo : MonoBehaviour
//{
//    private AudioClip audioClip;
//    private AudioSource audioSource;
//    private void Start()
//    {
//        audioClip = Resources.Load<AudioClip>("*****");
//        audioSource.clip = audioClip;
//        Destroy(gameObject, 4);
//    }
//}