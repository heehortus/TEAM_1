using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    private static ResourceManager _resourceManager = GameManager.GetInstance().resourceManager;
    public static GameObject getUnit(string name, PlaceObject _place) {
        GameObject unit;
        unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 1")); //기본 prefab 생성

        unit.transform.SetParent(GameManager.GetInstance().sceneManager.Unit_Parent.transform);

        if (_place.isPlayerPlace)
        {
            Debug.Log($"Player 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }
        else
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