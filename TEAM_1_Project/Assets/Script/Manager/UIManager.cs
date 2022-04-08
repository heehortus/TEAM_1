using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    public void Init()
    {
        ChangeInfoBar();
        Background.GetComponent<SpriteRenderer>().sprite = ResourceManager.LoadSprite(string.Format("Stage{0}BG",
            GameData.GetInstance().selectStage.Item1));
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
        Text _text = unitInfo.GetComponentInChildren<Text>();
        if (unit.GetComponent<Boom>() != null)
        {
            Boom _boom = unit.GetComponent<Boom>();
            _text.text = $"타입 : 폭탄\n" +
                         $"식량소모 :{_boom.coast}\n" +
                         $"데미지 :{_boom.damage}\n" +
                         $"성장력 :{_boom.growth}\n" +
                         $"레벨 :{_boom.level}\n" +
                         $"속도 :{_boom._speed}\n";
        }
        else if (unit.GetComponent<Seed>() != null)
        {
            Seed _seed = unit.GetComponent<Seed>();
            _text.text = $"타입 : 씨앗\n" +
                         $"식량소모 :{_seed.coast}\n" +
                         $"성장력 :{_seed._growth}\n" +
                         $"성장턴 :{_seed.level}/{_seed.maxLevel}\n";
        }
        else if (unit.GetComponent<Stealer>() != null)
        {
            Stealer _stealer = unit.GetComponent<Stealer>();
            _text.text = $"타입 : 다람쥐\n" +
                         $"식량소모 :{_stealer.coast}\n" +
                         $"훔치기 :{_stealer.stealCount}\n" +
                         $"공격력 :{_stealer.attackpower}\n";
        }
    }
    public void ShowVictoryUI(bool isAlreadyCleared)
    {
        GameData gameData = GameData.GetInstance();
        if (gameData.selectStage.Item1==3&& gameData.selectStage.Item2 == 3)
        {
            Instantiate(ResourceManager.LoadUI("UI_Victory_Final")).transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
        }
        else
        {
            Instantiate(ResourceManager.LoadUI("UI_Victory")).transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
            
            List<string> copy_NoHaveUnit = gameData.noHaveUnit.ToList();
            int cnt = 3;
            if (copy_NoHaveUnit.Count < 3) cnt = copy_NoHaveUnit.Count;

            if (cnt >= 1 && !isAlreadyCleared)
            {
                GameObject ug = Instantiate(ResourceManager.LoadUI("UI_GetCompensation"));
                ug.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);

                for (int i = 0; i < cnt; i++)
                {
                    int rand = Random.Range(0, copy_NoHaveUnit.Count);

                    GameObject cb = Instantiate(ResourceManager.LoadUI("CompensationUnitButton"));
                    cb.transform.SetParent(ug.GetComponent<UI_GetCompensation>().OutLine.transform);
                    cb.GetComponent<CompensationUnitButton>().unitName = copy_NoHaveUnit[rand];
                    cb.GetComponent<CompensationUnitButton>().GetComponentInChildren<Text>().text = copy_NoHaveUnit[rand];

                    copy_NoHaveUnit.RemoveAt(rand);
                }
            }
        }
    }
}
