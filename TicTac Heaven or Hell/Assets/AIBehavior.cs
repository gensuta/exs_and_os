using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    int aiTurnNumber = 0;
    [SerializeField] Strategy myStrat;
    Board b;
    // Start is called before the first frame update
    void Start()
    {
        b = TicTacToeHandler.Instance.board;
    }

    // Update is called once per frame
    void Update()
    {
        if (TicTacToeHandler.Instance.turnTimer > 0f) return;

        if (TicTacToeHandler.Instance.isSinglePlayer && !TicTacToeHandler.Instance.isPlayerOnesTurn)
        {
            int winningSpot = b.GetWinningSpot();

            if (myStrat == null || myStrat.locations.Length == 0)
            {
                // check if player is abt to win
                //if -1 skip over
                if (winningSpot != -1 && b.cells[winningSpot]._button.interactable)
                {
                    b.cells[winningSpot].AI_FillCell();
                }
                else
                {
                    //check for an empty cell
                    b.cells[b.getEmptyCell()].AI_FillCell();
                }
            }
            else
            {
                if (b.cells[myStrat.locations[aiTurnNumber]]._button.interactable)
                {
                    b.cells[myStrat.locations[aiTurnNumber]].AI_FillCell();
                    aiTurnNumber++;
                }
                else
                {
                    //check if player is abt to win
                    if(winningSpot != -1 && b.cells[winningSpot]._button.interactable)
                    {
                        b.cells[winningSpot].AI_FillCell();
                    }
                    else
                    {
                        //check for an empty cell
                        b.cells[b.getEmptyCell()].AI_FillCell();
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class Strategy
{
    public int[] locations; 
    // 0 1 2
    // 3 4 5
    // 6 7 8
}
