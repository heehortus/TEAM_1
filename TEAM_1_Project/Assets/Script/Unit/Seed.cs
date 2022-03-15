using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Unit
{
    public int myresource { get; set; } = 1;
    GameObject findStealer = null;
    public override void Ability()
    {

        myresource += 1;
        
    }
    private void Start()
    {
        character = gameObject.GetComponent<SpriteRenderer>();
        if (UnitManager.Inst.isPlace)
            gameObject.tag = "Player";
        else
            gameObject.tag = "Enemy";
    }

    
    
    
}
