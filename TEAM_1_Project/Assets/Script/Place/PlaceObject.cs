using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaceObject : MonoBehaviour
{
    public Transform point;
    public PlaceManager.place place;
    [SerializeField] public int x = 0;
    [SerializeField] public int y = 0;
    [SerializeField] public bool isEmpty = true;
    // Start is called before the first frame update
    void Start()
    {
        SetUpPoint();
    }

    public void SetUpPoint()
    {
        
        

    }

    private void OnMouseDown()
    {
        var click_state = GameManager.GetInstance().inputManager.Get_ClickerState();
        if (click_state >= InputManager.E_CLICKERSTATE.CREATEUNIT1 &&
            click_state <= InputManager.E_CLICKERSTATE.CREATEUNIT4)
        {
             GameManager.GetInstance().unitManager.CreateUnit(place, this, "Unit");
            Debug.Log($"Create : {click_state}");
        }
        else if(click_state == InputManager.E_CLICKERSTATE.MOVE)
        {
            Debug.Log("Move");
        }
        GameManager.GetInstance().inputManager.SetClickerState((int)InputManager.E_CLICKERSTATE.STANDBY);
    }
}
