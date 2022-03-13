using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Turn_End_Button : MonoBehaviour
{
    public void ButtonClicked()
    {
        GameManager.GetInstance().sceneManager.currTurn += 1;
        Seed.Inst.isbatch = true;
        Debug.Log($"현재 턴 : {GameManager.GetInstance().sceneManager.currTurn}");
    }
}
