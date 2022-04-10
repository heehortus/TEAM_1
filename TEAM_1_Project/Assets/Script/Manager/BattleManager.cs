using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    //float _battleTime = 1.0f;
    int _basicallyProvideResource = 1;

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
        //상대 유닛 생성
        (GameManager.sceneManager.Enemy as EnemyPlayer).enemyAI.PlaceUnits();
        StartCoroutine("BattleCoroutine");
    }
    IEnumerator BattleCoroutine()
    {
        BattleLogic();
        for(int i = 0; i < GameManager.unitManager.UnitList.Count; i++)
        {
            GameManager.enemy.Skill();
            yield return new WaitForSeconds(GameManager.unitManager.doBattle(i));
            GameManager.uiManager.ChangeInfoBar();
        }
        GameManager.unitManager.RemoveUnits();
        for (int i = 0; i < GameManager.unitManager.UnitList.Count; i++)
        {
            GameManager.unitManager.UnitList[i].firstTurn++;
        }
        EndBattle();
    }
    void BattleLogic()
    {
        GameManager.inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
        GameManager.placeManager.display(false);
        GameManager.uiManager.ChangePlaceToBattle();
        GameManager.unitManager.UnitList.Sort();
        Debug.Log("전투 시작!");
    }
    void EndBattle()
    {
        _isBattle = false;
        Debug.Log("전투 끝!");
        GameManager.sceneManager.endBattle();
        GameManager.uiManager.changeTurn();
        GameManager.uiManager.ChangeBattleToPlace();
        GameManager.uiManager.ChangeInfoBar();
    }
    void ProvideResource()
    {
        Player player = GameManager.sceneManager.getPlayer(true);
        Player enemy = GameManager.sceneManager.getPlayer(false);
        player._currResource = Mathf.Clamp(player._currResource + _basicallyProvideResource, 0, player._maxResource);
        enemy._currResource = Mathf.Clamp(enemy._currResource + _basicallyProvideResource, 0, enemy._maxResource);
    }
}
