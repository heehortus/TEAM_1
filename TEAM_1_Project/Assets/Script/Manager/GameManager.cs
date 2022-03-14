using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] public PlaceManager placeManager;
    [SerializeField] public UnitManager unitManager;
    [SerializeField] public InputManager inputManager;
    [SerializeField] public UIManager uiManager;
    [SerializeField] public SceneManager sceneManager;
    [SerializeField] public ResourceManager resourceManager;
    [SerializeField] public BattleManager battleManager;

    static GameManager m_cInstance;
    static public GameManager GetInstance()
    {
        return m_cInstance;
    }

    private void Awake()
    {
        if (m_cInstance == null)
        {
            m_cInstance = this;
            DontDestroyOnLoad(this.transform.parent);
        }
        else
        {
            if (this != m_cInstance)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
    private void Start()
    {
        m_cInstance.placeManager.Init();
        m_cInstance.unitManager.Init();
        m_cInstance.inputManager.Init();
        m_cInstance.uiManager.Init();
        m_cInstance.sceneManager.Init();
        m_cInstance.resourceManager.Init();
        m_cInstance.battleManager.Init();
    }
    public void Update() {
        m_cInstance.placeManager.OnUpdate();
        m_cInstance.unitManager.OnUpdate();
        m_cInstance.inputManager.OnUpdate();
        m_cInstance.uiManager.OnUpdate();
        m_cInstance.sceneManager.OnUpdate();
        m_cInstance.resourceManager.OnUpdate();
        m_cInstance.battleManager.OnUpdate();
    }

}
