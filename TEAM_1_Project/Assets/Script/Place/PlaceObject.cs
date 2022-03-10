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
            if (GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.CREATEUNIT1)
            {
                GameManager.GetInstance().unitManager.CreateUnit(place, x, y);
                Debug.Log("Create 1");
                isEmpty = false;
            }
            else if (GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.CREATEUNIT2)
            {
                GameManager.GetInstance().unitManager.CreateUnit(place, x, y);
                Debug.Log("Create 2");
                isEmpty = false;
            }
            else if (GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.CREATEUNIT3)
            {
                GameManager.GetInstance().unitManager.CreateUnit(place, x, y);
                Debug.Log("Create 3");
                isEmpty = false;
            }
            else if (GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.CREATEUNIT4)
            {
                GameManager.GetInstance().unitManager.CreateUnit(place, x, y);
                Debug.Log("Create 4");
                isEmpty = false;
            }
        }
        

        if (GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.MOVE)
        {
            if (isEmpty)
            {

                GameManager.GetInstance().unitManager.UnitMoveFunc(place, GameManager.GetInstance().placeManager.saved_x_point, GameManager.GetInstance().placeManager.saved_y_point, this.x, this.y);
                Debug.Log("Move");
                isEmpty = false;
            }
            else
            {
                Debug.Log("이동 시킬 유닛이 없습니다");
            }
        }
        GameManager.GetInstance().placeManager.SavedPoint(place, x, y);
    }
}
