using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 外观模式     解决的是 上层 调用 下层 的关系混乱
/// </summary>
public class DPFacade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Principal principal = new Principal();
        principal.OrderTeacherToDoTask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//上层管理
public class Principal
{
    private Teacher teacher = new Teacher();
    public void OrderTeacherToDoTask()
    {
        teacher.OrderStudentsToSummary();
    }
}

//外观角色
public class Teacher
{
    private Monitor monitor = new Monitor();
    private LeagueSecretay leagueSecretary = new LeagueSecretay();
    public void OrderStudentsToSummary()
    {
        monitor.WriteSummary();
        leagueSecretary.WriteSummary();
    }
}

public class Monitor
{
    public void WriteSummary()
    {
        Debug.Log("班长的总结");
    }
}

public class LeagueSecretay
{
    public void WriteSummary()
    {
        Debug.Log("团支书的总结");
    }
}