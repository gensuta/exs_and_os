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

    public event Action TileFilled;
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

        TileFilled += GameHandler.Instance.CheckForWinner;
        StateHandler.TicTacToeMode += TicTacToeMode;
        StateHandler.ConnectFourMode += ConnectFourMode;
        StateHandler.RoundStart += RoundStart;
    }

    private void RoundStart()
    {
        ClearTile(); // resets!
    }

    public void ClearTile()
    {
        _text.text = "";
        _button.interactable = true;
        isFilled = false;
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
        TileFilled -= GameHandler.Instance.CheckForWinner;
    }

    public void FillWithString(string s)
    {
        _text.text = s;

        if(string.IsNullOrEmpty(s))
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }    
    }

    public string GetContent()
    {
        return _text.text;
    }


    public void FillTile()
    {
        if (GameHandler.Instance.isSinglePlayer && !GameHandler.Instance.isPlayerOnesTurn) return;

        if (GameHandler.Instance.isConnectFour && !board.isTileBelowFilled(this)) return;

        _text.text = GameHandler.Instance.GetCurrentChar();
        _button.interactable = false;

        isFilled = true;

        TileFilled?.Invoke();
    }

    public void AI_FillTile()
    {
        if (GameHandler.Instance.isConnectFour && !board.isTileBelowFilled(this)) return;

        _text.text = GameHandler.Instance.GetCurrentChar();
        _button.interactable = false;

        TileFilled?.Invoke();

        isFilled = true;
    }


}
