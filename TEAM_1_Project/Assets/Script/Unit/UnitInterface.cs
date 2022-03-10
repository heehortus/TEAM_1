using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UnitInterface
{
    public void clickfunc();

    public void setUnitPos(PlaceManager.place place,int x,int y);
    
    public bool checkPos(int a,int b);

}
