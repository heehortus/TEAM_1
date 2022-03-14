using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TurnDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMeshStr = null;
    TextMeshProUGUI textMesh = null;
    void Awake() {
        textMeshStr = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textMesh = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }
    public void changeTurn(int turn) {
        textMesh.text = string.Format("{0}",turn);
    }
    public void ChangeBattleToPlace()
    {
        textMeshStr.text = "Place Turn";
    }
    public void ChangePlaceToBattle()
    {
        textMeshStr.text = "Battle Turn";
    }
}
