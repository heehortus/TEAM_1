using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LobbyScene_Setting : MonoBehaviour
{
    public Scrollbar bgm;
    public Scrollbar effect;
    void Start()
    {
        bgm.value = Audio.Instance.bgmSound;
        effect.value = Audio.Instance.effectSound;
        bgm.onValueChanged.AddListener(Audio.ChangeBgmSound);
        effect.onValueChanged.AddListener(Audio.ChangeEffectSound);
    }
    public void PushBackButton()
    {
        Audio.PlayEffect("ClickButton");
        Destroy(gameObject);
    }
    public void PushMainButton()
    {
        Audio.PlayEffect("ClickButton");
        LoadingSceneController.LoadScene("LobbyScene");
    }
    public void PushExitButton()
    {
        Audio.PlayEffect("ClickButton");
        Application.Quit();
    }
}
