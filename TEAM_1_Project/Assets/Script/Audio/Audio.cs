using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    static Audio s_instance;
    public static Audio Instance { get { return s_instance; } }
    public static AudioSource BGM { get { return s_instance.bgm; } }
    public static AudioSource EFFECT { get { return s_instance.effect; } }
    [SerializeField]
    AudioSource bgm;
    [SerializeField]
    AudioSource effect;
    public float bgmSound = 0.5f;
    public float effectSound = 0.5f;
    private void Awake()
    {
        s_instance = this;
        Audio.PlayBgm("MainBgm");
    }
    public static void ChangeBgmSound(float value)
    {
        s_instance.bgmSound = value;
        s_instance.bgm.volume = value;
    }
    public static void ChangeEffectSound(float value)
    {
        s_instance.effectSound = value;
        s_instance.effect.volume = value;
    }
    public static void PlayBgm(string path)
    {
        AudioClip bgmClip = Resources.Load<AudioClip>($"Sounds/Bgm/{path}");
        if (bgmClip == null)
        {
            Debug.Log($"Failed to Load : {path}");
            return;
        }
        s_instance.bgm.Stop();
        s_instance.bgm.clip = bgmClip;
        s_instance.bgm.Play();
    }
    public static void PlayEffect(string path)
    {
        AudioClip effectClip = Resources.Load<AudioClip>($"Sounds/Effect/{path}");
        if (effectClip == null)
        {
            Debug.Log($"Failed to Load : {path}");
            return;
        }
        s_instance.effect.PlayOneShot(effectClip);
    }
    public static void StopBgm()
    {
        s_instance.bgm.Stop();
    }
    public static void StopEffect()
    {
        s_instance.effect.Stop();
    }
}
