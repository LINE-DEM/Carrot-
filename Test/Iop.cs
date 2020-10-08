using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iop : MonoBehaviour
{
    private void Start()
    {
        //可以用接口声明！！！！！！ 
        //用接口类型定义的 变量 不能接收 
        //1.用new新建立的 方法 
        //2.不能 .变量 
        IHero myHero = new Leblanc();
        myHero.SkillE();
       
        BaseHero myHero01 = new Leblanc();
        myHero01.SkillE();
        myHero01.hp = 10;
    }
}

public interface IHero
{
    void SkillQ();
    void SkillW();
    void SkillE();
    void SkillR();
}


//为什么 用一个基类： 为了定义 一些变量
public class BaseHero : IHero
{
    public int hp;

    public virtual void SkillE()
    {
        Debug.Log("玩家按下E键");
    }

    public void SkillQ()
    {
        Debug.Log("玩家按下Q键");
    }

    public void SkillR()
    {
        Debug.Log("玩家按下R键");
    }

    public void SkillW()
    {
        Debug.Log("玩家按下W键");
    }
}

public class Leblanc : BaseHero
{
    //new 变成了新方法 不会被接口类型的变量调用 
    //virtual 和 override 即使是接口变量也可以被很好的调用
    public override void SkillE()
    {
        base.SkillE();
        Debug.Log("E幻影铁链");
    }

    //public void SkillQ()
    //{
    //    Debug.Log("Q恶意魔印");
    //}

    //public void SkillR()
    //{
    //    Debug.Log("R故技重施");
    //}

    //public void SkillW()
    //{
    //    Debug.Log("E魔影迷踪");
    //}
}

public class Zed : BaseHero
{
    //public void SkillE()
    //{
    //    Debug.Log("E禁奥义");
    //}

    //public void SkillQ()
    //{
    //    Debug.Log("Q禁奥义 ");
    //}

    //public void SkillR()
    //{
    //    Debug.Log("R禁奥义 瞬育婴杀阵");
    //}

    //public void SkillW()
    //{
    //    Debug.Log("E禁奥义");
    //}
}

