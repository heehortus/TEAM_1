using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    public void Init()
    {
        ChangeInfoBar();
        Background.GetComponent<SpriteRenderer>().sprite = ResourceManager.LoadSprite(string.Format("Stage{0}BG",
            GameManager.sceneManager.Player._selectStage.Item1));
    }
    public void OnUpdate()
    {

    }
    [SerializeField] GameObject TurnObject;
    [SerializeField] GameObject InfoBar;
    public int _uiInfoOffset = 50;
    public Stack<GameObject> _popupUIs = new Stack<GameObject>();
    public void changeTurn() {
        TurnObject.GetComponent<TurnDisplay>().changeTurn(++GameManager.sceneManager.presentTurn);
    }

    public void changeTurn(int turn) {
        GameManager.sceneManager.presentTurn = turn;
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

        Player _player = GameManager.sceneManager.getPlayer(true);
        Player _enemy = GameManager.sceneManager.getPlayer(false);
        if (_player._currHP <= 0 || _enemy._currHP <= 0)
        {
            if (_player._currHP <= 0 && _enemy._currHP == 0)
            {
                if (_player._currResource >= _enemy._currResource)
                {
                    GameManager.GetInstance().SetGameState(1);
                }
                else GameManager.GetInstance().SetGameState(2);
            }
            else if (_player._currHP <= 0)
            {
                GameManager.GetInstance().SetGameState(2);
            }
            else if (_enemy._currHP <= 0)
            {
                GameManager.GetInstance().SetGameState(1);
            }
        }
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

    public void ShowUnitInfo(GameObject unit, GameObject unitInfo)
    {
        TextMeshProUGUI _text = unitInfo.GetComponentInChildren<TextMeshProUGUI>();
        if (unit.GetComponent<Boom>() != null)
        {
            Boom _boom = unit.GetComponent<Boom>();
            _text.text = $"Type : Boom\n" +
                         $"Name :{_boom._name}\n" +
                         $"Level :{_boom.level}\n" +
                         $"Speed :{_boom._speed}\n" +
                         $"Damage :{_boom.damage}";
        }
        else if (unit.GetComponent<Seed>() != null)
        {
            Seed _seed = unit.GetComponent<Seed>();
            _text.text = $"Type : Seed\n" +
                         $"Name :{_seed._name}\n" +
                         $"Level :{_seed.level}\n" +
                         $"Speed :{_seed._speed}\n" +
                         $"Resource :{_seed.myresource}";
        }
        else if (unit.GetComponent<Stealer>() != null)
        {
            Stealer _stealer = unit.GetComponent<Stealer>();
            _text.text = $"Type : Stealer\n" +
                         $"Name :{_stealer._name}\n" +
                         $"Speed :{_stealer._speed}\n" +
                         $"Level :{_stealer.level}\n" +
                         $"Power :{_stealer.attackpower}";
        }
    }
}
