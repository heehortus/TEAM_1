using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageScene : MonoBehaviour
{
    public Player _player;
    public Image[] stage1Imags = new Image[4];
    public Image[] stage2Imags = new Image[4];
    public Image[] stage3Imags = new Image[4];
    public GameObject settings;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        Init();
    }
    void Init()
    {
        for(int i = 1; i <= 3; i++)
        {
            if (!_player._possibleStage[1, i])
            {
                stage1Imags[i].color = Color.red;
            }
            if (!_player._possibleStage[2, i])
            {
                stage2Imags[i].color = Color.red;
            }
            if (!_player._possibleStage[3, i])
            {
                stage3Imags[i].color = Color.red;
            }
        }
        _player._currHP = _player._maxHP;
    }
    public void PushStage1Button(int num)
    {
        if (!_player._possibleStage[1, num]) return;
        _player._selectStage = (1, num);
        LoadingSceneController.LoadScene("BattleScene");
    }
    public void PushStage2Button(int num)
    {
        if (!_player._possibleStage[2, num]) return;
        _player._selectStage = (2, num);
        LoadingSceneController.LoadScene("BattleScene");
    }
    public void PushStage3Button(int num)
    {
        if (!_player._possibleStage[3, num]) return;
        _player._selectStage = (3, num);
        LoadingSceneController.LoadScene("BattleScene");
    }
    public void PushBackButton()
    {
        LoadingSceneController.LoadScene("LobbyScene");
    }
    public void PushSettingButton()
    {
        Instantiate(settings);
    }
}
