using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏物体类型的工厂基类
/// </summary>
public class BaseFactory : IBaseFactory
{
    //当前拥有的GameObject类型的资源(UI ， UIPanel ， Game)
    //切记；Dict存放的是 资源预制体 具体的对象是要放到对象池中
    protected Dictionary<string, GameObject> factoryDict = new Dictionary<string, GameObject>();

    //对象池（就是我们具体存储的游戏物体的 对象）

    //对象池字典(存的是许多对象池）
    protected Dictionary<string, Stack<GameObject>> objectPoolDict = new Dictionary<string, Stack<GameObject>>();

    //加载路径
    protected string loadPath;

    public BaseFactory()
    {
        loadPath = "Prefabs/";
    }

    //取实例
    public GameObject GetItem(string itemName)
    {
        GameObject itemGo = null;
        if (objectPoolDict.ContainsKey(itemName)){
            if(objectPoolDict[itemName].Count == 0)
            {
                GameObject go = GetResource(itemName);
                itemGo = GameManager.Instance.CreateItem(go);
            }
            else
            {
                itemGo = objectPoolDict[itemName].Pop();
                itemGo.SetActive(true);
            }

        }
        else//如果没有这个对象池 就创建一个
        {
            objectPoolDict.Add(itemName, new Stack<GameObject>());
            GameObject go = GetResource(itemName);          //只是取得资源
            itemGo = GameManager.Instance.CreateItem(go);   //生成一个实例
        }


        if(itemGo == null)
        {
            Debug.Log(itemName + "的实例获取失败");
        }
        return itemGo;
    }

    //放入池子的方法
    public void PushItem(string itemName, GameObject item)
    {
        item.SetActive(false);
        item.transform.SetParent(GameManager.Instance.transform);
        if (objectPoolDict.ContainsKey(itemName))
        {
            //把item压入对象池
            objectPoolDict[itemName].Push(item);
        }
        else
        {
            Debug.Log("当前字典没有" + itemName + "的栈");
        }
    }

    //取资源 (给一个名字 来获取一个游戏对象）
    private GameObject GetResource(string itemName)
    {
        GameObject itemGo = null;
        string itemLoadPath = loadPath + itemName;
        if (factoryDict.ContainsKey(itemName))
        {
            itemGo = factoryDict[itemName];//如果字典里有直接返回引用
        }
        else
        {
            itemGo = Resources.Load<GameObject>(itemLoadPath);  //如果字典里没有
            factoryDict.Add(itemName, itemGo);                  //就加载一个预制体
        }
        if (itemGo == null)
        {
            Debug.Log(itemName + "的资源获取失败");
            Debug.Log("失败路径：" + itemLoadPath);
        }
        return itemGo;
    }
}
