using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public Button _button;


    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillCell()
    {
        TicTacToeHandler.Instance.turnTimer = 1f;

        if (TicTacToeHandler.Instance.isSinglePlayer && !TicTacToeHandler.Instance.isPlayerOnesTurn) return;

        _text.text = TicTacToeHandler.Instance.GetCurrentChar();
        _button.interactable = false;

        CheckRoundStuff();
    }

    public void AI_FillCell()
    {
        _text.text = TicTacToeHandler.Instance.GetCurrentChar();
        _button.interactable = false;

        CheckRoundStuff();
    }

    public void CheckRoundStuff()
    {
        bool hasWinner = TicTacToeHandler.Instance.board.CheckForWinner();

        bool isTie = TicTacToeHandler.Instance.board.CheckForTie();



        if (hasWinner)
        {
            TicTacToeHandler.Instance.StartNewRound();
        }
        else if (isTie)
        {
            TicTacToeHandler.Instance.StartNewRound(true);
        }
        else
        {
            TicTacToeHandler.Instance.StartNewTurn();
        }
    }
}
