using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Skill : ScriptableObject
{
    public Unit unit;
    int plusTurn = 0;
    public List<Effect> effects = new List<Effect>();

    public abstract void Skiil();

    public void Use(Unit caster, Unit target)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].Use(caster, target);
        }
    }
}
