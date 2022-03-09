using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitManager : MonoBehaviour
{
    private List<GameObject> UnitList = new List<GameObject>();
    public void UnitMoveFunc(int x1,int y1,int x2,int y2)
    {
        var unit = UnitList.Find(a => a.GetComponent<Unit>().checkPos(x1,x2) == true);
        unit.GetComponent<Unit>().Movefuc(x2,y2);
    }//유닛 이동 명령

    public void CreateUnit(int x,int y) {
        //유닛 생성부 (나중에 유닛 팩토리로 새로 만들 예정)
        var unit = new GameObject();
        UnitList.Add(unit);
    }
    public void CreateMoveFunc()
    {
    }

}
