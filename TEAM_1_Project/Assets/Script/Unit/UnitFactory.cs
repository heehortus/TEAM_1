using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    private static ResourceManager _resourceManager = GameManager.GetInstance().resourceManager;
    public static GameObject getUnit(string name, PlaceObject _place) {

        GameObject unit = null;

        if (_place.isPlayerPlace)
        {
            Debug.Log($"Player 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }
        else
        {
            Debug.Log($"Enemy 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }

        switch (name) {
            case "Unit" :
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 1")); //나중에 다 추상화 할 예정
                unit.AddComponent<Unit>();
                break;

            case "BoomUnit":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 1")); //나중에 다 추상화 할 예정
                unit.AddComponent<Boom>();
                break;
            case "StealerUnit":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 2"));
                unit.AddComponent<Stealer>();
                break;
            case "SeedUnit":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 3"));
                unit.AddComponent<Seed>();
                break;
            default :
                return unit;
        }
        unit.transform.SetParent(GameManager.GetInstance().sceneManager.Unit_Parent.transform);
        unit.GetComponent<UnitInterface>().setUnitPos(_place);
        return unit;
    }
}