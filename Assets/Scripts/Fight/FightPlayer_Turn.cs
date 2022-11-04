using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayerTurn : FightUnit 
{
    public override void Init()
    {
        //base.Init();
        Debug.Log("playerTime");
        UIManager.Instance.ShowTip("玩家回合", Color.green, delegate()
        {
            //抽牌
            Debug.Log("抽牌");
            UIManager.Instance.GetUI<FightUI>("FightUI").CreateCardItem(4);//抽4张
            UIManager.Instance.GetUI<FightUI>("FightUI").UpdateCardItemPos();
        });
    }

    public override void OnUpdate()
    {
        //base.OnUpdate();
    }
}
