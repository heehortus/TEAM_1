using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string _nickName;
    public int _maxHP;
    public int _currHP;
    public int _maxResource;
    public int _currResource;
    static Player player = null;
    public Dictionary<string, bool> _unitDic = new Dictionary<string, bool>();
    void Start()
    {


    }
    private void Awake()
    {
        player = this;

        player._unitDic.Add("SeedUnit1", true);
        player._unitDic.Add("SeedUnit2", false);
        player._unitDic.Add("SeedUnit3", false);

        player._unitDic.Add("BoomUnit1", true);
        player._unitDic.Add("BoomUnit2", false);
        player._unitDic.Add("BoomUnit3", false);

        player._unitDic.Add("StealerUnit1", true);
        player._unitDic.Add("StealerUnit2", false);
        player._unitDic.Add("StealerUnit3", false);

        player._unitDic.Add("Unit", false); // 일단 UnitFactory에 있는 유닛들만 임시로 보유하도록 설정
    }
    static public Player GetInstance()
    {
        return player;
    }
    void Update()
    {
        if(_maxHP == 0)
        {

        }
    }
}
