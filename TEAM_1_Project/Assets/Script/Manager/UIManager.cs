using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void Init()
    {

    }
    public void OnUpdate()
    {

    }
    [SerializeField] GameObject TurnObject;
    public int _uiInfoOffset = 50;
    public Stack<GameObject> _popupUIs = new Stack<GameObject>();

    public void changeTurn(int turn) {
        TurnObject.GetComponent<TurnDisplay>().changeTurn(turn);
    }
}
