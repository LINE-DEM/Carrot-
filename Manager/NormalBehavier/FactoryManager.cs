using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// **************    工厂管理 ， 负责管理各种类型的工厂 和 对象池
/// </summary>
public class FactoryManager 
{
    public Dictionary<FactoryType, IBaseFactory> factoryDict = new Dictionary<FactoryType, IBaseFactory>();
    public AudioClipFactory audioClipFactory;
    public SpriteFactory spriteFactory;
    public RunTimeAnimatorControllerFactory runTimeAnimatorControllerFactory;
   
    public FactoryManager()
    {
        factoryDict.Add(FactoryType.UIPanelFactory, new UIPanelFactory());
        factoryDict.Add(FactoryType.UIFactory, new UIFactory());
        factoryDict.Add(FactoryType.GameFactory, new GameFactory());
        audioClipFactory = new AudioClipFactory();
        spriteFactory = new SpriteFactory();
        runTimeAnimatorControllerFactory = new RunTimeAnimatorControllerFactory();

    }
}
