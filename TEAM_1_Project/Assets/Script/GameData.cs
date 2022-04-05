using System.Collections.Generic;

public class GameData
{
    private static GameData instance = null;

    public GameData()
    {
        possibleStage = new bool[4,4];
        selectStage = (1, 1);
        possibleStage[1,1] = true;
        possibleStage[2,1] = true;
        possibleStage[3,1] = true;
        _unitDic.Add("SeedUnit1", true);
        _unitDic.Add("SeedUnit2", false);
        _unitDic.Add("SeedUnit3", false);

        _unitDic.Add("BoomUnit1", true);
        _unitDic.Add("BoomUnit2", false);
        _unitDic.Add("BoomUnit3", false);

        _unitDic.Add("StealerUnit1", true);
        _unitDic.Add("StealerUnit2", false);
        _unitDic.Add("StealerUnit3", false);

        _unitDic.Add("Unit", false); // 일단 UnitFactory에 있는 유닛들만 임시로 보유하도록 설정
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
    
    public bool[,] possibleStage { get; set; }
    
    public Dictionary<string, bool> _unitDic = new Dictionary<string, bool>();

    public List<string> noHaveUnit = new List<string>() { "SeedUnit2", "SeedUnit3", "BoomUnit2", "BoomUnit3", "StealerUnit2", "StealerUnit3" };
}