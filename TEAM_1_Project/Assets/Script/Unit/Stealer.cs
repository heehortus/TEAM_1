using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
    SpriteRenderer sprite;
    RaycastHit2D[] hit;
    [SerializeField] int attackpower;
    [SerializeField] int stealCoast;

    [SerializeField] public bool isSteal;
    public bool isPlayer;
    PlaceObject _place;
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
        Seed old_seed = new Seed();
        if (sprite.flipX == true)
        {
            hit = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), Vector2.right, 10, LayerMask.GetMask("Seed"));
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector3.right * 10, new Color(0, 1, 0));
            for (int i = 0; i < hit.Length; i++)
            {
                
                GameManager.GetInstance().sceneManager.Player._currResource += Rip_Seed(old_seed);
                isSteal = true;
                
                
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
                    GameManager.GetInstance().sceneManager.Player._currResource += Rip_Seed(old_seed);
                    isSteal = true;
                }
                else if (hit == null)
                {
                    
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

    public int Rip_Seed(Seed seed)
    {
        int result;
        result = seed.myresource;
        seed.OnDestroy();
        return result;
    }

}
