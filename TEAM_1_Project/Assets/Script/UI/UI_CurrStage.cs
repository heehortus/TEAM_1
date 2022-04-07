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
        var selectedStage = GameData.GetInstance().selectStage;
        _text.text = $"{selectedStage.Item1}-{selectedStage.Item2}";
    }
}
