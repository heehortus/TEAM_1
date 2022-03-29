using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompensationUnitButton : MonoBehaviour
{
    public Button button;
    public string unitName;
    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(PushButton);
        button.onClick.AddListener(transform.parent.parent.GetComponent<UI_GetCompensation>().PushButton);
    }
    public void PushButton()
    {
        transform.parent.parent.GetComponent<UI_GetCompensation>().unitName = unitName;
    }
}
