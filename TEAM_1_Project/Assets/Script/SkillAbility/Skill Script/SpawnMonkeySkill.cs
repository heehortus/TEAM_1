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
    public int turn = 0;
    private void Start()
    {
        turn = GameManager.sceneManager.presentTurn;
    }
    public override void Skiil()
    {
        if(GameManager.sceneManager.presentTurn == 1)
        {
            turn = 0;
        }
        Debug.Log("스킬사용");
        Debug.Log(turn);
        if (GameManager.enemy.path == "기본숭이 2/기본 숭이 2")
            plusTurn = 3;
        else
            plusTurn = 4;
        if (GameManager.sceneManager.presentTurn == turn + plusTurn)
        {
            Debug.Log("숭이 소환!");
            var PlaceList = GameManager.placeManager.getEmptyPlaceObject(false);
            var iterator = PlaceList.GetEnumerator();
            iterator.MoveNext();
            if (PlaceList == null || PlaceList.Count == 0)
                Debug.Log("자리가 없습니다");
            else
            {
                if (GameManager.enemy.path == "기본숭이/기본 숭이")
                {
                    Debug.Log("공무원숭이 소환");
                    var item2 = iterator.Current.GetComponent<PlaceObject>();
                    int x = item2.x, y = item2.y;
                    Debug.Log(x);
                    Debug.Log(y);
                    var placeObject = GameManager.placeManager.getPlaceObject(false, x, y).GetComponent<PlaceObject>();
                    GameManager.sceneManager.getE()._currHP -= 2;

                    GameManager.unitManager.CreateUnit(placeObject, "OfficialMonkey");

                }
                else
                {
                    var item2 = iterator.Current.GetComponent<PlaceObject>();
                    int x = item2.x, y = item2.y;
                    var placeObject = GameManager.placeManager.getPlaceObject(false, x, y).GetComponent<PlaceObject>();
                    GameManager.unitManager.CreateUnit(placeObject, "OneMonkey");
                }
                turn = GameManager.sceneManager.presentTurn;
            }
        }
        
    }
}