using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    private static ResourceManager _resourceManager = GameManager.resourceManager;
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
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 4")); //나중에 다 추상화 할 예정
                unit.AddComponent<Unit>();
                break;

            case "BoomUnit1":
            case "BoomUnit2":
            case "BoomUnit3":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 1")); //나중에 다 추상화 할 예정
                unit.AddComponent<Boom>();
                break;
            case "StealerUnit1":
            case "StealerUnit2":
            case "StealerUnit3":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 2"));
                unit.AddComponent<Stealer>();
                break;
            case "SeedUnit1":
            case "SeedUnit2":
            case "SeedUnit3":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 3"));
                unit.AddComponent<Seed>();
                break;
            default :
                return unit;
        }
        unit.transform.SetParent(GameManager.sceneManager.Unit_Parent.transform);
        var script = unit.GetComponent<UnitInterface>();
        script.setUnitPos(_place);
        script.setSprite();
        unit.GetComponent<Unit>()._unitCamp = Define.UnitCamp.playerUnit;
        return unit;
    }
}