using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
    static PlaceManager _place = GameManager.placeManager;
    [SerializeField] int attackpower;
    [SerializeField] int stealCoast;

    [SerializeField] public bool isSteal;
    public bool isPlayer;
    GameObject target_place;
    private void Start()
    {
        base.Init();
        character.sprite = GameManager.resourceManager.LoadSprite("squirrel");
        level = 1;
        Level();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Ability();
    }
    public override void Ability()
    {
        
        if (character.flipX == true) // 적군이 아군에게
        {
            var target_unit = gameObject;
            var target_unit2 = gameObject;
            for (int i = 0; i < 2; i++)
            {
                target_place = _place.getPlaceObject(true, this._currPlace.x, i);
                target_unit = GameManager.unitManager.GetUnit(target_place.GetComponent<PlaceObject>());
                if (target_unit != null)
                {
                    target_unit2 = target_unit;
                    break;
                }
            }
            if (target_unit2.GetComponent<Seed>() != null)
            {
                Seed seed = target_unit2.GetComponent<Seed>();
                GameManager.sceneManager.getPlayer(_currPlace)._currResource += Rip_Seed(seed);
                isSteal = true;
            }
            else if (target_unit2.GetComponent<Boom>() != null)
            {
                Boom boom = target_unit2.GetComponent<Boom>();
                GameManager.sceneManager.getPlayer(_currPlace)._currHP -= boom.damage;
            }
            else if(target_unit == null)
            {
                GameManager.sceneManager.getPlayer(_currPlace)._currHP -= attackpower;
            }
        }
        else if (character.flipX == false) // 아군이 적군에게
        {
            var target_unit = gameObject;
            var target_unit2 = gameObject;
            for (int i = 0; i < 2; i++) 
            {
                target_place = _place.getPlaceObject(false, this._currPlace.x, i);
                target_unit = GameManager.unitManager.GetUnit(target_place.GetComponent<PlaceObject>());
                if (target_unit != null)
                {
                    target_unit2 = target_unit;
                    break;
                }
                else if (target_unit == null)
                    target_unit2 = target_unit;
            }
            if (target_unit2 == null)
            {
                GameManager.sceneManager.getEnemy(_currPlace)._currHP -= attackpower;
            }
            else if (target_unit2.GetComponent<Seed>() != null)
            {
                Seed seed = target_unit2.GetComponent<Seed>();
                GameManager.sceneManager.getPlayer(_currPlace)._currResource += Rip_Seed(seed);
                isSteal = true;
            }
            else if(target_unit2.GetComponent<Boom>() != null)
            {
                Boom boom = target_unit2.GetComponent<Boom>();
                GameManager.sceneManager.getEnemy(_currPlace)._currHP -= boom.damage;
            }
        }
    }

    //if (target_unit.layer == LayerMask.NameToLayer("Seed"))
    public void Level()
    {
        switch (level)
        {
            case 1:
                attackpower = 1;
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

    public int Rip_Seed(Seed seed)
    {
        int result;
        result = seed.myresource;
        int index = GameManager.unitManager.UnitList.FindIndex(a => a == seed);
        GameManager.unitManager.UnitList.RemoveAt(index);
        seed.OnDestroy();
        return result;
    }

}
