using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   ****************游戏总管理 负责管理所有管理者
/// </summary>
public class GameManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public FactoryManager factoryManager;
    public AudioSourceManager audioSourceManager;
    public UIManager uiManager;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public Stage currentStage;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        _instance = this;
        playerManager = new PlayerManager();//最先生成数据
        factoryManager = new FactoryManager();
        audioSourceManager = new AudioSourceManager();
        uiManager = new UIManager();
        uiManager.mUIFacade.currentSceneState.EnterScene();
    }

    //创建游戏对象
    public GameObject CreateItem(GameObject itemGo)
    {
        GameObject go = Instantiate(itemGo);
        return go;
    }

    //获取Sprite资源
    public Sprite GetSprite(string resourcePath)
    {
        return factoryManager.spriteFactory.GetSingleResources(resourcePath);
    }

    //获取AudioClip资源
    public AudioClip GetAudioClip(string resourcePath)
    {
        return factoryManager.audioClipFactory.GetSingleResources(resourcePath);
    }

    //
    public RuntimeAnimatorController GetRunTimeAnimatorController(string resourcePath)
    {
        return factoryManager.runTimeAnimatorControllerFactory.GetSingleResources(resourcePath);
    }

    //获取游戏物体
    public GameObject GetGameObjectResource(FactoryType factoryType , string resourcePath)
    {
        return factoryManager.factoryDict[factoryType].GetItem(resourcePath);
    }

    //将游戏物体放回对象池
    public void PushGameObjectToFactory(FactoryType factoryType ,string resourcePath , GameObject itemGo)
    {
        factoryManager.factoryDict[factoryType].PushItem(resourcePath, itemGo);
    }
}
