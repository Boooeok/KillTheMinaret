using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : MonoBehaviour
{
    void Start()
    {
        //��ʼ�����ñ�
        GameConfigManager.Instance.Init();

        //��ʼ����Ƶ������
        AudioManager.Instance.Init();

        //��ʼ���û���Ϣ
        RoleManager.Instance.Init();

        //��ʾloginUI
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");

        AudioManager.Instance.PlayBGM("bgm1");

        //string name = GameConfigManager.Instance.GetCardById("1002")["Des"];
        string name = GameConfigManager.Instance.GetCardById("1001")["Name"];
        print(name);
    }
}
