using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [Header("State Machine")]
    [SerializeField] private List<IState> _states = new List<IState>();
    [SerializeField] private IState currentState;

    public static Action<IState> OnStateChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {       
        _states.Add(new MenuState());
        _states.Add(new BetState());
        _states.Add(new GameState());
        _states.Add(new ResultState());
    }

    // Update is called once per frame
    void Update()
    {
        currentState?.OnUpdateState();
    }

    public void ChangeState(int index) 
    {
        currentState?.OnExitState();
        currentState = _states[index];
        currentState?.OnEnterState();

        OnStateChange?.Invoke(currentState);
    }
}
