using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, UnitInterface
{
	private int x = 0, y = 0;
	bool isUnitClick;
	[SerializeField] int coast;
	[SerializeField] int level;
	[SerializeField] Units unit;
	[SerializeField] SpriteRenderer character;

	enum Units { boom, stealer, crystal };

	void Unitablity()
    {
        switch (unit)
        {
			case Units.boom:
				boom();
				break;
			case Units.stealer:
				stealer();
				break;
        }
    }
	void stealer()
    {
		int stealCount;
		switch (level)
		{
			// 도둑같은 경우는 raycast를 쏴서 맞은 타일을 맞춰도 되고, 유닛을 맞춰서 현재 도둑 앞에 뭐가있는지 판별하면
			// 좋겠다고 생각했습니다.
			case 1:
				coast = 3;
				stealCount = 1;
				break;
			case 2:
				coast = 5;
				stealCount = 3;
				break;
			case 3:
				coast = 7;
				stealCount = 5;
				break;
		}

	}
	void boom()
    {
		int attackPower;
		switch (level)
		{
			// 폭탄은 아직 정확한 것은 아니지만, 도둑이 폭탄을 들고 자기 진형으로 가는 그런 시스템이라면
			// layer를 사용하여 상대 진형에 가면 터지도록 코드를 짜면 어떨까 생각해봤습니다
			case 1:
				coast = 3;
				attackPower = 3;
				break;
			case 2:
				coast = 5;
				attackPower = 5;
				break;
			case 3:
				coast = 7;
				attackPower = 7;
				break;
		}
	}
	void crystal()
    {
		switch (level)
		{
			// 턴 매니저에서 턴 값을 받아와 턴 값이 증가 할 때 마다 level을 증가하도록 짜면 어떨까 생각했습니다.
			case 1:
				coast = 3;
				break;
			case 2:
				coast = 5;
				break;
			case 3:
				coast = 7;
				break;
		}
	}
	void OnMouseDown()
    {
		isUnitClick = true;
    }
	public void clickfunc() {
        if (isUnitClick)
        {

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
