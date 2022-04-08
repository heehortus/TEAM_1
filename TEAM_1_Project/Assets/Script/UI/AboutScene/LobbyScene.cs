using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : MonoBehaviour
{
    public GameObject collections;
    public GameObject settings;
    public void PushSettingButton()
    {
        Instantiate(settings);
    }
    public void PushCollectionButton()
    {
        Audio.PlayEffect("ClickButton");
        Instantiate(collections);
    }
    public void PushStartButton()
    {
        Audio.PlayEffect("ClickButton");
        LoadingSceneController.LoadScene("StageScene");
    }
    public void TmpSaveInfo()
    {
        SaveManager.Save.SaveInfo();
    }
    public void TmpClearInfo()
    {
        SaveManager.Save.ClearInfo();
    }
}
