using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaceObject : MonoBehaviour
{
    public Transform point;
    [SerializeField] public int x = 0;
    [SerializeField] public int y = 0;
    [SerializeField] public bool isEmpty = true;

	public bool isPlayerPlace = true;
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
        var click_state = GameManager.GetInstance().inputManager.Get_ClickerState();
        var _unitManager = GameManager.GetInstance().unitManager;

        if(click_state == InputManager.E_CLICKERSTATE.CREATEUNIT1) {
            _unitManager.CreateUnit(this, "SeedUnit");
            Debug.Log($"Create : {click_state}");
        }
        else if(click_state == InputManager.E_CLICKERSTATE.CREATEUNIT2) {
            _unitManager.CreateUnit(this, "BoomUnit");
            Debug.Log($"Create : {click_state}");
        }
        else if(click_state == InputManager.E_CLICKERSTATE.CREATEUNIT3) {
            _unitManager.CreateUnit(this, "StealerUnit");
        }

        else if(click_state == InputManager.E_CLICKERSTATE.MOVE)
        {
            Debug.Log(_unitManager._currSelectedUnit._currPlace);
            _unitManager.UnitMoveFunc(_unitManager._currSelectedUnit._currPlace,this);
            Debug.Log("Move");
        }
        GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
    }
}
