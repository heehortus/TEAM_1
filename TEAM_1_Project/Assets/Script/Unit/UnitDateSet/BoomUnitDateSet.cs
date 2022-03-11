using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitDate
{
    public string name;
    public int coast;
    public int attackpower;
    public SpriteRenderer sprites;
}
[CreateAssetMenu(fileName = "Boom", menuName = "Units/Boom")]
public class BoomUnitDateSet : ScriptableObject
{
    public UnitDate[] unitDate;
}
