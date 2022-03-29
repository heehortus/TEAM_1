using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Victory : MonoBehaviour
{
    public void PushNextButton()
    {
        Player player = GameManager.sceneManager.Player;
        if (player._selectStage.Item2 <= 2)
        {
            player._selectStage.Item2 += 1;
            LoadingSceneController.LoadScene("BattleScene");
        }
        else if (player._selectStage.Item1 <= 2)
        {
            player._selectStage.Item1 += 1;
            player._selectStage.Item2 = 1;
            LoadingSceneController.LoadScene("BattleScene");
        }
    }
    public void PushLobbyButton()
    {
        LoadingSceneController.LoadScene("LobbyScene");
    }
}
