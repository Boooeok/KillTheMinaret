using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    void Start()
    {
        //初始化配置表
        GameConfigManager.Instance.Init();

        //初始化音频管理器
        AudioManager.Instance.Init();

        //初始化用户信息
        RoleManager.Instance.Init();

        //显示loginUI
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        AudioManager.Instance.PlayBGM("bgm1");

        //string name = GameConfigManager.Instance.GetCardById("1002")["Des"];
        string name = GameConfigManager.Instance.GetCardById("1001")["Name"];
        print(name);
    }
}
