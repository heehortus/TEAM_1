using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Turn_End_Button : MonoBehaviour
{
    public int turn = 1;
    public void ButtonClicked()
    {
        if (GameManager.battleManager._isBattle)
        {
            Debug.Log("전투 중 입니다.");
            return;
        }
        Audio.PlayEffect("ClickButton");
        GameManager.battleManager.StartBattle();
    }

    public void Clear()
    {
        turn = 1;
        GameManager.uiManager.changeTurn(turn);
    }
}
