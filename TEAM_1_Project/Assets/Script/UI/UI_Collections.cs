using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Collections : MonoBehaviour
{
    Player player;
    public Image[] seeds = new Image[3];
    public Image[] stealers = new Image[3];
    public Image[] booms = new Image[3];
    public void PushBackButton()
    {
        Audio.PlayEffect("ClickButton");
        Destroy(gameObject);
    }
    private void Start()
    {
        var gameData = GameData.GetInstance();
        for(int i = 0; i < 3; i++)
        {
            if (!gameData._unitDic[seeds[i].name])
            {
                seeds[i].color = Color.red;
            }
            if (!gameData._unitDic[stealers[i].name])
            {
                stealers[i].color = Color.red;
            }
            if (!gameData._unitDic[booms[i].name])
            {
                booms[i].color = Color.red;
            }
        }
    }
}
