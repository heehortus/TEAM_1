using System;
using System.Collections.Generic;
using System.Linq;

public class EnemyAI
{
    private Player player;
    private List<string> unitList;

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
        var PlaceUnits = unitList.OrderBy(a => Guid.NewGuid()).Take(1);//개수 선택 가능
        foreach (var item in PlaceUnits)
        {
            var placeObject = GameManager.placeManager.getPlaceObject(false,0,0).GetComponent<PlaceObject>();
            unitManager.CreateUnit(placeObject,item);
        }

    }
    
}