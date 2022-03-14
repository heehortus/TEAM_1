using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitManager : MonoBehaviour
{

    public void Init()
    {

    }
    public void OnUpdate()
    {

    }
    private List<GameObject> UnitList = new List<GameObject>();
    public bool isPlace;
    public static UnitManager Inst { get; private set; }
    void Awake() => Inst = this;
    public void UnitMoveFunc(PlaceObject prev,PlaceObject next)
    {
        var unit = GetUnit(prev);
        if(unit == null) throw new System.Exception("해당 위치에 유닛이 존재하지 않습니다.");
        if (next.isEmpty)
        {
            unit.GetComponent<UnitInterface>().setUnitPos(next);
            prev.isEmpty = true;
            next.isEmpty = false;
        }
        else
        {
            var next_unit = GetUnit(next);
            unit.GetComponent<UnitInterface>().setUnitPos(next);
            next_unit.GetComponent<UnitInterface>().setUnitPos(prev);
        }
    }//유닛 이동 명령

    
    public GameObject CreateUnit(PlaceObject _place,string name) { // 인자는 배치 오브젝트의 순서 (ex : (0,0), (2,0) ...) 이고 Transform이 아닙니다.
        GameObject unit = null;
        if(!_place.isEmpty) return null;
        unit = UnitFactory.getUnit(name, _place);
        isPlace = _place.isPlayerPlace;
        _place.isEmpty = false;
        UnitList.Add(unit);
        return unit;
    }

    public GameObject GetUnit(PlaceObject _place) {
        var unit = UnitList.Find(a => a.GetComponent<UnitInterface>().checkPos(_place) == true);
        return unit;
    }

    public void CreateMoveFunc()
    {

    }
}
