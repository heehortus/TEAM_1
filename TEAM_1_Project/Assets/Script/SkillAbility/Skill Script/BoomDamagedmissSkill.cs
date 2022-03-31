using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skill/BoomDamagemissSkill")]
public class BoomDamagedmissSkill : Skill
{
    public override void Skiil()
    {
        unit.isBoomDamageMiss = true;
    }
}
