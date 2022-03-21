using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScene : MonoBehaviour
{
    public Player _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Update()
    {
        
    }
    public void PushStageButton(int num)
    {
        _player._selectStage = num;
        LoadingSceneController.LoadScene("BattleScene");
    }
    public void PushBackButton()
    {
        LoadingSceneController.LoadScene("MainScene");
    }
}
