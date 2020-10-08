using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLoadSceneState : BaseSceneState
{
    public StartLoadSceneState(UIFacade uiFacade) : base(uiFacade)
    {
    }

    public override void EnterScene()
    {
        //添加UIPanel资源 到UIManager的字典里
        mUIFacade.AddPanelToDict(StringManager.StartLoadPanel);

        //从UIManager的字典里转 到mUIfacade的字典里 并且实例化
        base.EnterScene();
    }

    public override void ExitScene()
    {
        base.ExitScene();
        SceneManager.LoadScene(1);
    }
}
