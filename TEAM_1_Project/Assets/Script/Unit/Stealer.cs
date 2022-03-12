using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
	void Awake() {
		character = GameManager.GetInstance().resourceManager.LoadSprite("squirrel");
	}
}
