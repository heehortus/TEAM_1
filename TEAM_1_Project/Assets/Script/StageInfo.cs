using System.Collections.Generic;

public class StageInfo
{
    public List<string>[,] stageEnemyUnitList { get; private set; }

    public StageInfo()
    {
        stageEnemyUnitList = new List<string>[4, 4];
        //1-1
        
    }
}