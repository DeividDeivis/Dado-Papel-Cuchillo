using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public string playerName { get; private set; }
    public int currentLife { get; private set; }
    public int currentGold { get; private set; }
    public bool betAlready { get; private set; }

    [Header("Bet Info")]
    public int winPlayerBet { get; private set; } // 0 = no vote, 1 = Player 1, 2 = Player 2, etc.
    public int upgradeToConsume { get; private set; } // 0 = no upgrade, 1 = +Attack, 2 = -Damage, 3 = +Gold, 4 = Cancel enemy round.

    public PlayerController(string name, int life) 
    {
        playerName = name;
        currentLife = life;
        currentGold = 0;
        betAlready = false;

        winPlayerBet = 0;
        upgradeToConsume = 0;
    }

    public void SetBet(int bet) => winPlayerBet = bet;
    public void SetUpgradeToConsume(int upgrade) => upgradeToConsume = upgrade;
}
