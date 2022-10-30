using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//??????§Ø????
public enum ActionType
{
    None,
    Defend,//?????
    Attack,

}
public class Enemy : MonoBehaviour
{
    protected Dictionary<string, string> data;

    public ActionType type;

    public GameObject hpItemObj;
    public GameObject actionObj;

    public void Init(Dictionary<string, string> data)
    {
        this.data = data; 
    }

    void Start()
    {
        type = ActionType.None;
        hpItemObj = UIManager.Instance.CreateHpItem();
        actionObj = UIManager.Instance.CreateActionIcon();

        //??????? ?§Ø???
        hpItemObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position);
        actionObj.transform.position = Camera.main.WorldToScreenPoint(transform.Find("head").position);
    }

    //???????§Ø?
    public void SetRandomAction()
    {
        int ran = Random.Range(0, 3);

    }


}
