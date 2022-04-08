using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skill/FruitMonkey")]

public class FruitMonkey : Skill
{
    public override void Skiil()
    {
        Debug.Log(unit);
        if (unit.stealCount == 0)
        {
            Debug.Log("Dd");
            unit.valid = false;
            GameManager.unitManager.DeleteUnit(unit);
            unit.character.enabled = false;
            GameManager.sceneManager.getEnemy(unit._currPlace)._currResource += 1;
            
        }
    }
}
