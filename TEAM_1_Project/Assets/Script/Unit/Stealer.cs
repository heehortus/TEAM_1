using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
    SpriteRenderer sprite;
    RaycastHit2D[] hit;
    [SerializeField] int attackpower;
    [SerializeField] int stealCoast;
    static Stealer stealer;
    [SerializeField] public bool isSteal;
    public bool isPlayer;
    PlaceObject _place;
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
            hit = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.right, 10, LayerMask.GetMask("Seed"));
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector3.right * 10, new Color(0, 1, 0));
            for (int i = 0; i < hit.Length; i++)
            {
                RaycastHit2D hits = hit[i];
                if (hits.collider != null && hits.collider.gameObject.tag == "Enemy")
                {
                    Debug.Log("dd");
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
                else if (hit == null)
                {
                    Player.GetInstance()._currHP -= attackpower;
                }
            }

        }
        else if (sprite.flipX == false)
        {
            isPlayer = true;
            hit = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.right, 10, LayerMask.GetMask("Seed"));
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector3.right * 10, new Color(0, 1, 0));
            for (int i = 0; i < hit.Length; i++) 
            {
                RaycastHit2D hits = hit[i];
                if (hits.collider != null && hits.collider.gameObject.tag == "Enemy")
                {
                    Debug.Log("dd");
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
                else if (hit == null)
                {
                    Player.GetInstance()._currHP -= attackpower;
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
