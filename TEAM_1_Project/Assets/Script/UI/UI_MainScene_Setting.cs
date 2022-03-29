using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainScene_Setting : MonoBehaviour
{
    public Scrollbar bgm;
    public Scrollbar effect;
    void Start()
    {
        bgm.value = Audio.Instance.bgmSound;
        effect.value = Audio.Instance.effectSound;
        bgm.onValueChanged.AddListener(Audio.ChangeBgmSound);
        effect.onValueChanged.AddListener(Audio.ChangeEffectSound);

        // tmp
        Audio.PlayBgm("TestBgm");
    }

    public void PushBackButton()
    {
        // tmp
        Audio.StopBgm();
        Audio.StopEffect();
        //

        Destroy(gameObject);
    }

    //tmp
    public void TestSound()
    {
        Audio.PlayEffect("TestEffect");
    }
}
