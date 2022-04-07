using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    private static GameData instance = null;

    public GameData()
    {
        //possibleStage = new bool[4,4];
        selectStage = (1, 1);
        //possibleStage[1,1] = true;
        //possibleStage[2,1] = true;
        //possibleStage[3,1] = true;

        //possibleStage1 = new List<bool> { false, true, false, false };
        //possibleStage2 = new List<bool> { false, false, false, false };
        //possibleStage3 = new List<bool> { false, false, false, false };

        _unitDic.Add("SeedUnit1", true);
        _unitDic.Add("SeedUnit2", true);
        _unitDic.Add("SeedUnit3", true);

        _unitDic.Add("BoomUnit1", true);
        _unitDic.Add("BoomUnit2", true);
        _unitDic.Add("BoomUnit3", true);

        _unitDic.Add("StealerUnit1", true);
        _unitDic.Add("StealerUnit2", true);
        _unitDic.Add("StealerUnit3", true);

        //noHaveUnit = new List<string>() { "SeedUnit2", "SeedUnit3", "BoomUnit2", "BoomUnit3", "StealerUnit2", "StealerUnit3" };
    }
    public void Clear()
    {
        possibleStage1 = new List<bool> { false, true, false, false };
        possibleStage2 = new List<bool> { false, false, false, false };
        possibleStage3 = new List<bool> { false, false, false, false };
        noHaveUnit = new List<string>() { "SeedUnit2", "SeedUnit3", "BoomUnit2", "BoomUnit3", "StealerUnit2", "StealerUnit3" };
        foreach (var unit in noHaveUnit)
        {
            GameData.GetInstance()._unitDic[unit] = false;
        }
    }
    public static GameData GetInstance()
    {
        if (instance == null)
        {
            instance = new GameData();
        }
        return instance;
    }

    public (int, int) selectStage;

    //public bool[,] possibleStage;
    public List<bool> possibleStage1 = new List<bool>();
    public List<bool> possibleStage2 = new List<bool>();
    public List<bool> possibleStage3 = new List<bool>();

    public Dictionary<string, bool> _unitDic = new Dictionary<string, bool>();

    public List<string> noHaveUnit = new List<string>();
}