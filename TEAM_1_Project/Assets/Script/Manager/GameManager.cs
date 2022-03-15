using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] PlaceManager _placeManager;
    [SerializeField] UnitManager _unitManager;
    [SerializeField] InputManager _inputManager;
    [SerializeField] UIManager _uiManager;
    [SerializeField] SceneManager _sceneManager;
    [SerializeField] ResourceManager _resourceManager;
    [SerializeField] BattleManager _battleManager;

    public static PlaceManager placeManager { get { return m_cInstance._placeManager; } }
    public static UnitManager unitManager { get { return m_cInstance._unitManager; } }
    public static InputManager inputManager { get { return m_cInstance._inputManager; } }
    public static UIManager uiManager { get { return m_cInstance._uiManager; } }
    public static SceneManager sceneManager { get { return m_cInstance._sceneManager; } }
    public static ResourceManager resourceManager { get { return m_cInstance._resourceManager; } }
    public static BattleManager battleManager { get { return m_cInstance._battleManager; } }

    public enum E_GAMESTATE { GAMING, VICTORY, DEFEAT, STANDBY};
    [SerializeField] public E_GAMESTATE gameState = E_GAMESTATE.GAMING;

    public void SetGameState(int idx)
    {
        switch(idx)
        {
            case 0: 
                gameState = E_GAMESTATE.GAMING;
                break;
            case 1:
                gameState = E_GAMESTATE.VICTORY;
                break;
            case 2:
                gameState = E_GAMESTATE.DEFEAT;
                break;
            case 3:
                gameState = E_GAMESTATE.STANDBY;
                break;
            default:
                break;
        }
    }







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
        placeManager.Init();
        unitManager.Init();
        inputManager.Init();
        uiManager.Init();
        sceneManager.Init();
        resourceManager.Init();
        battleManager.Init();
    }
    public void Update() {
        placeManager.OnUpdate();
        unitManager.OnUpdate();
        inputManager.OnUpdate();
        uiManager.OnUpdate();
        sceneManager.OnUpdate();
        resourceManager.OnUpdate();
        battleManager.OnUpdate();
    }

}
