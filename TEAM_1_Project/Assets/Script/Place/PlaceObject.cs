using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaceObject : MonoBehaviour
{
    public Place data {get;set;}

    private void OnMouseDown()
    {
        var click_state = GameManager.GetInstance().inputManager.Get_ClickerState();
        var _cur_unit = GameManager.GetInstance().inputManager._currSelectedUnit;
        var _unitManager = GameManager.GetInstance().unitManager;

        if (click_state >= InputManager.E_CLICKERSTATE.CREATEUNIT1 &&
            click_state <= InputManager.E_CLICKERSTATE.CREATEUNIT4)
        {
            
            _unitManager.CreateUnit(data, "Unit");
            Debug.Log($"Create : {click_state}");
        }

        else if(click_state == InputManager.E_CLICKERSTATE.MOVE)
        {
            Debug.Log(_cur_unit._currPlace);
            _unitManager.UnitMoveFunc(_cur_unit._currPlace,data);
            Debug.Log("Move");
        }
        GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
    }
}
