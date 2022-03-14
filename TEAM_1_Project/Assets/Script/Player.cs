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
    static Player player;
    public Dictionary<string, bool> _unitDic = new Dictionary<string, bool>();
    void Start()
    {
        _unitDic.Add("SeedUnit", true);
        _unitDic.Add("BoomUnit", true);
        _unitDic.Add("StealerUnit", true);
        _unitDic.Add("Unit", true); // 일단 UnitFactory에 있는 유닛들만 임시로 보유하도록 설정
    }
    private void Awake()
    {
        player = this;
    }
    static public Player GetInstance()
    {
        return player;
    }
    void Update()
    {
        
    }
}
