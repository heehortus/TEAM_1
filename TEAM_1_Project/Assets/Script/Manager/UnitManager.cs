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
    public List<Unit> UnitList = new List<Unit>();
    private List<Unit> UnitRemoveList = new List<Unit>();
    public bool isPlace;
    public bool isSteal = false;
    public int count = 0;
    int playerboomCount = 3;
    int enemybommCount = 3;
    int unitRemoveCount;
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

    public bool checkResouceToCreateUnit(Player player,string name)
    {
        try
        {
            if (player._currResource < GameManager.inputManager._currSelectedButton._cost)
            {
                Debug.Log("자원이 부족합니다.");
                return false;
            }
        }
        catch
        {
            return false;
        }
        return true;
    }

    
    public GameObject CreateUnit(PlaceObject _place,string name) { // 인자는 배치 오브젝트의 순서 (ex : (0,0), (2,0) ...) 이고 Transform이 아닙니다.
        var player = GameManager.sceneManager.getPlayer(_place.isPlayerPlace);
        if (!checkResouceToCreateUnit(player, name)&&_place.isPlayerPlace) return null;
        GameObject unit = null;
        if(!_place.isEmpty) return null;
        unit = UnitFactory.getUnit(name, _place);
        if(unit == null)
        {
            Debug.Log("더 이상 설치할 수 없습니다");
            return null;
        }
        isPlace = _place.isPlayerPlace;
        _place.isEmpty = false;
        UnitList.Add(unit.GetComponent<Unit>());
        GameManager.sceneManager.getPlayer(_place.isPlayerPlace)._currResource -= GameManager.inputManager._currSelectedButton?._cost ?? 0;
        GameManager.uiManager.ChangeInfoBar();
        if (unit.GetComponent<Boom>() != null && name != "BoomUnit1")
        {
            if (_place.isPlayerPlace)
                playerboomCount--;
            else if (!_place.isPlayerPlace)
                enemybommCount--;
            if (unit.GetComponent<Unit>()._currPlace.isPlayerPlace)
                ResourceManager.LoadUnit("Boom2").GetComponent<Boom>().playermaxCount = playerboomCount;
            else
                ResourceManager.LoadUnit("Boom2").GetComponent<Boom>().enemymaxCount = enemybommCount;
        }
        return unit;
    }

    public GameObject GetUnit(PlaceObject _place) {
        var unit = UnitList.Find(a => a.GetComponent<UnitInterface>().checkPos(_place) == true);
        if (unit != null)
            return unit.gameObject;
        else
            return null;
    }

    public float doBattle(int idx)
    {
        if (!UnitList[idx].valid) return 0;
        return UnitList[idx].Ability();
    }
    public void RemoveUnits()
    {
        for (int i = 0; i < unitRemoveCount; i++)
        {
            UnitList.Remove(UnitRemoveList[i]);
            UnitRemoveList[i].OnDestroy();
        }
        UnitRemoveList.Clear();
        unitRemoveCount = 0;
    }

    public void DeleteUnit(Unit _unit) {
        _unit._currPlace.isEmpty = true;
        //Debug.Log("DDS");
        UnitRemoveList.Add(_unit);
        unitRemoveCount += 1;
    }

}
