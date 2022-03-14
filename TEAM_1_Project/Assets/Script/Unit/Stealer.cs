using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
    static PlaceManager _place = GameManager.GetInstance().placeManager;
    SpriteRenderer sprite;
    [SerializeField] int attackpower;
    [SerializeField] int stealCoast;
    static Stealer stealer;
    [SerializeField] public bool isSteal;
    public bool isPlayer;
    GameObject target_place;

    void Awake() {
        character = gameObject.GetComponent<SpriteRenderer>();
        character.sprite = GameManager.GetInstance().resourceManager.LoadSprite("squirrel");
        stealer = this;
	}
    static public Stealer GetInstance()
    {
        return stealer;
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
        if (sprite.flipX == true)
        {
            for(int i = 2; i<4; i++)
            {
                target_place = _place.getPlaceObject(false, i, this._currPlace.y);
                var pl = target_place.GetComponent<PlaceObject>();
                GameObject target_unit = UnitManager.Inst.GetUnit(pl);
                if (target_unit.layer == LayerMask.NameToLayer("Seed"))
                {
                    if (stealCoast < Seed.Inst.ReturnCoast())
                    {
                        Player.GetInstance()._currResource += stealCoast;
                        isSteal = true;
                    }
                    else
                    {
                        Player.GetInstance()._currResource += Seed.Inst.ReturnCoast();
                        isSteal = true;
                    }
                }
            }

        }
        else if (sprite.flipX == false)
        {
            for (int i = 2; i < 4; i++)
            {
                target_place = _place.getPlaceObject(false, i, this._currPlace.y);
                var pl = target_place.GetComponent<PlaceObject>();
                GameObject target_unit = UnitManager.Inst.GetUnit(pl);
                if (target_unit.layer == LayerMask.NameToLayer("Seed"))
                {
                    if (stealCoast < Seed.Inst.ReturnCoast())
                    {
                        Player.GetInstance()._currResource += stealCoast;
                        isSteal = true;
                    }
                    else
                    {
                        Player.GetInstance()._currResource += Seed.Inst.ReturnCoast();
                        isSteal = true;
                    }
                }
            }

        }
    }
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


}
