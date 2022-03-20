using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    int turn, round;
    public bool isXTurn, isPlayerOnesTurn, isSinglePlayer;
    public int playerOne_Score, playerTwo_Score;

    [Space]
    public Board board;
    public ScoreKeeper scoreKeeper;
    [SerializeField] BoardGenerator boardGenerator;
    public static GameHandler Instance;

    public float turnTimer; // time till it goes to nextTurn, mainly for AI

    // should it be a bool or a game mode?
    public bool isConnectFour;

    bool switchChar;

    public static event Action OnNewTurn;

    [SerializeField] TextMeshProUGUI scoreText;


    private void Awake()
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

    private void OnEnable()
    {
        StateHandler.ConnectFourMode += ConnectFourMode;
        StateHandler.BattleStart += BattleStart;
        StateHandler.BattleEnd += BattleEnd;
        StateHandler.TicTacToeMode += TicTacToeMode;
    }

    private void TicTacToeMode()
    {

    }

    private void OnDisable()
    {

        StateHandler.ConnectFourMode -= ConnectFourMode;
        StateHandler.BattleStart -= BattleStart;
        StateHandler.BattleEnd -= BattleEnd;
        StateHandler.TicTacToeMode -= TicTacToeMode;
    }

    private void BattleEnd()
    {

    }

    private void BattleStart()
    {
        Init();
    }

    private void ConnectFourMode()
    {
        isConnectFour = true;
        boardGenerator.AddTiles(7);
    }

    private void Init()
    {
        int randNum = UnityEngine.Random.Range(0, 2);
        isPlayerOnesTurn = (randNum == 0) ? true : false; // since i keep forgetting. This is called a condition operator expression!!
        turn = 0;
        round = 1;
        boardGenerator.buildBoard();
    }

    private void Update()
    {
        if (turnTimer > 0f)
        {
            turnTimer -= Time.deltaTime;
        }
    }

    public void StartNewTurn()
    {
        turn++;
        isXTurn = !isXTurn;
        isPlayerOnesTurn = !isPlayerOnesTurn;

        if(isPlayerOnesTurn)
        {
            turnTimer = 1f;
        }
        OnNewTurn?.Invoke();
    }

    public void StartNewRound(bool isTie = false)
    {
        StateHandler.Instance.StartRound();

       

        round++;
        if (!isTie)
        {
            if (isPlayerOnesTurn) playerOne_Score++;
            else playerTwo_Score++;
        }

        scoreText.text = "Score \n" + playerOne_Score + "|" + playerTwo_Score;

        if (playerOne_Score >= 3 || playerTwo_Score >= 3) return;




        boardGenerator.ResetBoard();
        turn = 0;
        StartNewTurn();
    }

    public void CheckForWinner()
    {
        bool hasWinner = scoreKeeper.CheckForWinner();

        bool isTie = scoreKeeper.CheckForTie();


        if (hasWinner)
        {
            StartNewRound();
        }
        else if (isTie)
        {
            StartNewRound(true);
        }
        else
        {
            StartNewTurn();
        }

        /*         GameHandler.Instance.
        GameHandler.Instance.isPlayerOnesTurn = !GameHandler.Instance.isPlayerOnesTurn;*/
    }

    public string GetCurrentChar()
    {
        if (switchChar)
        {
            if (!isXTurn)
                return "X";
            else
                return "O";
        }
        else
        {
            if (!isXTurn)
                return "O";
            else
                return "X";
        }
    }

    public void ToggleSwitch()
    {
        switchChar = !switchChar;
    }
}
