using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayerTurn : FightUnit 
{
    public override void Init()
    {
        //base.Init();
        Debug.Log("playerTime");
        UIManager.Instance.ShowTip("��һغ�", Color.green, delegate()
        {
            //����
            Debug.Log("����");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);//��4��
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();
        });
    }

    public override void OnUpdate()
    {
        //base.OnUpdate();
    }
}
