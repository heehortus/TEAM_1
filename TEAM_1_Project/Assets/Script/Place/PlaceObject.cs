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
        if(GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.CREATEUNIT1)
        {
            if (isEmpty)
            {
                GameManager.GetInstance().unitManager.CreateUnit(place, x, y);
                isEmpty = false;
                Debug.Log("Create 1");
            }
        }
        else if (GameManager.GetInstance().inputManager.Get_ClickerState() == InputManager.E_CLICKERSTATE.CREATEUNIT2)
        {
            if (isEmpty)
            {
                GameManager.GetInstance().unitManager.CreateUnit(place, x, y);
                isEmpty = false;
                Debug.Log("Create 2");
            }
        }


    }
}
