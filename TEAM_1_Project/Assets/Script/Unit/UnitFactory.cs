using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class UnitFactory 
{
    public static GameObject getUnit(string name, PlaceObject _place, GameObject Prefabs = null, PlaceManager.place place = PlaceManager.place.player) {
        GameObject unit;
        if(Prefabs == null)
            unit = new GameObject();
        else 
            unit = Object.Instantiate(Prefabs); //기본 prefab 생성

        unit.transform.SetParent(GameManager.GetInstance().sceneManager.Unit_Parent.transform);

        if (place == PlaceManager.place.player)
        {
            //GameManager.GetInstance().unitManager._isExistOnPlayerPlace[x, y] = true;
            Debug.Log($"Player 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }
        if (place == PlaceManager.place.enemy)
        {
            //GameManager.GetInstance().unitManager._isExistOnEnemyPlace[x, y] = true;
            Debug.Log($"Enemy 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");


            Debug.Log($"Player 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }
        if (place == PlaceManager.place.enemy)
        {
            Debug.Log($"Enemy 진영 {_place.x} , {_place.y} 에 유닛을 설치했습니다.");
        }

        switch (name) {
            case "Unit":
                // unit.AddComponent<Unit>(); //스크립트별로 붙여주기
                unit.GetComponent<Unit>().setUnitPos(place, _place);
                return unit;
        }
        return null;
    }
}