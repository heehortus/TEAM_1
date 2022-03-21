using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageScene : MonoBehaviour
{
    public Player _player;
    public Image[] _stageImgs = new Image[6];
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        Init();
    }
    void Init()
    {
        for(int i = 1; i <= 5; i++)
        {
            if (!_player._possibleStage[i])
            {
                _stageImgs[i].color = Color.red;
            }
        }
    }
    public void PushStageButton(int num)
    {
        if (!_player._possibleStage[num]) return;
        _player._selectStage = num;
        LoadingSceneController.LoadScene("BattleScene");
    }
    public void PushBackButton()
    {
        LoadingSceneController.LoadScene("MainScene");
    }
}
