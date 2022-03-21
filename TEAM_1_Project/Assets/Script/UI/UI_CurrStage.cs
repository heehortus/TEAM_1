using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CurrStage : MonoBehaviour
{
    public TextMeshProUGUI _text;
    private void Start()
    {
        _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        _text.text = $"Stage {GameObject.Find("Player").GetComponent<Player>()._selectStage}";
    }
}
