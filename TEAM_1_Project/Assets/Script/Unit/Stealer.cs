using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
    SpriteRenderer sprite;
    RaycastHit2D righthit;
    RaycastHit2D lefthit;
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public override void Ability()
    {
        if(sprite.flipX == true)
        {
             righthit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, 2, LayerMask.GetMask("Seed"));
            if (righthit.collider != null)
            {
                Seed.Inst.ReturnCoast();
            }
            else
            {
                //플레이어에게 데미지
            }
            
        }
        else if(sprite.flipX == false)
        {
             lefthit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 2, LayerMask.GetMask("Seed"));
            if(lefthit.collider != null)
            {

            }
            else
            {

            }

        }
    }
}
