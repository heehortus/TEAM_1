using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    public static GameObject getUnit(string name,int x,int y,GameObject Prefabs = null) {
        GameObject unit;
        if(Prefabs == null)
            unit = new GameObject();
        else 
            unit = Object.Instantiate(Prefabs); //기본 prefab 생성

        switch(name) {
            case "Unit":
                unit.AddComponent<Unit>(); //스크립트별로 붙여주기
                return unit;
        }
        return null;
    }
}