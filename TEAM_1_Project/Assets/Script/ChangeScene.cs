using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

[System.Serializable]
public class ChangeScene : MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKeyDown)
        {
            Changescene(2);
        }
    }



    public void Changescene(int idx)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(idx);
        switch (idx)
        {
            case 0:
                
                break;
            case 1:

                break;
            case 2:

                break;
        }
    }

}
