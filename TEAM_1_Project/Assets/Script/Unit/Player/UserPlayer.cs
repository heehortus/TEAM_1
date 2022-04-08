using UnityEngine;

public class UserPlayer : Player
{
    public string _nickName;

    protected override void Awake()
    {
        base.Awake();
    }
    public bool ClearStage()
    {
        bool ret = false;
        var gameData = GameData.GetInstance();
        if (gameData.selectStage.Item2 <= 2)
        {
            if (gameData.selectStage.Item1 == 1)
            {
                if (gameData.possibleStage1[gameData.selectStage.Item2 + 1]) ret = true;
                gameData.possibleStage1[gameData.selectStage.Item2 + 1] = true;
            }
            else if (gameData.selectStage.Item1 == 2)
            {
                if (gameData.possibleStage2[gameData.selectStage.Item2 + 1]) ret = true;
                gameData.possibleStage2[gameData.selectStage.Item2 + 1] = true;
            }
            else if (gameData.selectStage.Item1 == 3)
            {
                if (gameData.possibleStage3[gameData.selectStage.Item2 + 1]) ret = true;
                gameData.possibleStage3[gameData.selectStage.Item2 + 1] = true;
            }
        }
        else if (gameData.selectStage.Item1 <= 2)
        {
            if (gameData.selectStage.Item1 == 1)
            {
                if (gameData.possibleStage2[1]) ret = true;
                gameData.possibleStage2[1] = true;
            }
            else if (gameData.selectStage.Item1 == 2)
            {
                if (gameData.possibleStage3[1]) ret = true;
                gameData.possibleStage3[1] = true;
            }
        }
        return ret;
    }
}