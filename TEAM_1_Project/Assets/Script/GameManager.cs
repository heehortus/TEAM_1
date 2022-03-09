using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] PlaceManager placeManager;
    [SerializeField] UnitManager unitManager;
    static GameManager m_cInstance; // 게임 매니저 싱글톤 패턴
    static public GameManager GetInstance()
    {
        return m_cInstance;
    }

    private void Awake()
    {
        m_cInstance = this;
    }

}
