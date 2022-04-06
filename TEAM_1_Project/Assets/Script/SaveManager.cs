using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveManager
{
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
        File.WriteAllText($"{Application.persistentDataPath}/save.json", str);
    }
    public void LoadInfo()
    {
        
        string path = $"{Application.persistentDataPath}/save.json";
        if (File.Exists(path) == false)
        {
            using (var writer = File.CreateText(path))
            {
                GameData.GetInstance().Clear();
                string str = JsonUtility.ToJson(GameData.GetInstance());
                writer.Write(str);
            }
        }

        string file = File.ReadAllText(path);
        GameData data = JsonUtility.FromJson<GameData>(file);

        foreach (var unit in data.noHaveUnit)
        {
            GameData.GetInstance().noHaveUnit.Add(unit);
            GameData.GetInstance()._unitDic[unit] = false;
        }
        foreach (var st in data.possibleStage1)
            GameData.GetInstance().possibleStage1.Add(st);
        foreach (var st in data.possibleStage2)
            GameData.GetInstance().possibleStage2.Add(st);
        foreach (var st in data.possibleStage3)
            GameData.GetInstance().possibleStage3.Add(st);

    }
    public void ClearInfo()
    {
        GameData.GetInstance().Clear();
        SaveInfo();
    }
}
