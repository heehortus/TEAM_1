using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, UnitInterface
{
	private int x = 0, y = 0;
	public void clickfunc() {

	}
    public void Movefuc(int x,int y)
    {

    }

	public bool checkPos(int a,int b) {
		if(a == this.x && b == this.y)
			return true;
		return false;
	}
}
