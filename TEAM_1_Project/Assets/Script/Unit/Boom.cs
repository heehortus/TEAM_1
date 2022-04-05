using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Unit//, IStoledUnit
{
    public int damage;
    [SerializeField] int growth;
    [SerializeField] int maxDamage;
    [SerializeField] public int playermaxCount;
    [SerializeField] public int enemymaxCount;
    public Define.BoomState currState = Define.BoomState.nothing;
    
    private ParticleSystem particle = null;
    float _effectTime = 1f;
    public override float Ability()
    {
        if (skill != null)
            skill.Skiil();
        GameManager.effectManager.UseSkill(Define.Effect.boomGetBigger, this);
        if (damage <= maxDamage)
        {
            damage += growth;
        }
        return _effectTime;
    }
    public override void Effect()
    {
        
    }

    public void boomAnimation()
    {
        if (particle != null)
        {
            particle.Play();
        }
    }

    public void getStoled(float time, Stealer stealer)
    {
        GameManager.effectManager.UseSkill(Define.Effect.stealerToBoom, stealer, this);
        getStoled(time);
    }

    public void getStoled(float time)
    {
        StartCoroutine(CoAttackedOrUsed(this, time));
        if (isBoomDamageMiss)
        {
            StartCoroutine(CoAttackedOrUsed(this, time));
            GameManager.sceneManager.getPlayer(_currPlace)._currHP -= damage;
        }
        GameManager.unitManager.isSteal = true;
    }

    private void Start()
    {
        base.Init();
        Level();
        try
        {
            particle = GetComponent<ParticleSystem>() ?? null;
        }
        catch
        {
            Debug.Log("이펙트가 없습니다.");
        }
        if (particle != null)
            particle.Stop();
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
