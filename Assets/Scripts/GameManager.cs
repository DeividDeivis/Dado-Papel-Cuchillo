using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int playersInGame;
    [SerializeField] private GameStateController stateController;
    private int stateIndex = 0;
    public int StateIndex => stateIndex;
    public UIController _UI { get; private set; }
    public List<PlayerController> playerControllers { get; private set; }
    public int m_Round { get; private set; }

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _UI = FindFirstObjectByType<UIController>();
        stateController = FindFirstObjectByType<GameStateController>();

        playerControllers = new List<PlayerController>();
        for (int i = 1; i > playersInGame; i++)       
            playerControllers.Add(new PlayerController($"Player {i}", 10));       

        m_Round = 0;

        stateController.ChangeState(stateIndex);
    }

    public void NextState() 
    {
        stateIndex++;
        stateController.ChangeState(stateIndex);
    }
}
