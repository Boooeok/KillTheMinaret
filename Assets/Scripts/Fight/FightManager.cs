using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ս��ö��
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
/// ս��������
/// </summary>
public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit;//ս����Ԫ


    public int MaxHp;//���Ѫ��
    public int CurHp;//��ǰѪ��

    public int MaxPowerCount;//�������(����ʹ�û���������)
    public int CurPowerCount;//��ǰ����(����ʹ�û���������)
    public int DefenseCount;//

    //��ʼ��
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
    /// �л�ս������
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
        fightUnit.Init();//��ʼ��
    }
    private void Update()
    {
        if (fightUnit != null)
        {
            fightUnit.OnUpdate();
        }
    }
}
