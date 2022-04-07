using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour
{
    public int _maxHP;
    [SerializeField]
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

    public float BgmSound;
    public float EffectSound;
    
    private int costEarnAtEndOfTurn = 2;
    void Start()
    {

    }
    protected virtual void Awake()
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
}
