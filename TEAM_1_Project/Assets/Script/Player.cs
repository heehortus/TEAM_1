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
    public Dictionary<string, bool> _unitDic = new Dictionary<string, bool>();
    void Start()
    {


    }
    private void Awake()
    {
        _unitDic.Add("SeedUnit1", true);
        _unitDic.Add("SeedUnit2", false);
        _unitDic.Add("SeedUnit3", false);

        _unitDic.Add("BoomUnit1", true);
        _unitDic.Add("BoomUnit2", false);
        _unitDic.Add("BoomUnit3", false);

        _unitDic.Add("StealerUnit1", true);
        _unitDic.Add("StealerUnit2", false);
        _unitDic.Add("StealerUnit3", false);

        _unitDic.Add("Unit", false); // 일단 UnitFactory에 있는 유닛들만 임시로 보유하도록 설정
    }

    void Update()
    {
        if(_maxHP == 0)
        {

        }
    }
}
