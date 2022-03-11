using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitManager : MonoBehaviour
{
    [SerializeField] GameObject UnitPrefab1;
    [SerializeField] GameObject UnitPrefab2;
    [SerializeField] GameObject UnitPrefab3;
    [SerializeField] GameObject UnitPrefab4;

    public bool[,] _isExistOnPlayerPlace = new bool[3, 2];
    public bool[,] _isExistOnEnemyPlace = new bool[3, 2];

    public Unit _currSelectedUnit = null;
    
    private List<GameObject> UnitList = new List<GameObject>();
    public void UnitMoveFunc(PlaceManager.place place,int x1, int y1, int x2, int y2)
    {
        var unit = UnitList.Find(a => a.GetComponent<UnitInterface>().checkPos(x1,y1) == true);
        if(unit == null) throw new System.Exception("해당 위치에 유닛이 존재하지 않습니다."); 
        bool[,] PlayerPlace = null;
        if(place == PlaceManager.place.player) {
            PlayerPlace = _isExistOnPlayerPlace;
        }
        else {
            PlayerPlace = _isExistOnEnemyPlace;
        }
        PlayerPlace[x1,y1] = false;
        PlayerPlace[x2,y2] = true;
        unit.GetComponent<UnitInterface>().setUnitPos(place,x2,y2);
        GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
    }//유닛 이동 명령

    
    public GameObject CreateUnit(PlaceManager.place place, PlaceObject _place, int unitNum) { // 인자는 배치 오브젝트의 순서 (ex : (0,0), (2,0) ...) 이고 Transform이 아닙니다.
        GameObject unit = null;
        if (unitNum == 0)
        {

            unit = UnitFactory.getUnit("Unit", _place, UnitPrefab1, place);
        }
        if (unitNum == 1)
        {
            unit = UnitFactory.getUnit("Unit", _place, UnitPrefab2, place);
        }
        if (unitNum == 2)
        {
            unit = UnitFactory.getUnit("Unit", _place, UnitPrefab3, place);
        }
        if (unitNum == 3)
        {
            unit = UnitFactory.getUnit("Unit", _place, UnitPrefab4, place);

            if (_isExistOnPlayerPlace[x, y])
            {
                Debug.Log("이미 설치된 공간입니다.");
                return;
            }
            _isExistOnPlayerPlace[x,y] = true;
        }
        else if (place == PlaceManager.place.enemy)
        {         
            if (_isExistOnEnemyPlace[x, y])
            {
                Debug.Log("이미 설치된 공간입니다.");
                return;
            }    
            _isExistOnEnemyPlace[x,y] = true;

        }
        UnitList.Add(unit);
        GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
        return unit;
    }

    public void CreateMoveFunc()
    {
    }

}
