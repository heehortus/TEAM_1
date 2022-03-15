using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseUnitButton : MonoBehaviour
{
    [SerializeField] int idx;
    public string _unitName; // 버튼에 유닛 이름을 부여해서 player의 유닛 리스트에 해당 유닛이 없으면 소환할 수 없음
    private void OnMouseDown()
    {
        if (GameManager.battleManager._isBattle)
        {
            Debug.Log("전투 중엔 유닛을 선택할 수 없습니다.");
            GameManager.inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
            return;
        }
        bool _isPlayerHaveUnit;
        GameManager.sceneManager.Player._unitDic.TryGetValue(_unitName, out _isPlayerHaveUnit);
        if (!_isPlayerHaveUnit)
        {
            Debug.Log("아직 획득하지 못한 유닛입니다.");
            GameManager.inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
            return;
        }
        GameManager.inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.CREATEUNIT;
        GameManager.inputManager._currSelectedButton = this;
        Debug.Log((idx + 1) + "번째 유닛이 선택되었습니다.");
    }
}
