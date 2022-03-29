using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BattleScene_Setting : MonoBehaviour
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
        GameObject ui_giveup = Instantiate(GameManager.resourceManager.LoadUI("UI_GiveUp"));
        ui_giveup.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
    }
    public void PushExitButton()
    {
        Application.Quit();
    }
}
