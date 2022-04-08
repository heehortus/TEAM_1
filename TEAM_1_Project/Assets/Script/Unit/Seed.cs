using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Unit, IStoledUnit
{
    public int myresource;
    public int _growth;
    public int maxLevel = 3;
    public SpriteRenderer seedSprite;
    public int Turn = 0;
    float _effectTime = 1f;

    public Define.SeedState currState = Define.SeedState.nothing;
    public override float Ability()
    {
        if (skill != null)
            skill.Skiil();
        GameManager.effectManager.UseSkill(Define.Effect.seed, this);
        if(level == maxLevel) {
            myresource += _growth;
            GameManager.sceneManager.getPlayer(_currPlace)._currResource += myresource;
            StartCoroutine(CoAttackedOrUsed(this, _effectTime));
            return _effectTime;
        }
        level += 1;
        return _effectTime;
    }

    public void getStoled(float time, Stealer stealer)
    {
        GameManager.effectManager.UseSkill(Define.Effect.stealerToSeed, stealer, this);
        StartCoroutine(CoAttackedOrUsed(this, time));
        GameManager.sceneManager.getPlayer(stealer._currPlace)._currResource += myresource;
        if (isSeedStealDamage)
            GameManager.sceneManager.getEnemy(stealer._currPlace)._currHP -= 2;
        GameManager.unitManager.isSteal = true;
    }
    
    private void Start()
    {
        seedSprite = GetComponent<SpriteRenderer>();
        base.Init();
    }

    private void Update()
    {
        switch (currState)
        {
            case Define.SeedState.nothing:
                {
                    break;
                }
            case Define.SeedState.skill:
                {
                    if (_currTime > _effectTime)
                    {
                        currState = Define.SeedState.nothing;
                        _currTime = 0;
                        break;
                    }
                    _currTime += Time.deltaTime;
                    if (_currTime <= _effectTime/2)
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
}
