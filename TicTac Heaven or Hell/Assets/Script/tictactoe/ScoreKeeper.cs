using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    [SerializeField] Board currentBoard;

    public bool CheckForWinner()
    {
        if (GameHandler.Instance.isConnectFour)
        {
            return CheckForConnectFourWin();
        }

        for (int i = 0; i <= 6; i += 3)
        {

            //horizontal
            if (!DoValusMatch(i, i + 1))
                continue;

            if (!DoValusMatch(i, i + 2))
                continue;

            return true;
        }

        for (int i = 0; i <= 2; i++)
        {

            //vertical
            if (!DoValusMatch(i, i + 3))
                continue;

            if (!DoValusMatch(i, i + 6))
                continue;

            return true;
        }

        // Left Diagonal
        if (DoValusMatch(0, 4) && DoValusMatch(0, 8))
            return true;


        // Right Diagonal
        if (DoValusMatch(2, 6) && DoValusMatch(2, 4))
            return true;

        return false;
    }

    public bool CheckForTie()
    {
        for (int i = 0; i < currentBoard.tiles.Count; i++)
        {
            if (currentBoard.tiles[i]._button.interactable)
            {
                return false;
            }
        }

        return true; // all tiles are filled
    }

    bool DoValusMatch(int i, int n)
    {
        string a = currentBoard.tiles[i]._text.text;
        string b = currentBoard.tiles[n]._text.text;

        if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return false;

        if (a == b) return true;
        else return false;
    }



    // 0 1 2 3
    // 4 5 6 7
    // 8 9 10 11
    // 12 13 14 15


    public bool CheckForConnectFourWin()
    {
        for (int i = 0; i <= 8; i += 4)
        {

            //horizontal
            if (!DoValusMatch(i, i + 1))
                continue;

            if (!DoValusMatch(i, i + 2))
                continue;


            if (!DoValusMatch(i, i + 3))
                continue;

            return true;
        }

        for (int i = 0; i <= 3; i++)
        {

            //vertical
            if (!DoValusMatch(i, i + 4))
                continue;

            if (!DoValusMatch(i, i + 8))
                continue;

            if (!DoValusMatch(i, i + 12))
                continue;

            return true;
        }

        // Left Diagonal
        if (DoValusMatch(0, 5) && DoValusMatch(0, 10) && DoValusMatch(0, 15))
            return true;


        // Right Diagonal
        if (DoValusMatch(3, 6) && DoValusMatch(3, 9) && DoValusMatch(3, 12))
            return true;


        return false;
    }
}
