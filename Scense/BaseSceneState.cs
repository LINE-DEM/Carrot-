using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSceneState : IBaseSceneState
{
    protected UIFacade mUIFacade;

    public BaseSceneState(UIFacade uiFacade)
    {
        mUIFacade = uiFacade;
    }
    public virtual void EnterScene()
    {
        //进入场景时 初始化所有面板
        mUIFacade.InitDict();
    }

    public virtual void ExitScene()
    {
        //离开场景时 清除UIM和UIF里面的字典
        mUIFacade.ClearDict();
    }
}
