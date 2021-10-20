using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeHandler : MonoBehaviour
{
    int turn, round;
    public bool isXTurn, isPlayerOnesTurn, isSinglePlayer;
    [Space]
    public int playerOne_Score, playerTwo_Score;


    public Board board;
    public static TicTacToeHandler Instance;

    public float turnTimer; // time till it goes to nextTurn

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (this != Instance)
                Destroy(gameObject);
        }
        Init();
    }

    private void Init()
    {
        int randNum = Random.Range(0, 2);
        isPlayerOnesTurn = (randNum == 0) ? true : false; // since i keep forgetting. This is called a condition operator expression!!
        turn = 0;
        round = 1;
        board.buildBoard();
    }

    private void Update()
    {
        if(turnTimer >0f)
        {
            turnTimer -= Time.deltaTime;
        }
    }

    public void StartNewTurn()
    {
        turn++;
        isXTurn = !isXTurn;
        isPlayerOnesTurn = !isPlayerOnesTurn;
    }

    public void StartNewRound(bool isTie = false)
    {
        round++;
        if (!isTie)
        {
            if (isPlayerOnesTurn) playerOne_Score++;
            else playerTwo_Score++;
        }
        if (playerOne_Score >= 3 || playerTwo_Score >= 3) return;



        board.ResetBoard();
        turn = 0;
        StartNewTurn();
    }



    public string GetCurrentChar()
    {
        if (!isXTurn)
            return "O";
        else
            return "X";
    }
}
