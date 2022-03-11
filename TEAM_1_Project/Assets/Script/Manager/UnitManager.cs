using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitManager : MonoBehaviour
{
    
    private List<GameObject> UnitList = new List<GameObject>();
    public void UnitMoveFunc(Place prev,Place next)
    {
        var unit = UnitList.Find(a => a.GetComponent<UnitInterface>().checkPos(prev) == true);
        if(unit == null) throw new System.Exception("해당 위치에 유닛이 존재하지 않습니다."); 
        unit.GetComponent<UnitInterface>().setUnitPos(next);
        prev.isEmpty = true;
        next.isEmpty = false;
    }//유닛 이동 명령

    
    public GameObject CreateUnit(Place _place,string name) { // 인자는 배치 오브젝트의 순서 (ex : (0,0), (2,0) ...) 이고 Transform이 아닙니다.
        GameObject unit = null;
        if(!_place.isEmpty) return null;
        unit = UnitFactory.getUnit(name, _place);
        _place.isEmpty = false;
        UnitList.Add(unit);
        return unit;
    }

    public void CreateMoveFunc()
    {
    }

}
