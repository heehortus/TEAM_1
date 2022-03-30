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
    [SerializeField] BattleManager _battleManager;
    [SerializeField] EffectManager _effectManager;

    public static PlaceManager placeManager { get { return m_cInstance._placeManager; } }
    public static UnitManager unitManager { get { return m_cInstance._unitManager; } }
    public static InputManager inputManager { get { return m_cInstance._inputManager; } }
    public static UIManager uiManager { get { return m_cInstance._uiManager; } }
    public static SceneManager sceneManager { get { return m_cInstance._sceneManager; } }
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
                if (sceneManager.finished) break;
                sceneManager.finished = true;
                sceneManager.Player.ClearStage();
                uiManager.ShowVictoryUI();
                break;
            case 2:
                gameState = E_GAMESTATE.DEFEAT;
                if (sceneManager.finished) break;
                sceneManager.finished = true;
                Instantiate(ResourceManager.LoadUI("UI_Defeat")).transform.SetParent(sceneManager.UI_Parent.transform);
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
        sceneManager.Player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void Start()
    {
        placeManager.Init();
        unitManager.Init();
        inputManager.Init();
        sceneManager.Init();
        uiManager.Init();
        battleManager.Init();
        uiManager.ChangeInfoBar();
    }
    public void Update() {
        placeManager.OnUpdate();
        unitManager.OnUpdate();
        inputManager.OnUpdate();
        sceneManager.OnUpdate();
        uiManager.OnUpdate();
        battleManager.OnUpdate();
        effectManager.OnUpdate();
    }

}
