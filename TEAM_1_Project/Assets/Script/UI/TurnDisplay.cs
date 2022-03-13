using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TurnDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMesh = null;
    void Awake() {
        textMesh = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }
    public void changeTurn(int turn) {
        textMesh.text = string.Format("{0}",turn);
    }
}
