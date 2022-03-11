using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitManager : MonoBehaviour
{
    [SerializeField] GameObject UnitPrefab;
    public bool[,] _isExistOnPlayerPlace = new bool[3, 2];
    public bool[,] _isExistOnEnemyPlace = new bool[3, 2];

    public Unit _currSelectedUnit = null;
    
    private List<GameObject> UnitList = new List<GameObject>();
    public void UnitMoveFunc(PlaceManager.place place,int x1, int y1, int x2, int y2)
    {
        var unit = UnitList.Find(a => a.GetComponent<UnitInterface>().checkPos(x1,y1) == true);
        if(unit == null) throw new System.Exception("해당 위치에 유닛이 존재하지 않습니다."); 
        unit.GetComponent<UnitInterface>().setUnitPos(place,x2,y2);
        GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
    }//유닛 이동 명령

    
    public GameObject CreateUnit(PlaceManager.place place, PlaceObject _place) { // 인자는 배치 오브젝트의 순서 (ex : (0,0), (2,0) ...) 이고 Transform이 아닙니다.

        var unit = UnitFactory.getUnit("Unit", _place, UnitPrefab, place);
        UnitList.Add(unit);
        GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
        return unit;
    }

    public void CreateMoveFunc()
    {
    }

}
