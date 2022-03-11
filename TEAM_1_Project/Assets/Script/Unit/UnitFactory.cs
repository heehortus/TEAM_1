using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    private static ResourceManager _resourceManager = GameManager.GetInstance().resourceManager;
    public static GameObject getUnit(string name, PlaceObject _place) {
        GameObject unit = new GameObject();

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
                unit = Object.Instantiate(_resourceManager.LoadUnit("Unit_Tmp 1")); //기본 prefab 생성
                unit.AddComponent<Unit>(); 
                //나중에 추상화 해야함
                break;
            default :
                return unit;
        }
        unit.transform.SetParent(GameManager.GetInstance().sceneManager.Unit_Parent.transform);
        unit.GetComponent<UnitInterface>().setUnitPos(_place);
        return unit;
    }
}