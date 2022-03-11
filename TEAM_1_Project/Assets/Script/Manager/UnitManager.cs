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
    public Unit _currSelectedUnit = null;
    
    private List<GameObject> UnitList = new List<GameObject>();
    public void UnitMoveFunc(PlaceManager.place place,PlaceObject prev,PlaceObject next)
    {
        var unit = UnitList.Find(a => a.GetComponent<UnitInterface>().checkPos(prev) == true);
        if(unit == null) throw new System.Exception("해당 위치에 유닛이 존재하지 않습니다."); 
        unit.GetComponent<UnitInterface>().setUnitPos(place,next);
        prev.isEmpty = true;
        next.isEmpty = true;
    }//유닛 이동 명령

    
    public GameObject CreateUnit(PlaceManager.place place, PlaceObject _place,string name) { // 인자는 배치 오브젝트의 순서 (ex : (0,0), (2,0) ...) 이고 Transform이 아닙니다.
        GameObject unit = null;
        if(!_place.isEmpty) return null;
        unit = UnitFactory.getUnit(name, _place, UnitPrefab1, place);
        _place.isEmpty = true;
        UnitList.Add(unit);
        return unit;
    }

    public void CreateMoveFunc()
    {
    }

}
