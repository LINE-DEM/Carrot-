using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : SingletonTemplate<Trigger>
{
    private void Start()
    {
        Debug.Log(Instance);
    }
}
