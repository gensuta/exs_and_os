using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    int aiTurnNumber = 0;
    [SerializeField] Strategy myStrat;
    Board currentBoard;
    // Start is called before the first frame update
    void Start()
    {
        currentBoard = GameHandler.Instance.board;
    }


    void Update()
    {
        if (GameHandler.Instance.turnTimer > 0f || !GameHandler.Instance.board.isBoardBuilt) return;

        if (GameHandler.Instance.isSinglePlayer && !GameHandler.Instance.isPlayerOnesTurn)
        {
            int winningSpot = GetWinningSpot();

            if (myStrat == null || myStrat.locations.Length == 0)
            {
                // check if player is abt to win
                //if -1 skip over
                if (winningSpot != -1 && currentBoard.tiles[winningSpot]._button.interactable)
                {
                    currentBoard.tiles[winningSpot].AI_FillTile();
                }
                else
                {
                    //check for an empty cell
                    currentBoard.tiles[getEmptyCell()].AI_FillTile();
                }
            }
            else
            {
                if (currentBoard.tiles[myStrat.locations[aiTurnNumber]]._button.interactable)
                {
                    currentBoard.tiles[myStrat.locations[aiTurnNumber]].AI_FillTile();
                    aiTurnNumber++;
                }
                else
                {
                    //check if player is abt to win
                    if(winningSpot != -1 && currentBoard.tiles[winningSpot]._button.interactable)
                    {
                        currentBoard.tiles[winningSpot].AI_FillTile();
                    }
                    else
                    {
                        //check for an empty cell
                        currentBoard.tiles[getEmptyCell()].AI_FillTile();
                    }
                }
            }
        }
    }


    public int GetWinningSpot() // get the spot your opponent is abt to win with 
    {
        for (int i = 0; i <= 6; i += 3)
        {
            //horizontal
            if (DoValusMatch(i, i + 1))
                return i + 2;

            if (DoValusMatch(i, i + 2))
                return i + 1;

            if (DoValusMatch(i + 1, i + 2))
                return i;
        }

        for (int i = 0; i <= 2; i++)
        {

            //vertical
            if (DoValusMatch(i, i + 3))
                return i + 6;

            if (DoValusMatch(i, i + 6))
                return i + 3;

            if (DoValusMatch(i + 3, i + 6))
                return i;
        }

        // Left Diagonal
        if (DoValusMatch(0, 4))
            return 8;
        if (DoValusMatch(0, 8))
            return 4;
        if (DoValusMatch(4, 8))
            return 0;


        // Right Diagonal
        if (DoValusMatch(2, 4))
            return 6;
        if (DoValusMatch(2, 6))
            return 4;
        if (DoValusMatch(4, 6))
            return 2;

        return -1;

        // 0 1 2
        // 3 4 5
        // 6 7 8
    }


    public int getEmptyCell()
    {
        List<int> emptytiles = new List<int>();

        for (int i = 0; i < currentBoard.tiles.Count; i++)
        {
            if (currentBoard.tiles[i]._button.interactable)
            {
                emptytiles.Add(i);
            }
        }
        int randNum = Random.Range(0, emptytiles.Count);

        return emptytiles[randNum];

    }


    bool DoValusMatch(int i, int n)
    {
        string a = currentBoard.tiles[i]._text.text;
        string b = currentBoard.tiles[n]._text.text;

        if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return false;

        if (a == b) return true;
        else return false;
    }
}
