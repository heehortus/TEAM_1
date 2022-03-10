using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaceObject : MonoBehaviour
{
    public Transform point;
    public PlaceManager.place place;
    public int x;
    public int y;
    // Start is called before the first frame update

    /*
    void Start()
    {
        SetUpPoint();
    }

    public void SetUpPoint()
    {
        point = this.transform;
        for (int i = 0; i < 12; i++)
        {
            if(this == GameManager.GetInstance().placeManager.GivePlaceValue(i))
            {
                this.x = (i % 4) + 1;
                this.y = (i / 4) + 1;
            }
        }
        

    }
    */

    private void OnMouseDown()
    {
        GameManager.GetInstance().unitManager.CreateUnit(place,x,y);

    }

}
