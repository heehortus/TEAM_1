using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class InputManager : MonoBehaviour
{
    public enum E_CLICKERSTATE { CREATEUNIT, MOVE, STANDBY }
    private E_CLICKERSTATE _CLICKERSTATE;
    public E_CLICKERSTATE e_CLICKERSTATE {
        get {return _CLICKERSTATE;}
        set {
            _CLICKERSTATE = value;
            if(value != E_CLICKERSTATE.STANDBY) {
                GameManager.placeManager.display(true);
            }
            else {
                GameManager.placeManager.display(false);
            }
        }
    }
    public Unit _currSelectedUnit = null;
    public ChooseUnitButton _currSelectedButton = null;
    public E_CLICKERSTATE Get_ClickerState()
    {
        return e_CLICKERSTATE;
    }
    public void Init()
    {
        
    }

    public void OnUpdate()
    {
        LeftClick();
        RightClick();
    }

    public void LeftClick()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (EventSystem.current.IsPointerOverGameObject()) return; // UI 클릭하면 종료
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); // 카메라에서 화면으로 광선을 쏴서 맞는 물체 판별
        if (GameManager.uiManager._popupUIs.Count > 0) Destroy(GameManager.uiManager._popupUIs.Pop()); // 팝업 UI (현재는 유닛 정보) 가 떠있으면 삭제
        if (hit.collider == null)
        {
            return;
        }
        //Debug.Log($"{hit.collider.name} 클릭");

        var _SceneManager = GameManager.sceneManager;

		if(hit.collider.gameObject.GetComponent<PlaceObject>() != null) {
            if (GameManager.battleManager._isBattle)
            {
                Debug.Log("전투 중엔 유닛을 배치할 수 없습니다.");
            }
            else
            {
                /*if (!hit.collider.gameObject.GetComponent<PlaceObject>().isPlayerPlace)
                {
                    Debug.Log("상대방의 진영입니다.");
                    e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
                }
                else
                {*/
                    _SceneManager.onClickPlaceObject(hit.collider.gameObject);
                //}  
            }      
        }
    }
    public void RightClick()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (GameManager.uiManager._popupUIs.Count > 0) Destroy(GameManager.uiManager._popupUIs.Pop());
        if (hit.collider == null)
        {
            return;
        }
        if(hit.collider.gameObject.GetComponent<Unit>() != null) // 광선을 맞은 물체가 Unit 컴포넌트를 가지고 있으면
        {
            GameObject _uiInfo = Instantiate(GameManager.resourceManager.LoadUI("UI_Unit_Info"));
            _uiInfo.transform.SetParent(GameManager.sceneManager.UI_Parent.transform);
            GameManager.uiManager._popupUIs.Push(_uiInfo);
            Image _iamge = _uiInfo.GetComponentInChildren<Image>();
            _iamge.gameObject.transform.position = Input.mousePosition + Vector3.right * GameManager.uiManager._uiInfoOffset;
            _iamge.sprite = hit.collider.gameObject.GetComponent<Unit>().character.sprite;
            _iamge.color = hit.collider.gameObject.GetComponent<Unit>().character.color;
        }
    }
}
