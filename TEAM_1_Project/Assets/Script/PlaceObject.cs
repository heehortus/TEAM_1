using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    Transform point;
    // Start is called before the first frame update
    void Start()
    {
        point = this.transform;
    }

    public Transform SendPointData()
    {
        //UnitManager

        return point;
    }



}
