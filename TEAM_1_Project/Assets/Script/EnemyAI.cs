using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAI
{
    private Player player;
    private List<string> unitList;
    private int PlaceCount = 1;

    public EnemyAI(Player player)
    {
        this.player = player;
        var gd = GameData.GetInstance();
        var level = gd.selectStage;
        unitList = StageInfo.getStageUnitInfo(level.Item1,level.Item2);
    }
    public void PlaceUnits()
    {
        //사용 가능한 유닛 찾기
        var unitManager = GameManager.unitManager;
        var PlaceUnits = unitList.OrderBy(a => Guid.NewGuid()).Take(PlaceCount);//개수 선택 가능
        var PlaceList = GameManager.placeManager.getEmptyPlaceObject(false)
            .OrderBy(a => Guid.NewGuid()).Take(PlaceCount);
        var iterator = PlaceList.GetEnumerator();
        iterator.MoveNext();
        foreach (var item in PlaceUnits)
        {
            var item2 = iterator.Current.GetComponent<PlaceObject>();
            int x = item2.x, y = item2.y;
            Debug.Log(item);
            var placeObject = GameManager.placeManager.getPlaceObject(false, x, y).GetComponent<PlaceObject>();
            unitManager.CreateUnit(placeObject, item);
            iterator.MoveNext();
        }
    }
}
