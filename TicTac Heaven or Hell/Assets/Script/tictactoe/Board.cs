using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] Vector2 tictacSpacing, connectfourSpacing;
    [SerializeField] GridLayoutGroup gridLayout;
    public List<Tile> tiles;
    public bool isBoardBuilt;

    // 0 1 2
    // 3 4 5
    // 6 7 8

    // 0 1 2 3
    // 4 5 6 7
    // 8 9 10 11
    // 12 13 14 15

    private void OnEnable()
    {
        StateHandler.ConnectFourMode += ConnectFourMode;
        StateHandler.TicTacToeMode += TicTacToeMode;
    }



    private void OnDisable()
    {
        StateHandler.ConnectFourMode -= ConnectFourMode;
        StateHandler.TicTacToeMode -= TicTacToeMode;
    }

    private void ConnectFourMode()
    {
        gridLayout.spacing = connectfourSpacing;
    }
    private void TicTacToeMode()
    {
        gridLayout.spacing = tictacSpacing;
    }


    public bool isTileBelowFilled(Tile t ) // for connectfour. tile utilizes this function
    {
        int tileNum = tiles.IndexOf(t);

        if(tileNum > 11)
        {
            return true; // "true" because you're at the ground
        }

        int belowTileIndex = tileNum + 4;

        if(tiles[belowTileIndex].isFilled) //yup! tile below is filled!
        {
            return true;
        }

        if (GameHandler.Instance.isXTurn) GameHandler.Instance.turnTimer = 0.2f;

        return false;
    }
}
