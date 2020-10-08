using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源工厂 有很多 类型  可以让这个 资源工厂接口 使用 泛型
/// 在挂载到工厂的时候指定T的类型
/// </summary>
public interface IBaseRescerousFactory<T>
{
    T GetSingleResources(string resourcePath);


}
