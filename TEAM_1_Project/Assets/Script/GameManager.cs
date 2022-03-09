using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    [SerializeField] public PlaceManager placeManager;
    [SerializeField] public UnitManager unitManager;
    [SerializeField] public SceneManager sceneManager;
    [SerializeField] public ResourceManager resourceManager;
    [SerializeField] public InputManager inputManager;
    [SerializeField] public UIManager uiManager;
    static GameManager m_cInstance; // ∞‘¿” ∏≈¥œ¿˙ ΩÃ±€≈Ê ∆–≈œ
    static public GameManager GetInstance()
    {
        return m_cInstance;
    }

    private void Awake()
    {
        m_cInstance = this;
    }

}
