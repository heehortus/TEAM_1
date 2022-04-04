using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/SPYMonkey")]
public class SPYMonkey : Skill
{
    public override void Skiil()
    {
        Debug.Log("DD");
        unit.isBackCheck = true;
    }
}
