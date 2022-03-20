using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHandler : MonoBehaviour
{
    public static event Action DialogueStart, BattleStart, RoundStart, GachaStart;
    public static event Action DialogueEnd, BattleEnd, GachaEnd;

    public static event Action TicTacToeMode, ConnectFourMode, GoMode;

    public static StateHandler Instance;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (this != Instance)
                Destroy(gameObject);
        }
    }

    public void StartRound()
    {
        RoundStart?.Invoke();
    }

    public void InitateDialogue()
    {
        DialogueStart?.Invoke();
    }

    public void InitiateBattle()
    {
        BattleStart?.Invoke();

    }

    public void InitiateGacha()
    {
        GachaStart?.Invoke();
    }


    public void EndDialogue()
    {
        DialogueEnd?.Invoke();
    }
    public void EndBattle()
    {
        BattleEnd?.Invoke();
    }
    public void EndGacha()
    {
        GachaEnd?.Invoke();
    }
    public void StartConnectFour()
    {
        ConnectFourMode?.Invoke();
    }
    public void StartTicTacToe()
    {
        TicTacToeMode?.Invoke();
    }
}
