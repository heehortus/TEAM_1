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

    public void Init()
    {
        _inputManager = GameManager.GetInstance().inputManager;
        _unitManager = GameManager.GetInstance().unitManager;
        UI_Parent = new GameObject { name = "UI_Parent" }; // UI들 묶어서 하이라키창에 저장
        Unit_Parent = new GameObject { name = "Unit_Parent" }; // Unit들 묶어서 하이라키창에 저장

        Instantiate(GameManager.GetInstance().resourceManager.LoadUI("UI_Turn_End_Button")).transform.SetParent(UI_Parent.transform); // 턴 종료 UI 버튼 생성

        InitEnemyPlace();
    }

    //UI_Turn_End_Button
    public void OnUpdate()
    {
        if (GameManager.GetInstance().gameState == GameManager.E_GAMESTATE.VICTORY)
        {
            Instantiate(GameManager.GetInstance().resourceManager.LoadUI("UI_Victory")).transform.SetParent(UI_Parent.transform); // 턴 종료 UI 버튼 생성
        }
        else if (GameManager.GetInstance().gameState == GameManager.E_GAMESTATE.DEFEAT)
        {
            Instantiate(GameManager.GetInstance().resourceManager.LoadUI("UI_Defeat")).transform.SetParent(UI_Parent.transform); // 턴 종료 UI 버튼 생성
        }
    }


    void InitEnemyPlace() { // 전투 테스트 용도로 작성한 함수입니다. 적 진영에 유닛들 배치하는 함수입니다.
        var _placeManager = GameManager.GetInstance().placeManager;

        var placeobj = _placeManager.getPlaceObject(false,0,1); // 적 좌표 0,1 가져오기
        _unitManager.CreateUnit(placeobj.GetComponent<PlaceObject>(),"SeedUnit");
        
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
