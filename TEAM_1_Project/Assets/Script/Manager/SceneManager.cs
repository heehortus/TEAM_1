using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int currTurn;
    public int basicResource = 10;
    InputManager _inputManager;
    UnitManager _unitManager;

    public GameObject UI_Parent;
    public GameObject Unit_Parent;
    [SerializeField] public Player Player; 
    [SerializeField] public Player Enemy;

    public int presentTurn { get;set; }

    public int _maxMoveCount = 1;
    public int _currMoveCount = 0;

    public bool finished;
    public void Init()
    {
        _inputManager = GameManager.inputManager;
        _unitManager = GameManager.unitManager;
        UI_Parent = new GameObject { name = "UI_Parent" }; // UI들 묶어서 하이라키창에 저장
        Unit_Parent = new GameObject { name = "Unit_Parent" }; // Unit들 묶어서 하이라키창에 저장

        presentTurn = 1;

        CreateUI();

        //InitEnemyPlace();
    }

    //UI_Turn_End_Button
    public void OnUpdate()
    {
        //if (GameManager.GetInstance().gameState == GameManager.E_GAMESTATE.VICTORY)
        //{
        //    if (finished) return;
        //    Instantiate(GameManager.resourceManager.LoadUI("UI_Victory")).transform.SetParent(UI_Parent.transform); // 턴 종료 UI 버튼 생성
        //    GameManager.GetInstance().SetGameState(3);
        //}
        //else if (GameManager.GetInstance().gameState == GameManager.E_GAMESTATE.DEFEAT)
        //{
        //    if (finished) return;
        //    Instantiate(GameManager.resourceManager.LoadUI("UI_Defeat")).transform.SetParent(UI_Parent.transform); // 턴 종료 UI 버튼 생성
        //    GameManager.GetInstance().SetGameState(3);
        //}
    }

    void CreateUI()
    {
        GameObject _turnEndButton = Instantiate(ResourceManager.LoadUI("UI_Turn_End_Button")); // 턴 종료 UI 버튼 생성
        _turnEndButton.transform.SetParent(UI_Parent.transform);
        _turnEndButton.name = "UI_Turn_End_Button"; 

        GameObject _setting = Instantiate(ResourceManager.LoadUI("UI_Setting"));
        _setting.transform.SetParent(UI_Parent.transform);
        _setting.name = "UI_Setting";

        GameObject _currStage = Instantiate(ResourceManager.LoadUI("UI_CurrStage"));
        _currStage.transform.SetParent(UI_Parent.transform);
        _currStage.name = "UI_CurrStage";
    }

    public void endBattle()
    {
        Player.endBattle();
        Enemy.endBattle();
        _currMoveCount = 0;
    }
    public void onClickPlaceObject(GameObject Ojbect) {
        PlaceObject placeObject = Ojbect.GetComponent<PlaceObject>();
        if (placeObject.isPlayerPlace == false) return;
        var click_state = _inputManager.e_CLICKERSTATE;

        if(click_state == InputManager.E_CLICKERSTATE.CREATEUNIT) {
            _unitManager.CreateUnit(placeObject, _inputManager._currSelectedButton._unitName);
        }
        else if(click_state == InputManager.E_CLICKERSTATE.MOVE)
        {
            if (_currMoveCount >= _maxMoveCount)
            {
                Debug.Log("현재 턴에서는 더이상 유닛을 이동시킬 수 없습니다.");
                _inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
                return;
            }
            _unitManager.UnitMoveFunc(_inputManager._currSelectedUnit._currPlace,placeObject);
            Debug.Log("Move");
        }
        _inputManager.e_CLICKERSTATE =  InputManager.E_CLICKERSTATE.STANDBY;
    }
    public Player getPlayer(bool isPlayer) {
        if(isPlayer) {
            return Player;
        }
        return Enemy;
    }

    public Player getPlayer(PlaceObject placeObject) {
        if(placeObject.isPlayerPlace) {
            return Player;
        }
        return Enemy;
    }
    public Player getEnemy(PlaceObject placeObject) {
        if(placeObject.isPlayerPlace) {
            return Enemy;
        }
        return Player;
    }
}
