using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Victory : MonoBehaviour
{
    public void PushNextButton()
    {
        GameData gameData = GameData.GetInstance();
        if (gameData.selectStage.Item2 <= 2)
        {
            gameData.selectStage.Item2 += 1;
            LoadingSceneController.LoadScene("BattleScene");
        }
        else if (gameData.selectStage.Item1 <= 2)
        {
            gameData.selectStage.Item1 += 1;
            gameData.selectStage.Item2 = 1;
            LoadingSceneController.LoadScene("BattleScene");
        }
    }
    public void PushLobbyButton()
    {
        LoadingSceneController.LoadScene("LobbyScene");
    }
}
