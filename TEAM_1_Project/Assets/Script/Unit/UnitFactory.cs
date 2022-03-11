using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    private static GameObject[] UnitPrefabs = Resources.LoadAll<GameObject>("PreFabs/Units");
    public static GameObject getUnit(string name, PlaceObject _place,PlaceManager.place place = PlaceManager.place.player) {
        GameObject unit;
        if(UnitPrefabs == null)
            unit = new GameObject();
        else 
            unit = Object.Instantiate(UnitPrefabs[0]); //기본 prefab 생성

        unit.transform.SetParent(GameManager.GetInstance().sceneManager.Unit_Parent.transform);

        if (place == PlaceManager.place.player)
        {
            Debug.Log($"Player 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }
        if (place == PlaceManager.place.enemy)
        {
            Debug.Log($"Enemy 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }

        switch (name) {
            case "Unit":
                unit.AddComponent<Unit>();
                break;
        }
        unit.GetComponent<UnitInterface>().setUnitPos(_place);
        return unit;
    }
}