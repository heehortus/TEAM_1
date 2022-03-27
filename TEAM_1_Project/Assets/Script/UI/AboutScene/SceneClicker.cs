using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneClicker : MonoBehaviour
{
    [SerializeField] string scenename;
    public GameObject ui_Setting;

    private void OnMouseDown()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        LoadingSceneController.LoadScene(scenename);
    }

    public void PushSettingButton()
    {
        Instantiate(ui_Setting);
    }
    public void PushExitGame()
    {
        Application.Quit();
    }
}
