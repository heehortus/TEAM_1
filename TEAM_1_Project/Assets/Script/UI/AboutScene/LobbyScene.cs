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
        Instantiate(collections);
    }
    public void PushStartButton()
    {
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
