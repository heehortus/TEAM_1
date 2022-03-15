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
            for (int i = 0; i < 2; i++) 
            {
                target_place = _place.getPlaceObject(true, this._currPlace.x, i);
                var pl = target_place.GetComponent<PlaceObject>();
                GameObject target_unit = GameManager.unitManager.GetUnit(pl);
                if (target_unit.layer == LayerMask.NameToLayer("Seed"))
                {
                    GameManager.sceneManager.getPlayer(_currPlace)._currResource += Rip_Seed(target_unit.GetComponent<Seed>());
                    isSteal = true;
                }
            }
        }
        else if (character.flipX == false) // 아군이 적군에게
        {
            var target_unit = gameObject;
            for (int i = 0; i < 2; i++) 
            {
                target_place = _place.getPlaceObject(false, this._currPlace.x, i);
                target_unit = GameManager.unitManager.GetUnit(target_place.GetComponent<PlaceObject>());
            }
            if (target_unit.GetComponent<Seed>() != null)
            {
                Seed seed = target_unit.GetComponent<Seed>();
                GameManager.sceneManager.getPlayer(_currPlace)._currResource += Rip_Seed(seed);
                isSteal = true;
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
        seed.OnDestroy();
        return result;
    }

}
