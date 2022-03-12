using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : Unit
{
	void Awake() {
        character = gameObject.GetComponent<SpriteRenderer>();
        character.sprite = GameManager.GetInstance().resourceManager.LoadSprite("squirrel");
	}
}
