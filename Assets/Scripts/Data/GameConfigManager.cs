using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigManager : MonoBehaviour
{
    public static GameConfigManager Instance = new GameConfigManager();

    private GameConfigData cardData;//���Ʊ�

    private GameConfigData enemyData;//���˱�

    private GameConfigData levelData;//�ؿ���

    private TextAsset textAsset;//

    //��ʼ�������ļ�
    public void Init()
    {
        textAsset = Resources.Load<TextAsset>("Data/card");
        cardData = new GameConfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/enemy");
        enemyData = new GameConfigData(textAsset.text);

        textAsset = Resources.Load<TextAsset>("Data/level");
        levelData = new GameConfigData(textAsset.text);
    }

    public List<Dictionary<string, string>> GetCardLines()
    {
        return cardData.GetLines();
    }

    public List<Dictionary<string, string>> GetEnemyLines()
    {
        return enemyData.GetLines();
    }

    public List<Dictionary<string, string>> GetLevelLines()
    {
        return levelData.GetLines();
    }

    public Dictionary<string, string> GetCardById(string id)
    {
        return cardData.GetOneById(id);
    }

    public Dictionary<string, string> GetEnemyById(string id)
    {
        return enemyData.GetOneById(id);
    }

    public Dictionary<string, string> GetLevelById(string id)
    {
        return levelData.GetOneById(id);
    }

}
