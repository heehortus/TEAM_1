using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
    [SerializeField] public int attackpower;
    [SerializeField] int stealCoast;

    [SerializeField] public bool isSteal;
    public bool isPlayer;
    GameObject target_place;

    float _attackTime = 1f;
    float _stealTime = 1.5f;
    public Define.StealerState currState = Define.StealerState.nothing;

    public Unit target;
    public Vector3 targetPos;

    private void Start()
    {
        base.Init();
        //character.sprite = GameManager.resourceManager.LoadSprite("squirrel");
        level = 1;
        Level();
    }
    private void Update()
    {
        UpdateState();
    }
    void UpdateState()
    {
        switch (currState)
        {
            case Define.StealerState.nothing:
                UpdateNothing();
                break;
            case Define.StealerState.attack:
                UpdateAttack();
                break;
            case Define.StealerState.stealSeed:
                UpdateStealSead();
                break;
            case Define.StealerState.stealBoom:
                UpdateStealBoom();
                break;
        }
    }
    public override float Ability()
    {
        Debug.Log("Dd");
        float ret = 0;
        if (skill != null && _name != "Stealer1")
        {
            skill.Skiil();
        }
        isPlayer = true;
        GameObject target_unit = null;
        GameObject target_unit2 = null;
        GameObject target_place;
        isPlayer = false;
        if (isBackCheck)
        {
            Debug.Log("if문 들어옴");
            target_place = GameManager.placeManager.getPlaceObject(!_currPlace.isPlayerPlace, this._currPlace.x, 1);
            target_unit = GameManager.unitManager.GetUnit(target_place.GetComponent<PlaceObject>());
            if (target_unit != null)
            {
                if (target_unit.GetComponent<Stealer>() == null)
                {
                    if (target_unit.GetComponent<Unit>().valid)
                    {
                        target_unit2 = target_unit;
                    }
                }
            }
            else if (target_unit == null)
            {
                target_place = GameManager.placeManager.getPlaceObject(!_currPlace.isPlayerPlace, this._currPlace.x, 0);
                target_unit = GameManager.unitManager.GetUnit(target_place.GetComponent<PlaceObject>());
                if (target_unit == null)
                    target_unit2 = target_unit;
                else
                {
                    if (target_unit.GetComponent<Stealer>() == null)
                    {
                        if (target_unit.GetComponent<Unit>().valid)
                        {
                            target_unit2 = target_unit;
                        }
                    }
                }

            }
        }
        else
        {
            //Debug.Log("플레이어");
            for (int i = 0; i < 2; i++)
            {
                target_place = GameManager.placeManager.getPlaceObject(false, this._currPlace.x, i);
                target_unit = GameManager.unitManager.GetUnit(target_place.GetComponent<PlaceObject>());
                if (target_unit != null)
                {
                    if (target_unit.GetComponent<Stealer>() == null)
                    {
                        if (target_unit.GetComponent<Unit>().valid)
                        {
                            target_unit2 = target_unit;
                            break;
                        }
                    }
                }
            }
        }
        if (stealCount > 0)
        {
            Debug.Log("Ddd");
            if (target_unit2 == null || target_unit2.GetComponent<Stealer>() != null)
            {
                ret = _attackTime;
                GameManager.effectManager.UseSkill(Define.Effect.stealer, this);

                GameManager.sceneManager.getEnemy(_currPlace)._currHP -= attackpower;
            }
            else
            {
                (target_unit2.GetComponent<Unit>() as IStoledUnit).getStoled(_stealTime,this);
                ret = _stealTime;
            }
        }
        return ret;
    }

    //if (target_unit.layer == LayerMask.NameToLayer("Seed"))
    public void Level()
    {
        switch (level)
        {
            case 1:
                attackpower = 30;
                stealCoast = 1;
                break;
            case 2:
                attackpower = 3;
                stealCoast = 3;
                break;
            case 3:
                attackpower = 5;
                stealCoast = 5;
                break;
        }
    }

    void UpdateNothing()
    {

    }
    void UpdateAttack()
    {
        if (_currTime > _attackTime)
        {
            currState = Define.StealerState.nothing;
            _currTime = 0;
            return;
        }
        _currTime += Time.deltaTime;
        if (_currTime <= _attackTime / 2)
        {
            gameObject.transform.localScale += Vector3.one * _effectSize * Time.deltaTime;
        }
        else
        {
            gameObject.transform.localScale -= Vector3.one * _effectSize * Time.deltaTime;
        }
    }
    void UpdateStealSead()
    {
        if (_currTime > _stealTime)
        {
            currState = Define.StealerState.nothing;
            _currTime = 0;
            return;
        }
        _currTime += Time.deltaTime;
        Vector3 dirVec = (targetPos - transform.position).normalized;
        float dist = (targetPos - transform.position).magnitude;
        if (_currTime <= _stealTime / 2)
        {
            transform.position += dirVec * dist * Time.deltaTime * 1.5f;
        }
        else
        {
            if (_unitCamp == Define.UnitCamp.playerUnit)
            {
                target.transform.position = transform.position + Vector3.right;
            }
            else
            {
                target.transform.position = transform.position + Vector3.left;
            }
            transform.position -= dirVec * dist * Time.deltaTime * 1.5f;
        }
    }
    void UpdateStealBoom()
    {
        if (_currTime > _stealTime)
        {
            currState = Define.StealerState.nothing;
            _currTime = 0;
            return;
        }
        _currTime += Time.deltaTime;
        Vector3 dirVec = (targetPos - transform.position).normalized;
        float dist = (targetPos - transform.position).magnitude;
        if (_currTime <= _stealTime / 2)
        {
            transform.position += dirVec * dist * Time.deltaTime * 1.5f;
        }
        else
        {
            if (_unitCamp == Define.UnitCamp.playerUnit)
            {
                target.transform.position = transform.position + Vector3.right;
            }
            else
            {
                target.transform.position = transform.position + Vector3.left;
            }
            transform.position -= dirVec * dist * Time.deltaTime * 1.5f;
        }
    }
}
