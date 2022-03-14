using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, UnitInterface
{
    [SerializeField] bool isUnitClick;
	[SerializeField] protected int coast;
	[SerializeField] protected int level;
	[SerializeField] public SpriteRenderer character;
    SpriteRenderer sprite;
    [SerializeField] public PlaceObject _currPlace { get; private set;}

	public void setUnitPos(PlaceObject _place) {
		_currPlace = _place;
        transform.position = _currPlace.transform.position - Vector3.forward;
	}

    private void Start()
    {
        character = gameObject.GetComponent<SpriteRenderer>();
        isPlayer();
        if (gameObject.tag == "Player")
            sprite.flipX = false;
        else if (gameObject.tag == "Enemy")
            sprite.flipX = true;
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
        if (GameManager.GetInstance().battleManager._isBattle)
        {
            Debug.Log("전투 중엔 유닛을 이동할 수 없습니다.");
            GameManager.GetInstance().inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.STANDBY;
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
        GameManager.GetInstance().inputManager.e_CLICKERSTATE = InputManager.E_CLICKERSTATE.MOVE;
        GameManager.GetInstance().inputManager._currSelectedUnit = this;
    }
	public void clickfunc() {
    }

	public bool checkPos(PlaceObject place) {
		if(place == _currPlace)
			return true;
		return false;
	}

    public void setSprite()
    {

    }

}
