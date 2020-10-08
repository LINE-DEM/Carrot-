using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
///   分离管理者和对象 封装方法
/// </summary>
public class UIFacade
{
    //管理者
    public  UIManager mUIManager;
    private GameManager mGameManager;
    private AudioSourceManager mAudioSourceManager;
    public PlayerManager mPlayerManager;
    //UI面板
    public Dictionary<string, IBasePanel> currentScenePanelDict = new Dictionary<string, IBasePanel>();
    //其他成员变量
    private GameObject mask;
    private Image maskImage;
    public Transform canvasTransform;
    //场景状态
    public IBaseSceneState currentSceneState;
    public IBaseSceneState lastSceneState;

    public UIFacade(UIManager uiManager)
    {
        //获取四个管理者
        mGameManager = GameManager.Instance;
        mPlayerManager = mGameManager.playerManager;
        mUIManager = uiManager;
        mAudioSourceManager = mGameManager.audioSourceManager;
        InitMask();
    }


    //初始化遮罩
    public void InitMask()
    {
        canvasTransform = GameObject.Find("Canvas").transform;
        //最好不要让UIF 知道UI工厂
        //mask = mGameManager.factoryManager.factoryDict[FactoryType.UIFactory].GetItem("Img_Mask");
        //1所以最好封装到GameManger里面
        //mask = mGameManager.GetGameObjectResource(FactoryType.UIFactory, "Img_Mask");
        //2在UIFacade里封装
        //mask = GetGameObjectResource(FactoryType.UIFactory, "Img_Mask");
        
        //实例化UI
        mask = CreateUIAndSetUIPosition("Img_Mask");
        maskImage = mask.GetComponent<Image>();
    }

    #region 改变当前场景的状态 ChangeSceneState
    //
    public void ChangeSceneState(IBaseSceneState baseSceneState)
    {
        lastSceneState = currentSceneState;
        ShowMask();
        currentSceneState = baseSceneState;
    }

    //显示遮罩
    public void ShowMask()
    {
        mask.transform.SetSiblingIndex(10);
        Tween t = DOTween.To(() => 
        maskImage.color, 
        toColor => 
        maskImage.color = toColor,
        new Color(0, 0, 0, 1),1f);
        
        //回调事件
        t.OnComplete(ExitSceneComplete);
    }

    //离开当前场景
    private void ExitSceneComplete()
    {
        lastSceneState.ExitScene();
        currentSceneState.EnterScene();
        HideMask();
    }

    //隐藏遮罩
    public void HideMask()
    {
        mask.transform.SetSiblingIndex(10);
        DOTween.To(() =>
        maskImage.color,
        toColor =>
        maskImage.color = toColor,
        new Color(0, 0, 0, 0), 1f);
    }
    #endregion 




    //实例化当前场景所有面板，并存入UIF字典
    public void InitDict()
    {
        foreach (var item in mUIManager.currentScenePanelDict)
        {
            
            item.Value.transform.SetParent(canvasTransform);
            item.Value.transform.localPosition = Vector3.zero;
            item.Value.transform.localScale = Vector3.one;
            IBasePanel basePanel = item.Value.GetComponent<IBasePanel>();
            if (basePanel == null)
            {
                Debug.Log("获取面板上IBasePanel脚本失败");
            }
            basePanel.InitPanel();
            
            currentScenePanelDict.Add(item.Key, basePanel);
            
            
        }
    }

    //清空UIPanel字典
    public void ClearDict()
    {
        currentScenePanelDict.Clear();
        mUIManager.ClearDict();
    }

    //添加UIPanel到UIManager
    public void AddPanelToDict(string uiPanelName)
    {
        mUIManager.currentScenePanelDict.Add(uiPanelName, 
            GetGameObjectResource(FactoryType.UIPanelFactory, uiPanelName));
    }

    //实例化UI
    public GameObject CreateUIAndSetUIPosition(string uiName)
    {
        GameObject itemGo = GetGameObjectResource(FactoryType.UIFactory, uiName);
        itemGo.transform.SetParent(canvasTransform);
        itemGo.transform.localPosition = Vector3.zero;
        itemGo.transform.localScale = Vector3.one;
        return itemGo;
    }

    #region 传入路径 获取资源 的方法封装
    //获取资源
    public Sprite GetSprite(string resourcePath)
    {
        return mGameManager.GetSprite(resourcePath);
    }

    public AudioClip GetAudioSource(string resourcePath)
    {
        return mGameManager.GetAudioClip(resourcePath);
    }

    public RuntimeAnimatorController GetRuntimeAnimatorController(string resourcePath)
    {
        return mGameManager.GetRunTimeAnimatorController(resourcePath);
    }

    //获取游戏物体
    public GameObject GetGameObjectResource(FactoryType factoryType, string resourcePath)
    {
        return mGameManager.GetGameObjectResource(factoryType, resourcePath);
    }
    //将游戏物体放回对象池
    public void PushGameObjectToFactory(FactoryType factoryType, string resourcePath, GameObject itemGo)
    {
        mGameManager.PushGameObjectToFactory(factoryType, resourcePath, itemGo);
    }
    #endregion


    //开关音乐
    public void CloseOrOpenBGMusic()
    {
        mAudioSourceManager.CloseOrOpenBGMusic();
    }

    public void CloseOrOpenEffectMusic()
    {
        mAudioSourceManager.CloseOrOpenEffectMusic();
    }
}
