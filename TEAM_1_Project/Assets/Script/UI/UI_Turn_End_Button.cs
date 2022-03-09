using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Turn_End_Button : MonoBehaviour
{
    public void ButtonClicked()
    {
        GameManager.GetInstance().sceneManager.currTurn += 1;
        Debug.Log($"ÇöÀç ÅÏ : {GameManager.GetInstance().sceneManager.currTurn}");
    }
}
