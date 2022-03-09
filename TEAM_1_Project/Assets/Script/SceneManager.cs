using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int currTurn;

    public GameObject UI_Parent;
    public GameObject Unit_Parent;
    void Start()
    {
        UI_Parent = new GameObject(name = "UI_Parent"); // UI들 묶어서 하이라키창에 저장
        Unit_Parent = new GameObject(name = "Unit_Parent"); // Unit들 묶어서 하이라키창에 저장

        Instantiate(GameManager.GetInstance().resourceManager.LoadUI("UI_Turn_End_Button")).transform.parent = UI_Parent.transform; // 턴 종료 UI 버튼 생성
        Instantiate(GameManager.GetInstance().resourceManager.LoadUnit("Unit_Tmp")).transform.parent = Unit_Parent.transform; // 임시 유닛 생성 ( 정보창 확인용) 
    }

    void Update()
    {
        
    }
}
