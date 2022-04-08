using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : Player
{
    public EnemyAI enemyAI;
    public GameObject MonkeyImage;
    protected override void Awake()
    {
        base.Awake();
        enemyAI = new EnemyAI(this);
        string path = null;
        if (GameData.GetInstance().selectStage.Item2 == 1)
        {
            path = "기본숭이/기본 숭이";
        }
        else if (GameData.GetInstance().selectStage.Item2 == 2)
        {
            path = "기본숭이 2/기본 숭이 2";
        }
        else
        {
            path = "기본숭이/기본 숭이";
        }


        MonkeyImage = Instantiate(ResourceManager.LoadUnit(path));
        MonkeyImage.transform.SetParent(transform);
        MonkeyImage.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        MonkeyImage.transform.position = transform.position;
        ;
    }
    
}