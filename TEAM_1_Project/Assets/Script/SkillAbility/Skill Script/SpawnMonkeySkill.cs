using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skill/SpawnMonkeySkill")]
public class SpawnMonkeySkill : Skill
{
    int plusTurn = 0;
    public int turn;

    private void Start()
    {
        turn = GameManager.sceneManager.presentTurn;
    }
    public override void Skiil()
    {
        Debug.Log(turn);
        if (unit._name == "Stealer1")
            plusTurn = 3;
        else
            plusTurn = 4;
        if (GameManager.sceneManager.presentTurn == turn + plusTurn)
        {
            int x = Random.Range(0, 2);
            int y = Random.Range(0, 2);
            if (unit._name == "LastBoos")
            {
                GameManager.sceneManager.getPlayer(unit._currPlace)._currHP -= 2;
                GameObject target_Place = GameManager.placeManager.getPlaceObject(unit._currPlace.isPlayerPlace, x, y);
                GameManager.unitManager.CreateUnit(target_Place.GetComponent<PlaceObject>(), "OfficialMokey");
            }
            else
            {
                GameObject target_Place = GameManager.placeManager.getPlaceObject(unit._currPlace.isPlayerPlace, x, y);
                GameManager.unitManager.CreateUnit(target_Place.GetComponent<PlaceObject>(), "StealerUnit1");
            }
        }
    }
}
