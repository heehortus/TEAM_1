using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Setting : MonoBehaviour
{
    public void PushSettingButton()
    {
        GameObject _uiSettingMenu = Instantiate(GameManager.resourceManager.LoadUI("UI_SettingMenu"));
        _uiSettingMenu.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
        _uiSettingMenu.name = "UI_SettingMenu";
    }
}
