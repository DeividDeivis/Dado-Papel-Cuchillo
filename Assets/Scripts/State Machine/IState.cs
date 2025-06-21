using System;
using UnityEngine;

public interface IState
{
    public void OnEnterState();

    public void OnUpdateState();

    public void OnExitState();
}

/*public abstract class State : MonoBehaviour
{
    public abstract UIContainer _UI { get; set; }

    public State(UIContainer stateUI) 
    {
        _UI = stateUI;
    }
}*/
