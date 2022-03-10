using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    public static GameObject getUnit(string name,int x,int y,GameObject Prefabs = null,PlaceManager.place place = PlaceManager.place.player) {
        GameObject unit;
        if(Prefabs == null)
            unit = new GameObject();
        else 
            unit = Object.Instantiate(Prefabs); //기본 prefab 생성

        switch(name) {
            case "Unit":
                unit.AddComponent<Unit>(); //스크립트별로 붙여주기
                unit.GetComponent<Unit>().setUnitPos(place,x,y);
                return unit;
        }
        return null;
    }
}