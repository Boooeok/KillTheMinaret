using System.Runtime.Versioning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvasTf;//�����ı任���

    private List<UIBase> uiList;//�洢���ع��Ľ���ļ���

    private void Awake()
    {
        Instance = this;
        //�������еĻ���
        canvasTf = GameObject.Find("Canvas").transform;
        //��ʼ������
        uiList = new List<UIBase>();
    }
    public UIBase ShowUI<T>(string uiName) where T : UIBase
    {
        UIBase ui = Find(uiName);
        if (ui == null)
        {
            GameObject obj = Instantiate(Resources.Load("UI/" + uiName), canvasTf) as GameObject;

            //������
            obj.name = uiName;

            //�����Ҫ�Ľű�
            ui = obj.AddComponent<T>();

            //��ӵ����Ͻ��д洢
            uiList.Add(ui);
        }
        else
        {
            ui.Show();
        }
        return ui;
    }

    //����
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

    //��������ͷ�����ж�ͼ��
    public GameObject CreateActionIcon()
    {
        GameObject obj = Instantiate(Resources.Load("UI/actionIcon")) as GameObject;
        obj.transform.SetAsLastSibling();//�����ڸ��������һλ
        return obj;
    }

    //�������˵ײ���Ѫ������
    public GameObject CreateHpItem()
    {
        GameObject obj = Instantiate(Resources.Load("UI/HpItem"), canvasTf) as GameObject;
        obj.transform.SetAsLastSibling();//�����ڸ��������һλ
        return obj;
    }

}
