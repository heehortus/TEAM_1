using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GetCompensation : MonoBehaviour
{
    public GameObject OutLine;
    public string unitName;
    bool pushed = false;
    public void PushButton()
    {
        if (pushed) return;
        pushed = true;
        GameManager.sceneManager.Player.noHaveUnit.Remove(unitName);
        GameManager.sceneManager.Player._unitDic[unitName] = true;

        Debug.Log(unitName);
        Destroy(gameObject, 2);
    }
}
