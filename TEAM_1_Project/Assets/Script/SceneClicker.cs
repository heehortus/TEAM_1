using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneClicker : MonoBehaviour
{
    [SerializeField] string scenename;

    private void OnMouseDown()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        LoadingSceneController.LoadScene(scenename);
    }
}
