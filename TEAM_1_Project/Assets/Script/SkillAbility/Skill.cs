using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public List<Effect> effects = new List<Effect>();

    public void Use(Unit caster, Unit target)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            effects[i].Use(caster, target);
        }
    }
}
