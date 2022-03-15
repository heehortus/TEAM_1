using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Unit
{
    public int myresource { get; set; } = 1;
    private int maxLevel {get;} = 3;
    public override void Ability()
    {
        if(myresource == maxLevel) {
            GameManager.sceneManager.getPlayer(_currPlace)._currResource += myresource;
            Destroy(this);
        }
        myresource += 1;
    }
    private void Start()
    {
        base.Init();
    }

    
    
    
}
