using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit : MonoBehaviour, UnitInterface
{
    [SerializeField] bool isUnitClick;
	[SerializeField] int coast;
	[SerializeField] int level;
	[SerializeField] SpriteRenderer character;

    public Place _currPlace;

	public void setUnitPos(Place _place) {
		_currPlace = new Place(_place);
        var _curPlaceTransform = GameManager.GetInstance().placeManager.GetPlace(_currPlace).transform;
        transform.position = _curPlaceTransform.position - Vector3.forward;
	}

	void OnMouseDown()
    {
        if(isUnitClick)
        {
            isUnitClick = false;
        }
        else
        {
            isUnitClick = true;
        }
        GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.MOVE);
        GameManager.GetInstance().inputManager._currSelectedUnit = this;
    }
	public void clickfunc() {
	}

	public bool checkPos(Place place) {
		if(place == _currPlace)
			return true;
		return false;
	}

}
