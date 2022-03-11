using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitManager : MonoBehaviour
{
    [SerializeField] GameObject UnitPrefab;
    private List<GameObject> UnitList = new List<GameObject>();
    public void UnitMoveFunc(int x1, int y1, int x2, int y2)
    {
        var unit = UnitList.Find(a => a.GetComponent<UnitInterface>().checkPos(x1,x2) == true);
        if(unit == null) throw new System.Exception("해당 위치에 유닛이 존재하지 않습니다."); 
        unit.GetComponent<UnitInterface>().Movefuc(x2,y2);
    }//유닛 이동 명령

    public void CreateUnit(PlaceManager.place place,int x,int y) { // 인자는 배치 오브젝트의 순서 (ex : (0,0), (2,0) ...) 이고 Transform이 아닙니다.

        if (place == PlaceManager.place.player)
        {
            if (GameManager.GetInstance().placeManager._isExistOnPlayerPlace[x, y])
            {
                Debug.Log("이미 설치된 공간입니다.");
                return;
            }
        }
        else if (place == PlaceManager.place.enemy)
        {         
            if (GameManager.GetInstance().placeManager._isExistOnEnemyPlace[x, y])
            {
                Debug.Log("이미 설치된 공간입니다.");
                return;
            }    
        }

        var unit = UnitFactory.getUnit("Unit",x,y,UnitPrefab,place);
        UnitList.Add(unit);
    }

    public void CreateMoveFunc()
    {

    }
}
