using System.Runtime.Versioning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;//画布的变换组件

    private List<UIBase> uiList;//存储加载过的界面的集合

    private void Awake()
    {
        Instance = this;
        //找世界中的画布
        canvasTf = GameObject.Find("Canvas").transform;
        //初始化集合
        uiList = new List<UIBase>();
    }
    public UIBase ShowUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if (ui == null)
        {
            GameObject obj = Instantiate(Resources.Load("UI/" + uiName), canvasTf) as GameObject;

            //改名字
            obj.name = uiName;

            //添加需要的脚本
            ui = obj.AddComponent<T>();

            //添加到集合进行存储
            uiList.Add(ui);
        }
        else
        {
            ui.Show();
        }
        return ui;
    }

    //隐藏
    public void HideUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if(ui != null)
        {
            ui.Hide();
        }
    }

    public void CloseAllUI()
    {
        for(int i = uiList.Count - 1; i >= 0; i--)
        {
            Destroy(uiList[i].gameObject);
        }
        uiList.Clear();
    }

    public void CloseUI(string uiName)
    {
        UIBase ui = Find(uiName);
        if( ui != null)
        {
            uiList.Remove(ui);
            Destroy(ui.gameObject);
        }
    }

    public UIBase Find(string uiName)
    {
        for (int i = 0; i < uiList.Count; i++)
        {
            if(uiList[i].name == uiName)
            {
                return uiList[i];
            }
        }
        return null;
    }

    //创建敌人头部得行动图标
    public GameObject CreateActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon")) as GameObject;
        obj.transform.SetAsLastSibling();//设置在父级得最后一位
        return obj;
    }

    //创建敌人底部得血量物体
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), canvasTf) as GameObject;
        obj.transform.SetAsLastSibling();//设置在父级得最后一位
        return obj;
    }

}
