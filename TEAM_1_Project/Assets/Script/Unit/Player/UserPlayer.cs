using UnityEngine;

public class UserPlayer : Player
{
    public string _nickName;

    protected override void Awake()
    {
        base.Awake();
    }
    public void ClearStage()
    {
        var gameData = GameData.GetInstance();
        if (gameData.selectStage.Item2 <= 2)
        {
            if (gameData.selectStage.Item1 == 1)
            {
                gameData.possibleStage1[gameData.selectStage.Item2 + 1] = true;
            }
            else if (gameData.selectStage.Item1 == 2)
            {
                gameData.possibleStage2[gameData.selectStage.Item2 + 1] = true;
            }
            else if (gameData.selectStage.Item1 == 3)
            {
                gameData.possibleStage3[gameData.selectStage.Item2 + 1] = true;
            }
        }
        else if (gameData.selectStage.Item1 <= 2)
        {
            if (gameData.selectStage.Item1 == 1)
            {
                gameData.possibleStage2[1] = true;
            }
            else if (gameData.selectStage.Item1 == 2)
            {
                gameData.possibleStage3[1] = true;
            }
            //gameData.possibleStage[gameData.selectStage.Item1 + 1, 1] = true;
        }
        SaveManager.Save.SaveInfo();
    }
}