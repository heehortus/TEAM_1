using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Defeat : MonoBehaviour
{
    public void PushReStartButton()
    {
        LoadingSceneController.LoadScene("BattleScene");
    }
    public void PushLobbyButton()
    {
        LoadingSceneController.LoadScene("LobbyScene");
    }
}
