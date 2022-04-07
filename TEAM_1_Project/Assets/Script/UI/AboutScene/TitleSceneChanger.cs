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
    void Update()
    {
        if(Input.anyKey)
        {
            if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            LoadingSceneController.LoadScene("MainScene");
        }
    }
}
