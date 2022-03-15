using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    float _battleTime = 5.0f;
    public bool _isBattle = false;
    public void Init()
    {
        
    }
    public void OnUpdate()
    {

    }
    public void StartBattle()
    {
        if (_isBattle)
        {
            Debug.Log("이미 전투중 입니다.");
            return;
        }
        _isBattle = true;
        StartCoroutine("BattleCoroutine");
    }
    IEnumerator BattleCoroutine()
    {
        BattleLogic();
        yield return new WaitForSeconds(_battleTime);
        EndBattle();
    }
    void BattleLogic()
    {
        GameManager.inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
        GameManager.placeManager.display(false);
        GameManager.uiManager.ChangePlaceToBattle();
        Debug.Log("전투 시작!");
    }
    void EndBattle()
    {
        _isBattle = false;
        Debug.Log("전투 끝!");

        ref int _turn = ref GameObject.Find("UI_Turn_End_Button").GetComponentInChildren<UI_Turn_End_Button>().turn;
        _turn++;
        GameManager.uiManager.changeTurn(_turn);
        GameManager.uiManager.ChangeBattleToPlace();
        GameManager.sceneManager._currMoveCount = 0;
    }
}
