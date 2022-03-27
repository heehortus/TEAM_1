using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string _nickName;
    public int _maxHP;
    private int currHP;
    public int _currHP {
        get {return currHP;}
        set {
            if(value<currHP) {
                GameManager.sceneManager.Player.getAnimation().getAtacked();
            }
            currHP = value;
        }
    }
    public int _maxResource;
    public int _currResource;
    public Dictionary<string, bool> _unitDic = new Dictionary<string, bool>();

    public bool[,] _possibleStage = new bool[4,4];

    public (int ,int) _selectStage;

    public float BgmSound;
    public float EffectSound;
    
    private int costEarnAtEndOfTurn = 2;
    void Start()
    {

    }
    private void Awake()
    {
        _currHP = _maxHP;
        _unitDic.Add("SeedUnit1", true);
        _unitDic.Add("SeedUnit2", false);
        _unitDic.Add("SeedUnit3", false);

        _unitDic.Add("BoomUnit1", true);
        _unitDic.Add("BoomUnit2", false);
        _unitDic.Add("BoomUnit3", false);

        _unitDic.Add("StealerUnit1", true);
        _unitDic.Add("StealerUnit2", false);
        _unitDic.Add("StealerUnit3", false);

        _unitDic.Add("Unit", false); // 일단 UnitFactory에 있는 유닛들만 임시로 보유하도록 설정

        _possibleStage[1,1] = true;
    }

    public void endBattle() {
        _currResource += costEarnAtEndOfTurn;
    }

    public Action getAnimation() {
        return GetComponent<Action>();
    }

    void Update()
    {
        if(_maxHP == 0)
        {

        }
    }
}
