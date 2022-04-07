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
        Destroy(gameObject);
    }
    public void PushMainButton()
    {
        LoadingSceneController.LoadScene("TitleScene");
    }
    public void PushExitButton()
    {
        Application.Quit();
    }
}
