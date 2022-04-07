using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneChanger : MonoBehaviour
{
    private void Start()
    {
        GameObject audio = GameObject.Find("Audio");
        if (audio != null)
        {
            DontDestroyOnLoad(audio);
        }
        SaveManager.Save.LoadInfo();
    }
}
