using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit : MonoBehaviour, UnitInterface
{
    [SerializeField] protected int x = 0, y = 0;
    [SerializeField] bool isUnitClick;
    [SerializeField] protected int coast;
    [SerializeField] protected int level;
	[SerializeField] Units unit;
    [SerializeField] protected SpriteRenderer character;

	enum Units { boom, stealer, crystal };

	public void setUnitPos(PlaceManager.place place,int x,int y) {
		var placeobject = GameManager.GetInstance().placeManager.GivePlaceValue(place,x,y);
		transform.position = placeobject.transform.position;
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
    }
	public void clickfunc() {
        if (isUnitClick)
        {
            Movefuc(1, 1);
        }
	}
    public void Movefuc(int x,int y)
    {
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y), 3);
    }

	public bool checkPos(int a,int b) {
		if(a == x && b == y)
			return true;
		return false;
	}
}
