using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Unit
{
    public static Seed Inst { get; private set; }
    void Awake() => Inst = this;
    public bool isbatch;
    public int mycoast = 1;
    GameObject findStealer = null;
    public override void Ability()
    {

        mycoast += 1;
        
    }
    private void Start()
    {
        if (UnitManager.Inst.isPlace)
            gameObject.tag = "Player";
        else
            gameObject.tag = "Enemy";
    }
    public int ReturnCoast()
    {
        return mycoast;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        findStealer = GameObject.Find("Unit_Tmp 2(Clone)");
        if(findStealer != null)
        {
            if (Stealer.GetInstance().isSteal && gameObject.tag == "Enemy")
            {
                OnDestroy();
                Stealer.GetInstance().isSteal = false;
            }
        }
    }
}
