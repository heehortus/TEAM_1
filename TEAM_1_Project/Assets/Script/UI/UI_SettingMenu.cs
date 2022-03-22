using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SettingMenu : MonoBehaviour
{
    public void PushResumeButton()
    {
        Destroy(this.gameObject);
    }
    public void PushLeaveButton()
    {
        LoadingSceneController.LoadScene("StageScene");
    }
}
