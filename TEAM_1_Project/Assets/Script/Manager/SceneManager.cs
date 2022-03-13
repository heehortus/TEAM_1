using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int currTurn;
    InputManager _inputManager;
    UnitManager _unitManager;

    public GameObject UI_Parent;
    public GameObject Unit_Parent;
    void Start()
    {
        _inputManager = GameManager.GetInstance().inputManager;
        _unitManager = GameManager.GetInstance().unitManager;
        UI_Parent = new GameObject { name = "UI_Parent" }; // UI들 묶어서 하이라키창에 저장
        Unit_Parent = new GameObject { name = "Unit_Parent" }; // Unit들 묶어서 하이라키창에 저장

        Instantiate(GameManager.GetInstance().resourceManager.LoadUI("UI_Turn_End_Button")).transform.SetParent(UI_Parent.transform); // 턴 종료 UI 버튼 생성
    }
    
    //UI_Turn_End_Button
    void Update()
    {
        
    }

    public void onClickPlaceObject(GameObject Ojbect) {
        PlaceObject placeObject = Ojbect.GetComponent<PlaceObject>();
        if(!placeObject.isPlayerPlace) return;
        var click_state = _inputManager.e_CLICKERSTATE;

        if(click_state == InputManager.E_CLICKERSTATE.CREATEUNIT) {
            _unitManager.CreateUnit(placeObject, _inputManager._currSelectedButton._unitName);
        }
        else if(click_state == InputManager.E_CLICKERSTATE.MOVE)
        {
            _unitManager.UnitMoveFunc(_inputManager._currSelectedUnit._currPlace,placeObject);
            Debug.Log("Move");
        }
        _inputManager.e_CLICKERSTATE =  InputManager.E_CLICKERSTATE.STANDBY;
    }
}
