using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseUnitButton : MonoBehaviour
{
    [SerializeField] int idx;
    public string _unitName; // 버튼에 유닛 이름을 부여해서 player의 유닛 리스트에 해당 유닛이 없으면 소환할 수 없음
    [SerializeField] Player _player;
    private void OnMouseDown()
    {
        bool _isPlayerHaveUnit;
        _player._unitDic.TryGetValue(_unitName, out _isPlayerHaveUnit);
        if (!_isPlayerHaveUnit)
        {
            Debug.Log("아직 획득하지 못한 유닛입니다.");
            GameManager.GetInstance().inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
            return;
        }
        GameManager.GetInstance().inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.CREATEUNIT;
        GameManager.GetInstance().inputManager._currSelectedButton = this;
        Debug.Log((idx + 1) + "번째 유닛이 선택되었습니다.");
    }
}
