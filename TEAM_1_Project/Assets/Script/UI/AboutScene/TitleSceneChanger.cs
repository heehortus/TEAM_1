using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneChanger : MonoBehaviour
{
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject audio = GameObject.Find("Audio");
        if (player != null)
        {
            DontDestroyOnLoad(player);
        }
        if (audio != null)
        {
            DontDestroyOnLoad(audio);
        }
    }
    void Update()
    {
        if(Input.anyKey)
        {
            LoadingSceneController.LoadScene("MainScene");
        }
    }
}
