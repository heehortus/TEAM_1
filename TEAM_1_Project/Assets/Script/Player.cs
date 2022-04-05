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
                if (getAnimation() != null)
                {
                    getAnimation().getAtacked();
                }
            }
            currHP = value;
        }
    }
    public int _maxResource;
    public int _currResource;
    //public Dictionary<string, bool> _unitDic = new Dictionary<string, bool>();

    //public List<string> noHaveUnit = new List<string>() { "SeedUnit2", "SeedUnit3", "BoomUnit2", "BoomUnit3", "StealerUnit2", "StealerUnit3" };

    //public bool[,] _possibleStage = new bool[4,4];

    //public (int ,int) _selectStage;

    public float BgmSound;
    public float EffectSound;
    
    private int costEarnAtEndOfTurn = 2;
    void Start()
    {

    }
    private void Awake()
    {
        _currHP = _maxHP;
        _currHP = _maxHP;
        _currResource = 10;
    }

    public void endBattle() {
        _currResource += costEarnAtEndOfTurn;
    }

    public Action getAnimation() {
        try
        {
            return GetComponent<Action>();
        }
        catch
        {
            return null;
        }
    }

    void Update()
    {
        if(_maxHP == 0)
        {

        }
    }

    public void ClearStage()
    {
        var gameData = GameData.GetInstance();
        if (gameData.selectStage.Item2 <= 2)
        {
            gameData.possibleStage[gameData.selectStage.Item1, gameData.selectStage.Item2 + 1] = true;
        }
        else if (gameData.selectStage.Item1 <= 2)
        {
            gameData.possibleStage[gameData.selectStage.Item1 + 1, 1] = true;
        }
    }
}
