using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Unit
{
    public int myresource;
    public int _growth;
    public int maxLevel = 3;
    public override void Ability()
    {
        if(level == maxLevel) {
            myresource += _growth;
            GameManager.sceneManager.getPlayer(_currPlace)._currResource += myresource;
            GameManager.unitManager.DeleteUnit(this);
            return;
        }
        level += 1;
    }
    private void Start()
    {
        base.Init();
    }

    
    
    
}
