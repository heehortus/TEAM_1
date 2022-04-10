using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayer : Player
{
    public EnemyAI enemyAI;
    public GameObject MonkeyImage;
    public Skill skill;
    public bool skillCheck = false;
    public string path = null;
    protected override void Awake()
    {
        base.Awake();
        _currResource = Int32.MaxValue;
        enemyAI = new EnemyAI(this);
        if (GameData.GetInstance().selectStage.Item2 == 1)
        {
            path = "기본숭이/기본 숭이";
        }
        else if (GameData.GetInstance().selectStage.Item2 == 2)
        {
            path = "기본숭이 2/기본 숭이 2";
        }
        else if(GameData.GetInstance().selectStage.Item1 == 1 && GameData.GetInstance().selectStage.Item2 == 3)
        {
            path = "치어리더 원숭이/치어리더 원숭이";
            skillCheck = true;
        }
        else if(GameData.GetInstance().selectStage.Item1 == 2 && GameData.GetInstance().selectStage.Item2 == 3)
        {
            path = "수도원숭이/수도 원숭이";
            skillCheck = true;
        }
        else if(GameData.GetInstance().selectStage.Item1 == 3 && GameData.GetInstance().selectStage.Item2 == 3)
        {
            path = "여기원숭이/여기원숭이 all";
            skillCheck = true;
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
    public void Skill()
    {
        if(skillCheck)
            skill.Skiil();
    }
    
}