using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseUnitButton : MonoBehaviour
{
    [SerializeField] int idx;
    private void OnMouseDown()
    {
        GameManager.GetInstance().inputManager.SetClickerState(idx);
        Debug.Log((idx + 1) + "번째 유닛이 선택되었습니다.");
    }
}
