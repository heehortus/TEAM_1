using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public void Init()
    {
        ChangeInfoBar();
    }
    public void OnUpdate()
    {

    }
    [SerializeField] GameObject TurnObject;
    [SerializeField] GameObject InfoBar;
    public int _uiInfoOffset = 50;
    public Stack<GameObject> _popupUIs = new Stack<GameObject>();

    public void changeTurn(int turn) {
        TurnObject.GetComponent<TurnDisplay>().changeTurn(turn);
    }
    public void ChangeBattleToPlace()
    {
        TurnObject.GetComponent<TurnDisplay>().ChangeBattleToPlace();
    }
    public void ChangePlaceToBattle()
    {
        TurnObject.GetComponent<TurnDisplay>().ChangePlaceToBattle();
    }

    public void ChangeInfoBar() {
        var playerInfo = InfoBar.transform.GetChild(0);
        var EnemyInfo = InfoBar.transform.GetChild(1);
        _ChangeInfoBar(playerInfo,true);
        _ChangeInfoBar(EnemyInfo,false);
    }

    private void _ChangeInfoBar(Transform obj,bool isPlayer) {
        var HelathBar = obj.GetChild(0).GetComponent<Slider>();
        var ResourceBar = obj.GetChild(1).GetComponent<Slider>();
        var Player = GameManager.sceneManager.getPlayer(isPlayer);
        HelathBar.maxValue = Player._maxHP;//최대 채력 변경
        HelathBar.value = Player._currHP;//현재 체력 변경
        obj.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Health : " + Player._currHP.ToString();//표시 값 변경
        ResourceBar.maxValue = Player._maxResource;//최대 자원량 변경
        ResourceBar.value = Player._currResource;//자원량 변경
        obj.GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>().text = "Seads : " + Player._currResource.ToString();//표시 값 변경
    }
}
