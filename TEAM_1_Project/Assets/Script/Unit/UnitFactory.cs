using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    public static GameObject getUnit(string name, PlaceObject _place) {

        GameObject unit = null;

        switch (name) {
            case "SeedUnit1":
                unit = Object.Instantiate(ResourceManager.LoadUnit("Seed1"));
                break;
            case "SeedUnit2":
                unit = Object.Instantiate(ResourceManager.LoadUnit("Seed2"));
                break;
            case "SeedUnit3":
                unit = Object.Instantiate(ResourceManager.LoadUnit("Seed3"));
                break;
            case "StealerUnit1":
                unit = Object.Instantiate(ResourceManager.LoadUnit("Stealer1"));
                break;
            case "StealerUnit2":
                unit = Object.Instantiate(ResourceManager.LoadUnit("Stealer2"));
                break;
            case "StealerUnit3":
                unit = Object.Instantiate(ResourceManager.LoadUnit("Stealer3"));
                break;
            case "OneMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("OneMonkey"));
                break;
            case "TwoMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("TwoMonkey"));
                break;
            case "CheeringMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("CheeringMonkey"));
                break;
            case "FuckMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("FuckMonkey"));
                break;
            case "AgentMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("AgentMonkey"));
                break;
            case "MartialMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("MartialMonkey"));
                break;
            case "FruitMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("FruitMonkey"));
                break;
            case "OfficialMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("OfficialMonkey"));
                break;
            case "EclipseMonkey":
                unit = Object.Instantiate(ResourceManager.LoadUnit("EclipseMonkey"));
                break;
            case "LastBoss":
                unit = Object.Instantiate(ResourceManager.LoadUnit("LastBoss"));
                break;


            case "BoomUnit1":
                unit = Object.Instantiate(ResourceManager.LoadUnit("Boom1"));
                break;
            case "BoomUnit2":
                if(ResourceManager.LoadUnit("Boom2").GetComponent<Boom>() != null)
                {
                    if (ResourceManager.LoadUnit("Boom2").GetComponent<Boom>().playermaxCount > 0 && _place.isPlayerPlace)
                         unit = Object.Instantiate(ResourceManager.LoadUnit("Boom2"));
                    
                    else if (ResourceManager.LoadUnit("Boom2").GetComponent<Boom>().playermaxCount <= 0 && _place.isPlayerPlace)
                        unit = null;
                    
                    if (ResourceManager.LoadUnit("Boom2").GetComponent<Boom>().enemymaxCount > 0 && !_place.isPlayerPlace)
                        unit = Object.Instantiate(ResourceManager.LoadUnit("Boom2"));
                    
                    else if (ResourceManager.LoadUnit("Boom2").GetComponent<Boom>().enemymaxCount <= 0 && !_place.isPlayerPlace)
                        unit = null;
                }
                break;
            case "BoomUnit3":
                if (ResourceManager.LoadUnit("Boom3").GetComponent<Boom>() != null)
                {
                    if (ResourceManager.LoadUnit("Boom3").GetComponent<Boom>().playermaxCount > 0 && _place.isPlayerPlace)
                        unit = Object.Instantiate(ResourceManager.LoadUnit("Boom3"));

                    else if (ResourceManager.LoadUnit("Boom3").GetComponent<Boom>().playermaxCount <= 0 && _place.isPlayerPlace)
                        unit = null;

                    if (ResourceManager.LoadUnit("Boom3").GetComponent<Boom>().enemymaxCount > 0 && !_place.isPlayerPlace)
                        unit = Object.Instantiate(ResourceManager.LoadUnit("Boom3"));

                    else if (ResourceManager.LoadUnit("Boom3").GetComponent<Boom>().enemymaxCount <= 0 && !_place.isPlayerPlace)
                        unit = null;
                }
                break;
                  
            default :
                return unit;
        }
        if(unit == null)
        {
            Debug.Log("설치에 실패하였습니다.");
            return null;
        }
        if (_place.isPlayerPlace)
        {
            Debug.Log($"Player 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }
        else
        {
            Debug.Log($"Enemy 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }
        unit.transform.SetParent(GameManager.sceneManager.Unit_Parent.transform);
        var script = unit.GetComponent<UnitInterface>();
        script.setUnitPos(_place);
        script.setSprite();
        if (_place.isPlayerPlace)
        {
            unit.GetComponent<Unit>()._unitCamp = Define.UnitCamp.playerUnit;
        }
        else
        {
            unit.GetComponent<Unit>()._unitCamp = Define.UnitCamp.enemyUnit;
        }
        return unit;
    }
}