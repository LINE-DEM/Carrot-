using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //只有游戏物体有对象池

    public GameObject monster;

    private Stack<GameObject> monsterPool;

    private Stack<GameObject> activeMonsterList;
    // Start is called before the first frame update
    void Start()
    {
        monsterPool = new Stack<GameObject>();
        activeMonsterList = new Stack<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //如果需要物体要去对象池里去
            GameObject itemGo = GetMonster();
            itemGo.transform.position = Vector3.one;
            activeMonsterList.Push(itemGo);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if(activeMonsterList.Count > 0)
            {
                //如果要销毁怪物对象 就直接把怪物对象放入池子
                PushMonster(activeMonsterList.Pop());
            }
        }
    }

    private GameObject GetMonster()
    {
        GameObject monsterGo = null;
        if(monsterPool.Count <= 0)//池子里没有怪物对象
        {
            monsterGo = Instantiate(monster);
        }
        else//池子里有怪物对象
        {
            monsterGo = monsterPool.Pop();
        }

        monsterGo.SetActive(true);
        return monsterGo;
    }

    private void PushMonster(GameObject monsterGo)
    {
        monsterGo.transform.SetParent(transform);
        monsterGo.SetActive(false);
        monsterPool.Push(monsterGo);
    }
}
