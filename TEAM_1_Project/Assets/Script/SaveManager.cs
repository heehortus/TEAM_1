using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveManager
{
    static string path = "Assets/Resources/Save/save.json";

    static SaveManager _instance = null;
    public static SaveManager Save
    {
        get { Init();return _instance; }
    }
    static void Init()
    {
        if (_instance == null)
        {
            _instance = new SaveManager();
        }
    }
    public void SaveInfo()
    {
        string str = JsonUtility.ToJson(GameData.GetInstance());
        using (var writer = File.CreateText("Assets/Resources/Save/save.json"))
        {
            writer.Write(str);
        }
    }
    public void LoadInfo()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Save/save");
        GameData data = JsonUtility.FromJson<GameData>(textAsset.text);
        GameData.GetInstance().noHaveUnit = data.noHaveUnit.ToList();
        GameData.GetInstance().possibleStage1 = data.possibleStage1.ToList();
        GameData.GetInstance().possibleStage2 = data.possibleStage2.ToList();
        GameData.GetInstance().possibleStage3 = data.possibleStage3.ToList();
        foreach(var unit in data.noHaveUnit)
        {
            GameData.GetInstance()._unitDic[unit] = false;
        }
    }
    public void ClearInfo()
    {
        GameData.GetInstance().Clear();
        SaveInfo();
    }
}
