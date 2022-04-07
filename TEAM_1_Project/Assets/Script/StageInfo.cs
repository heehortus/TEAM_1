using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class StageInfo
{
    private const int MaxFirstStage = 3;
    private const int MaxSecondStage = 3;
    public static List<string>[,] getStageInfo()
    {
        var stageEnemyUnitList = new List<string>[4, 4];
        string path = "monkeysList";
        string data = Resources.Load<TextAsset>(path).ToString();
        var monkeysData = JsonUtility.FromJson<MonkeyData>(data);
        foreach (var item in monkeysData.stageAddUnitList)
        {
            int i = int.Parse(item.stage[0].ToString());
            int j = int.Parse(item.stage[2].ToString());
            stageEnemyUnitList[i, j] = new List<string>();
            if (!(i == 1 && j == 1))
            {
                int x = j>1 ? i : i - 1;
                int y = j>1 ? j-1 : MaxSecondStage;
                stageEnemyUnitList[i,j] = stageEnemyUnitList[x,y].ToList();
            }
            foreach (var unit in item.Units)
            {
                stageEnemyUnitList[i,j].Add(unit);
            }
        }
        return stageEnemyUnitList;
    }
}

[Serializable]
public class MonkeyData
{
    public StageAddUnitList[] stageAddUnitList;
}

[Serializable]
public class StageAddUnitList {
    public string stage;
    public string[] Units;
}