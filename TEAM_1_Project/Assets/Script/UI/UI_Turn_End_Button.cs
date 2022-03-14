using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Turn_End_Button : MonoBehaviour
{
    int turn = 1;
    public void ButtonClicked()
    {
        turn++;
        GameManager.GetInstance().uiManager.changeTurn(turn);
    }

    public void Clear()
    {
        turn = 1;
        GameManager.GetInstance().uiManager.changeTurn(turn);
    }
}
