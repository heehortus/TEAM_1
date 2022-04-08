using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/SpawnMonkeySkill")]
public class SpawnMonkeySkill : Skill
{
    int plusTurn = 0;
    public int turn;
    bool isBoss;
    private void Start()
    {
        turn = GameManager.sceneManager.presentTurn - 1;
    }
    public override void Skiil()
    {
        int PlaceCount = 1;
        unit.isBoss = true; 
        Debug.Log(turn);
        if (unit._name == "CheeringMonkey")
            plusTurn = 3;
        else
            plusTurn = 4;
        if (GameManager.sceneManager.presentTurn == turn + plusTurn)
        {
            Debug.Log("숭이 소환!");
            var PlaceList = GameManager.placeManager.getEmptyPlaceObject(false)
                .OrderBy(a => Guid.NewGuid()).Take(PlaceCount);
            var iterator = PlaceList.GetEnumerator();
            iterator.MoveNext();
            if (unit._name == "LastBoss")
            {
                var item2 = iterator.Current.GetComponent<PlaceObject>();
                int x = item2.x, y = item2.y;
                var placeObject = GameManager.placeManager.getPlaceObject(false, x, y).GetComponent<PlaceObject>();
                GameManager.sceneManager.getPlayer(unit._currPlace)._currHP -= 2;
                GameManager.unitManager.CreateUnit(placeObject, "OfficialMokey");
                
            }
            else
            {
                var item2 = iterator.Current.GetComponent<PlaceObject>();
                int x = item2.x, y = item2.y;
                var placeObject = GameManager.placeManager.getPlaceObject(false, x, y).GetComponent<PlaceObject>();
                GameManager.sceneManager.getPlayer(unit._currPlace)._currHP -= 2;
                GameManager.unitManager.CreateUnit(placeObject, "OneMonkey");
            }
        }
        
    }
}