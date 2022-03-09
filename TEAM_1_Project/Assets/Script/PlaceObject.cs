using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaceObject : MonoBehaviour
{
    public Transform point;
    [SerializeField] int x = 0;
    [SerializeField] int y = 0;
    // Start is called before the first frame update
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

    private void OnMouseDown()
    {
        GameManager.GetInstance().unitManager.CreateUnit((int)point.position.x, (int)point.position.y);

    }



}
