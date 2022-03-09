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
    static GameManager m_cInstance; // ���� �Ŵ��� �̱��� ����
    static public GameManager GetInstance()
    {
        return m_cInstance;
    }

    private void Awake()
    {
        m_cInstance = this;
    }

    public void Update() {
        //<Test>
            if(Input.anyKeyDown) {
                unitManager.CreateUnit(0,0);
            }
        //</Test>
    }

}
