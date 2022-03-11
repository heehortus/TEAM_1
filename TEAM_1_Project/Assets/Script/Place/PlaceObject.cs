using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaceObject : MonoBehaviour
{
    public Transform point;
    public PlaceManager.place place;
    [SerializeField] public int x = 0;
    [SerializeField] public int y = 0;
    [SerializeField] public bool isEmpty = true;
    // Start is called before the first frame update
    void Start()
    {
        SetUpPoint();
    }

    public void SetUpPoint()
    {
        
        

    }

    private void OnMouseDown()
    {
        if(isEmpty)
        {
            GameObject unit = null;
            if (GameManager.GetInstance().inputManager.Get_ClickerState() >= InputManager.E_CLICKERSTATE.CREATEUNIT1 &&
                GameManager.GetInstance().inputManager.Get_ClickerState() <= InputManager.E_CLICKERSTATE.CREATEUNIT4)
            {
                unit = GameManager.GetInstance().unitManager.CreateUnit(place, this);
                unit.GetComponent<Unit>()._currPlace = this;
                isEmpty = false;
                Debug.Log($"Create : {(int)GameManager.GetInstance().inputManager.Get_ClickerState()}");
            }
            else if(GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.MOVE)
            {
                Unit _unit = GameManager.GetInstance().unitManager._currSelectedUnit;
                _unit._currPlace.isEmpty = true;
                _unit._currPlace = this;
                _unit.transform.position = transform.position;
                isEmpty = false;
                GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
                Debug.Log("Move");
            }
        }
        else
        {
            // 이미 유닛이 있는 공간에 유닛을 배치하려고 하면
            if ((int)GameManager.GetInstance().inputManager.Get_ClickerState() >= (int)InputManager.E_CLICKERSTATE.CREATEUNIT1 &&
                (int)GameManager.GetInstance().inputManager.Get_ClickerState() <= (int)InputManager.E_CLICKERSTATE.CREATEUNIT4)
            {
                Debug.Log("이미 유닛이 존재하는 공간입니다.");
                GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
            }
            else if (GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.MOVE)
            {
                Debug.Log("이미 유닛이 존재하는 공간입니다.");
                GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
            }
        }
        

        /*if (GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.MOVE)
        {
            if (isEmpty)
            {
                Unit _unit = GameManager.GetInstance().unitManager._currSelectedUnit;
                _unit._currPlace.isEmpty = true;
                _unit._currPlace = this;
                _unit.transform.position = transform.position;
                isEmpty = false;
                GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);

                //GameManager.GetInstance().unitManager.UnitMoveFunc(place, GameManager.GetInstance().placeManager.saved_x_point, GameManager.GetInstance().placeManager.saved_y_point, this.x, this.y);
                Debug.Log("Move");
            }
            else
            {
                Debug.Log("이미 유닛이 있는 공간입니다."); // 나중에 위치 바뀌도록 수정
            }
        }
        */
        //GameManager.GetInstance().placeManager.SavedPoint(place, x, y);
    }
}
