using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Setting : MonoBehaviour
{
    public void PushBattleSettingButton()
    {
        GameObject _uiSettingMenu = Instantiate(ResourceManager.LoadUI("UI_BattleScene_Setting"));
        _uiSettingMenu.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
        _uiSettingMenu.name = "UI_BattleScene_Setting";
    }
    public void PushMainSettingButton()
    {
        GameObject _uiSettingMenu = Instantiate(ResourceManager.LoadUI("UI_MainScene_Setting"));
        _uiSettingMenu.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
        _uiSettingMenu.name = "UI_BattleScene_Setting";
    }
    public void PushLobbySettingButton()
    {
        GameObject _uiSettingMenu = Instantiate(ResourceManager.LoadUI("UI_Lobby_Scene_Setting"));
        _uiSettingMenu.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
        _uiSettingMenu.name = "UI_BattleScene_Setting";
    }
}
