using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UI_Setting : MonoBehaviour
{
    public void PushBattleSettingButton()
    {
        Audio.PlayEffect("ClickButton");
        GameObject _uiSettingMenu = Instantiate(ResourceManager.LoadUI("UI_LobbyScene_Setting"));
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BattleScene")
            _uiSettingMenu.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
        _uiSettingMenu.name = "UI_BattleScene_Setting";
    }
    public void PushMainSettingButton()
    {
        Audio.PlayEffect("ClickButton");
        GameObject _uiSettingMenu = Instantiate(ResourceManager.LoadUI("UI_MainScene_Setting"));
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BattleScene")
            _uiSettingMenu.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
        _uiSettingMenu.name = "UI_BattleScene_Setting";
    }
    public void PushLobbySettingButton()
    {
        Audio.PlayEffect("ClickButton");
        GameObject _uiSettingMenu = Instantiate(ResourceManager.LoadUI("UI_LobbyScene_Setting"));
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "BattleScene")
            _uiSettingMenu.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
        _uiSettingMenu.name = "UI_BattleScene_Setting";
    }
}
