using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UnitInterface
{
    public void clickfunc();

    public void setUnitPos(PlaceManager.place place,PlaceObject _place);
    
    public bool checkPos(PlaceObject _place);

}
