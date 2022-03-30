using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Unit
{
    public int damage;
    [SerializeField] int growth;
    [SerializeField] int maxTurn;

    public Define.BoomState currState = Define.BoomState.nothing;
    float _effectTime = 1f;
    public override float Ability()
    {
        if(passedTurn >= maxTurn)
        {
            GameManager.effectManager.UseSkill(Define.Effect.boomGetBoom, this);
            GameManager.sceneManager.getEnemy(_currPlace)._currHP -= damage;
            StartCoroutine(CoAttackedOrUsed(this, _effectTime));
        }
        else
        {
            GameManager.effectManager.UseSkill(Define.Effect.boomGetBigger, this);
            damage += growth;
        }
        passedTurn++;
        return _effectTime;
    }
    private void Start()
    {
        base.Init();
        Level();
    }
    private void Update()
    {
        switch (currState)
        {
            case Define.BoomState.nothing:
                {
                    break;
                }
            case Define.BoomState.skill:
                {
                    if (_currTime > _effectTime)
                    {
                        currState = Define.BoomState.nothing;
                        _currTime = 0;
                        break;
                    }
                    _currTime += Time.deltaTime;
                    if (_currTime <= _effectTime / 2)
                    {
                        gameObject.transform.localScale += Vector3.one * _effectSize * Time.deltaTime;
                    }
                    else
                    {
                        gameObject.transform.localScale -= Vector3.one * _effectSize * Time.deltaTime;
                    }
                }
                break;
            case Define.BoomState.boom:
                {
                    break;
                }
        }
    }
    void Level()
    {
        switch (level)
        {
            case 1:
                damage = 3;
                growth = 0;
                break;
            case 2:
                damage = 5;
                growth = 1;
                break;
            case 3:
                damage = 7;
                growth = 2;
                break;
        }
    }
}
