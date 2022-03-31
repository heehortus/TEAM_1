using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skill/OfficialMonkey")]

public class OfficialMonkey : Skill
{
    public override void Skiil()
    {
        unit.isSeedStealDamage = true;
    }
}
