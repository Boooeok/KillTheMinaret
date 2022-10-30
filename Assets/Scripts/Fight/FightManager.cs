using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗枚举
/// </summary>
public enum FightType
{
    None,
    Init,
    Player,
    Enemy,
    Win,
    Loss
}
/// <summary>
/// 战斗管理器
/// </summary>
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit;//战斗单元


    public int MaxHp;//最大血量
    public int CurHp;//当前血量

    public int MaxPowerCount;//最大能量(卡牌使用会消耗能量)
    public int CurPowerCount;//当前能量(卡牌使用会消耗能量)
    public int DefenseCount;//

    //初始化
    public void Init()
    {
        MaxHp = 0;
        CurHp = 10;
        MaxPowerCount = 10; 
        CurPowerCount = 10; 
        DefenseCount = 10;
    }
    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 切换战斗类型
    /// </summary>
    /// <param name="type"></param>
    public void ChangeType(FightType type)
    {
        switch (type)
        {
            case FightType.None:
                break;
            case FightType.Init:
                fightUnit = new FightInit();
                break;
            case FightType.Player:
                fightUnit = new FightPlayerTurn();
                break;
            case FightType.Enemy:
                fightUnit = new FightEnemyTurn();
                break;
            case FightType.Win:
                fightUnit = new FightWin();
                break;
            case FightType.Loss:
                fightUnit = new FightLoss();
                break;
        }
        fightUnit.Init();//初始化
    }
    private void Update()
    {
        if (fightUnit != null)
        {
            fightUnit.OnUpdate();
        }
    }
}
