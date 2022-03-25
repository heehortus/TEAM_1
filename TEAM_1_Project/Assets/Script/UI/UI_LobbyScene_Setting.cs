using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LobbyScene_Setting : MonoBehaviour
{
    Audio audio;
    public Scrollbar bgm;
    public Scrollbar effect;
    void Start()
    {
        audio = GameObject.Find("Audio").GetComponent<Audio>();
        bgm.value = audio.bgmSound;
        effect.value = audio.effectSound;
        bgm.onValueChanged.AddListener(ChangeBgm);
        effect.onValueChanged.AddListener(ChangeEffect);
    }
    public void PushBackButton()
    {
        Destroy(gameObject);
    }
    public void PushMainButton()
    {
        LoadingSceneController.LoadScene("MainScene");
    }
    public void PushExitButton()
    {
        Application.Quit();
    }
    void ChangeBgm(float value)
    {
        audio.bgmSound = value;
        audio.bgm.volume = audio.bgmSound;
    }
    void ChangeEffect(float value)
    {
        audio.effectSound = value;
        audio.effect.volume = audio.effectSound;
    }
}
