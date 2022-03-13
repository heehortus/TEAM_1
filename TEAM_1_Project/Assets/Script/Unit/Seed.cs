using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Unit
{
    public static Seed Inst { get; private set; }
    void Awake() => Inst = this;
    public bool isbatch;
    public override void Ability()
    {

          this.coast += 1;
        
    }
    public int ReturnCoast()
    {
        return this.coast;
    }

}
