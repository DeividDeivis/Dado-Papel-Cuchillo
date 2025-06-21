using UnityEngine;

public class BetState : IState
{
    private float timeToBetInSec = 15;
    private float currentTime = 0;
    private bool startTimer = false;  

    private BetUI _UI;

    public void OnEnterState()
    {
        currentTime = timeToBetInSec;

        _UI = (BetUI)GameManager.Instance._UI.GetUI();
        _UI.SetContainer();
        _UI.ShowContainer();

        _UI.UpdateTimeUI(1);

        _UI.BetAnimIn(()=> startTimer = true);
    }

    public void OnUpdateState()
    {
        if (startTimer && currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            float percentage = currentTime / timeToBetInSec;
            _UI.UpdateTimeUI(percentage);

            if (currentTime <= 0) 
            {
                startTimer = false;
                CheckPlayersBet();
            }
        }
    }

    public void OnExitState()
    {
        _UI.HideContainer();
    }

    private void CheckPlayersBet() 
    {
        bool player1Bet = _UI._Player1UI.betToggles.AnyTogglesOn();
        bool player2Bet = _UI._Player2UI.betToggles.AnyTogglesOn();

        if (!player1Bet || !player2Bet) // Check if any player didn't bet
        {
            if (!player1Bet)
            {
                Debug.Log("Player 1 didn't bet, LOSE");
            }
            else
            {
                Debug.Log("Player 2 didn't bet, LOSE");
            }
        }
        else
        { 
            
        }
    }
}
