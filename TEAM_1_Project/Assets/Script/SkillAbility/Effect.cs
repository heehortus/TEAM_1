using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public Unit unit;
    virtual public void Use(Unit caster, Unit target)
    {
        if(unit.GetComponents<Stealer>() != null)
        {
            StealerUse(caster, target);
        }
        else if(unit.GetComponents<Seed>() != null)
        {
            SeedUse(caster, target);
        }
        else if(unit.GetComponents<Boom>() != null)
        {
            BoomUse(caster, target);
        }
        else
        {
            Debug.Log("오류");
        }
    }

    virtual public void SeedUse(Unit caster, Unit target)
    {

    }
    virtual public void StealerUse(Unit caster, Unit target)
    {
        int a = 0;
        if(a == 1)
        {
            
        }
    }
    virtual public void BoomUse(Unit caster, Unit target)
    {

    }
}

public class Attack : Effect
{
    public override void Use(Unit caster, Unit target)
    {
        base.Use(caster, target);
    }
    public override void StealerUse(Unit caster, Unit target)
    {
        base.StealerUse(caster, target);
    }
    
}
