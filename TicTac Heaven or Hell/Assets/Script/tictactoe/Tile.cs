using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public Button _button;

    public event Action CellFilled;
    public bool isFilled;

    Board board;

    // Start is called before the first frame update
    void Init()
    {
        board = transform.parent.GetComponent<Board>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        Init();

        CellFilled += GameHandler.Instance.CheckForWinner;
        StateHandler.TicTacToeMode += TicTacToeMode;
        StateHandler.ConnectFourMode += ConnectFourMode;
        StateHandler.RoundStart += RoundStart;
    }

    private void RoundStart()
    {
        isFilled = false;// resets!
    }

    private void ConnectFourMode()
    {

    }

    private void TicTacToeMode()
    {
        if(!isFilled && _button != null)
        {
            _button.interactable = true;
        }
    }

    private void OnDisable()
    {
        CellFilled -= GameHandler.Instance.CheckForWinner;
    }


    public void FillCell()
    {
        if (GameHandler.Instance.isSinglePlayer && !GameHandler.Instance.isPlayerOnesTurn) return;

        if (GameHandler.Instance.isConnectFour && !board.isTileBelowFilled(this)) return;

        _text.text = GameHandler.Instance.GetCurrentChar();
        _button.interactable = false;

        isFilled = true;

        CellFilled?.Invoke();
    }

    public void AI_FillCell()
    {
        if (GameHandler.Instance.isConnectFour && !board.isTileBelowFilled(this)) return;

        _text.text = GameHandler.Instance.GetCurrentChar();
        _button.interactable = false;

        CellFilled?.Invoke();

        isFilled = true;
    }


}
