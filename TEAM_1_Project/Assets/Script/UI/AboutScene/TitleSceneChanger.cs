using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneChanger : MonoBehaviour
{
    private void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            DontDestroyOnLoad(player);
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
