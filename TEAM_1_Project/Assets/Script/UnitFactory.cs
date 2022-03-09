using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory
{
    public static GameObject getUnit(string name,int x,int y) {
        switch(name) {
            case "Unit":
                var unit = new GameObject();
                return unit;
        }
        return null;
    }
}