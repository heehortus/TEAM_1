using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Turn_End_Button : MonoBehaviour
{
    public int turn = 1;
    public void ButtonClicked()
    {
        if (GameManager.GetInstance().battleManager._isBattle)
        {
            Debug.Log("전투 중 입니다.");
            return;
        }
        GameManager.GetInstance().battleManager.StartBattle();
    }

    public void Clear()
    {
        turn = 1;
        GameManager.GetInstance().uiManager.changeTurn(turn);
    }
}
