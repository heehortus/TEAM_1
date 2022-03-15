using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, UnitInterface, IComparable<Unit>
{
    [SerializeField] bool isUnitClick;
	[SerializeField] protected int coast;
	[SerializeField] protected int level;
	[SerializeField] public SpriteRenderer character;
    [SerializeField] public PlaceObject _currPlace { get; private set;}
    public int _speed;
    public Define.UnitCamp _unitCamp;

    public int CompareTo(Unit other) // 스피드 순서로 정렬하기 위한 함수
    {
        if (_speed == other._speed)
            return 0;
        return (_speed > other._speed) ? 1 : -1;
    }
	public void setUnitPos(PlaceObject _place) {
		_currPlace = _place;
        transform.position = _currPlace.transform.position - Vector3.forward;
	}

    protected void Init()
    {
        character = gameObject.GetComponent<SpriteRenderer>();
        isPlayer();
        if (gameObject.tag == "Player")
            character.flipX = false;
        else if (gameObject.tag == "Enemy")
            character.flipX = true;
    }
    public virtual void Ability()
    {

    }
    void isPlayer()
    {
        if (UnitManager.Inst.isPlace)
        {
            gameObject.tag = "Player";
        }
        else
            gameObject.tag = "Enemy";

    }
    void OnMouseDown()
    {
        if (_unitCamp == Define.UnitCamp.enemyUnit)
        {
            Debug.Log("상대방 유닛입니다.");
            GameManager.inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
            return;
        }
        if (GameManager.battleManager._isBattle)
        {
            Debug.Log("전투 중엔 유닛을 이동할 수 없습니다.");
            GameManager.inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
            return;
        }
        if(isUnitClick)
        {
            isUnitClick = false;
        }
        else
        {
            isUnitClick = true;
        }
        if (GameManager.sceneManager._currMoveCount <= GameManager.sceneManager._maxMoveCount - 1)
        {
            GameManager.inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.MOVE;
        }
        GameManager.inputManager._currSelectedUnit = this;
    }
	public void clickfunc() {
    }

	public bool checkPos(PlaceObject place) {
        if (place == _currPlace)
        {
            Debug.Log("dd");
            return true;
        }
		return false;
	}

    public void setSprite()
    {

    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

}
