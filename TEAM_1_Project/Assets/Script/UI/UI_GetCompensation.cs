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
        SaveManager.Save.SaveInfo();
        pushed = true;
        GameData.GetInstance().noHaveUnit.Remove(unitName);
        GameData.GetInstance()._unitDic[unitName] = true;

        Debug.Log(unitName);
        Destroy(gameObject);
    }
}
