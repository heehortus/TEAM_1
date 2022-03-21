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
            case "SeedUnit1":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Seed1"));
                break;
            case "SeedUnit2":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Seed2"));
                break;
            case "SeedUnit3":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Seed3"));
                break;
            case "StealerUnit1":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Stealer1"));
                break;
            case "StealerUnit2":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Stealer2"));
                break;
            case "StealerUnit3":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Stealer3"));
                break;
            case "BoomUnit1":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Boom1"));
                break;
            case "BoomUnit2":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Boom2"));
                break;
            case "BoomUnit3":
                unit = Object.Instantiate(_resourceManager.LoadUnit("Boom3"));
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