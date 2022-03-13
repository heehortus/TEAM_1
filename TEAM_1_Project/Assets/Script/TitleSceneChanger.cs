using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneChanger : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKey)
        {
            LoadingSceneController.LoadScene("MainScene");
        }
    }
}
