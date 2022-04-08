using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SettingMenu : MonoBehaviour
{
    public void PushResumeButton()
    {
        Audio.PlayEffect("ClickButton");
        Destroy(this.gameObject);
    }
    public void PushLeaveButton()
    {
        Audio.PlayEffect("ClickButton");
        LoadingSceneController.LoadScene("StageScene");
    }
}
