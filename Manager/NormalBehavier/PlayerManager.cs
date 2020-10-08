using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// **********    负责加载玩家信息
/// </summary>
public class PlayerManager 
{
    public int adventrueModelNum;                       //冒险模式 解锁的地图 个数
    public int burriedLevelNum;                         //隐藏关卡 的 地图个数
    public int bossModelNum;                            //boss模式杀死的 boss数
    public int coin;                                    //获得的 金币
    public int killMonsterNum;                          //杀怪数
    public int killBossNum;                             //杀boss数
    public int clearItemNum;                            //清理道具的总数
    public List<bool> unLockedNormalModelBigLevelList;  //判断大关卡是否开启
    public List<Stage> unLockedNormalModelLevelList;    //存储每一个小关卡信息
    public List<int> unLockedNormalModelLevelNum;       //每一个大关卡解锁了几个小关卡
    public List<int> unlockedeNormalModelTotleLevelNum; //每一个大关卡一共有几个小关卡

    //怪物窝
    public int cookies;
    public int milk;
    public int nest;
    public int diamands;

}
