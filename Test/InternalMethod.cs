using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalMethod : MonoBehaviour
{
    public enum Teacher
    {
        Siki,
        Ivy,
        Trigger,
        Sandy,
        Druid,
        Lain
    }

    private Teacher teacherKind;

    void Awake()
    {
        teacherKind = Teacher.Siki;
    }

    
    void  Start()
    {

    }

    void Update()
    {

    }
}
