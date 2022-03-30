using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Unit
{
    public int damage;
    [SerializeField] int growth;
    [SerializeField] int maxDamage;

    public Define.BoomState currState = Define.BoomState.nothing;
    float _effectTime = 1f;
    public override float Ability()
    {
        if (skill != null)
            skill.Skiil();
        GameManager.effectManager.UseSkill(Define.Effect.boom, this);
        if (damage <= maxDamage)
        {
            damage += growth;
        }
        return _effectTime;
    }
    public override void Effect()
    {
        
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
