using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
    static PlaceManager _place = GameManager.GetInstance().placeManager;
    SpriteRenderer sprite;
    [SerializeField] int attackpower;
    [SerializeField] int stealCoast;

    [SerializeField] public bool isSteal;
    public bool isPlayer;
    GameObject target_place;

    void Awake() {
        character = gameObject.GetComponent<SpriteRenderer>();
        character.sprite = GameManager.GetInstance().resourceManager.LoadSprite("squirrel");
	}
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
        
        if (sprite.flipX == true) // 적군이 아군에게
        {
            for (int i = 0; i < 2; i++) 
            {
                target_place = _place.getPlaceObject(true, this._currPlace.x, i);
                var pl = target_place.GetComponent<PlaceObject>();
                GameObject target_unit = UnitManager.Inst.GetUnit(pl);
                if (target_unit.layer == LayerMask.NameToLayer("Seed"))
                {
                    GameManager.GetInstance().sceneManager.Player._currResource += Rip_Seed(target_unit.GetComponent<Seed>());
                    isSteal = true;
                }
            }
        }
        else if (sprite.flipX == false) // 아군이 적군에게
        {
            for (int i = 2; i < 4; i++) 
            {
                target_place = _place.getPlaceObject(false, this._currPlace.x, i);
                PlaceObject pl = target_place.GetComponent<PlaceObject>();
                GameObject target_unit = UnitManager.Inst.GetUnit(pl);
                if (target_unit.GetComponent<Seed>() != null) 
                {
                    Seed seed = target_unit.GetComponent<Seed>();
                    GameManager.GetInstance().sceneManager.Player._currResource += Rip_Seed(seed);
                    isSteal = true;
                }
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
