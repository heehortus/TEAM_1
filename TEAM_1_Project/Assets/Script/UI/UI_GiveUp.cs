using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GiveUp : MonoBehaviour
{
    public void PushYesButton()
    {
        LoadingSceneController.LoadScene("MainScene");
    }
    public void PushNoButton()
    {
        Destroy(gameObject);
    }
}
