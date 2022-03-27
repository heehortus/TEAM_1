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
    [SerializeField] EffectManager _effectManager;

    public static PlaceManager placeManager { get { return m_cInstance._placeManager; } }
    public static UnitManager unitManager { get { return m_cInstance._unitManager; } }
    public static InputManager inputManager { get { return m_cInstance._inputManager; } }
    public static UIManager uiManager { get { return m_cInstance._uiManager; } }
    public static SceneManager sceneManager { get { return m_cInstance._sceneManager; } }
    public static ResourceManager resourceManager { get { return m_cInstance._resourceManager; } }
    public static BattleManager battleManager { get { return m_cInstance._battleManager; } }
    public static EffectManager effectManager { get { return m_cInstance._effectManager; } }

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
        }
    }
    private void Start()
    {
        placeManager.Init();
        unitManager.Init();
        inputManager.Init();
        sceneManager.Init();
        uiManager.Init();
        resourceManager.Init();
        battleManager.Init();
        effectManager.Init();

        sceneManager.Player._currResource = sceneManager.basicResource; // 처음 제공하는 자원 (임시)
        uiManager.ChangeInfoBar();
    }
    public void Update() {
        placeManager.OnUpdate();
        unitManager.OnUpdate();
        inputManager.OnUpdate();
        sceneManager.OnUpdate();
        uiManager.OnUpdate();
        resourceManager.OnUpdate();
        battleManager.OnUpdate();
        effectManager.OnUpdate();
    }

}
