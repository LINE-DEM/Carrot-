using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// **********   负责管理UI的管理者
/// </summary>
public class UIManager 
{
    public UIFacade mUIFacade;
    public Dictionary<string, GameObject> currentScenePanelDict;
    private GameManager mGameManager;

    public UIManager()
    {
        mGameManager = GameManager.Instance;
        currentScenePanelDict = new Dictionary<string, GameObject>();
        mUIFacade = new UIFacade(this);
        mUIFacade.currentSceneState = new StartLoadSceneState(mUIFacade);
    }

    //私有 将UIPanel放回工厂(封装了一下GameManager的方法而已)
    private void PushUIPanel(string uiPanelName , GameObject uiPanelGo)
    {
        mGameManager.PushGameObjectToFactory(FactoryType.UIPanelFactory, uiPanelName, uiPanelGo);
    }

    //清空字典
    public void ClearDict()
    {
        
        foreach (var item in currentScenePanelDict)
        {
            //先放入工厂栈中 但是生成的物体自带（Clone）要截取后7个
            PushUIPanel(item.Value.name.Substring(0 , item.Value.name.Length-7), item.Value);
        }

        currentScenePanelDict.Clear();
    }
}
