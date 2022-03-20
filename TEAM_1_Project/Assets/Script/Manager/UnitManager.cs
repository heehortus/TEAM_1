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
        // 정렬 확인하기 위한 임시 코드
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UnitList.Sort();
            foreach(Unit _unit in UnitList)
            {
                Debug.Log($"{_unit.gameObject.name} : {_unit._speed}");
            }
        }
    }
    private List<Unit> UnitList = new List<Unit>();
    public bool isPlace;
    public bool isSteal;
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
            if (prev == next)
            {
                return;
            }
            var next_unit = GetUnit(next);
            unit.GetComponent<UnitInterface>().setUnitPos(next);
            next_unit.GetComponent<UnitInterface>().setUnitPos(prev);
        }
        GameManager.sceneManager._currMoveCount++;
    }//유닛 이동 명령

    
    public GameObject CreateUnit(PlaceObject _place,string name) { // 인자는 배치 오브젝트의 순서 (ex : (0,0), (2,0) ...) 이고 Transform이 아닙니다.
        GameObject unit = null;
        if(!_place.isEmpty) return null;
        unit = UnitFactory.getUnit(name, _place);
        isPlace = _place.isPlayerPlace;
        _place.isEmpty = false;
        UnitList.Add(unit.GetComponent<Unit>());
        return unit;
    }

    public GameObject GetUnit(PlaceObject _place) {
        var unit = UnitList.Find(a => a.GetComponent<UnitInterface>().checkPos(_place) == true);
        if (unit != null)
            return unit.gameObject;
        else
            return null;
    }

    public void doBattle() {
        UnitList.Sort();

        for(int i = 0; i < UnitList.Count; i++)
        {
            Debug.Log(isSteal);
            if (isSteal)
            {
                UnitList[i - 1].Ability();
                Debug.Log("실행됨");
                isSteal = false;
                UnitList.RemoveAt(UnitList.Count-1);
                Debug.Log("dddadw");
            }
            else
                UnitList[i].Ability();
        }
        Debug.Log("FOR문 나옴");
       
    }

    public void DeleteUnit(Unit _unit) {
        _unit._currPlace.isEmpty = true;
        UnitList.Remove(_unit);
        UnitList.Add(_unit);
        _unit.OnDestroy();
    }

}
