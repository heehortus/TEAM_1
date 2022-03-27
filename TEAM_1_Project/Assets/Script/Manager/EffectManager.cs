using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public void Init()
    {

    }
    public void OnUpdate()
    {

    }
    public void UseSkill(Define.Effect effect, Unit caster, Unit target = null)
    {
        switch (effect)
        {
            case Define.Effect.seed:
                {
                    Debug.Log("seed Effect");
                    (caster as Seed).currState = Define.SeedState.skill;
                }
                break;
            case Define.Effect.boom:
                {
                    Debug.Log("boom Effect");
                    (caster as Boom).currState = Define.BoomState.skill;
                }
                break;
            case Define.Effect.stealer:
                {
                    Debug.Log("stealer Effect");
                    (caster as Stealer).currState = Define.StealerState.attack;
                }
                break;
            case Define.Effect.stealerToSeed:
                {
                    Debug.Log("stealerToSeed Effect");
                    (caster as Stealer).target = target;
                    (caster as Stealer).targetPos = target.transform.position;
                    (caster as Stealer).currState = Define.StealerState.stealSeed;
                }
                break;
            case Define.Effect.stealerToBoom:
                {
                    Debug.Log("stealerToBoom Effect");
                    (caster as Stealer).target = target;
                    (caster as Stealer).targetPos = target.transform.position;
                    (caster as Stealer).currState = Define.StealerState.stealBoom;
                }
                break;
        }
    }
}
