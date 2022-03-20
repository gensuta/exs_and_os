using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] GameObject board;

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

        Player.Instance.OnColumnErased += ClearColumn;
        Player.Instance.OnRowErased += ClearRow;

        Player.Instance.OnColumnShift += ShiftColumn;
        Player.Instance.OnRowShift += ShiftRow;

        Player.Instance.OnBoardRotated += OnBoardRotated;
    }

    private void OnDisable()
    {
        StateHandler.ConnectFourMode -= ConnectFourMode;
        StateHandler.TicTacToeMode -= TicTacToeMode;

        Player.Instance.OnColumnErased -= ClearColumn;
        Player.Instance.OnRowErased -= ClearRow;

        Player.Instance.OnColumnShift -= ShiftColumn;
        Player.Instance.OnRowShift -= ShiftRow;

        Player.Instance.OnBoardRotated -= OnBoardRotated;
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

    // 0 1 2
    // 3 4 5
    // 6 7 8

    // to the right
    // 2 0 1
    // 5 3 4
    // 8 6 7

    //to the left
    // 1 2 0
    // 4 5 3
    // 7 8 6

    public void ShiftColumn(int n, bool isShiftingLeft) // n represents the column we are shifting
    {
        n -= 1;

        for (int j = n; j <= 6; j += 3)
        {
            if (isShiftingLeft)
            {
                if (j == 0)
                {
                    string zeroContent = tiles[j].GetContent();
                    string oneContent = tiles[j + 1].GetContent();
                    string twoContent = tiles[j + 2].GetContent();

                    tiles[j].FillWithString(zeroContent);
                    tiles[j + 2].FillWithString(twoContent);
                    tiles[j + 1].FillWithString(oneContent);
                }
                else
                {
                    string zeroContent = tiles[j - 1].GetContent();
                    string oneContent = tiles[j].GetContent();
                    string twoContent = tiles[j + 1].GetContent();

                    tiles[j].FillWithString(zeroContent);
                    tiles[j - 1].FillWithString(twoContent);
                    tiles[j + 1].FillWithString(oneContent);
                }
            }

            else // right shift
            {
                if (j == 0)
                {
                    string zeroContent = tiles[j].GetContent();
                    string oneContent = tiles[j + 1].GetContent();
                    string twoContent = tiles[j + 2].GetContent();


                    tiles[j].FillWithString(zeroContent);
                    tiles[j - 1].FillWithString(twoContent);
                    tiles[j + 1].FillWithString(oneContent);

                }
                else
                {
                    string zeroContent = tiles[j - 1].GetContent();
                    string oneContent = tiles[j].GetContent();
                    string twoContent = tiles[j + 1].GetContent();

                    tiles[j].FillWithString(twoContent);
                    tiles[j - 1].FillWithString(oneContent);
                    tiles[j + 1].FillWithString(zeroContent);
                }

            }
        }

       //GameHandler.Instance.StartNewTurn(); // upon finishing this skill we need to deactivate it
    }

    // 0 1 2 // ROW 1
    // 3 4 5 // ROW 2 
    // 6 7 8 // ROW 3

    //right
    // 2 0 1
    // 5 3 4
    // 8 6 7

     //left
    // 1 2 0
    // 4 5 3
    // 7 8 6

    public void ShiftRow(int n, bool isShiftingLeft) // n represents the row we are shifting
    {

        for (int j = n; j <= 2; j++)
        {
            if (isShiftingLeft)
            {
                if(j== 0)
                {
                    string zeroContent = tiles[j].GetContent();
                    string oneContent = tiles[j + 1].GetContent();
                    string twoContent = tiles[j + 2].GetContent();

                    tiles[j].FillWithString(twoContent);
                    tiles[j + 2].FillWithString(zeroContent);
                    tiles[j + 1].FillWithString(oneContent);
                }
                else
                {
                    string zeroContent = tiles[j + 1].GetContent();
                    string oneContent = tiles[j + 2].GetContent();
                    string twoContent = tiles[j + 3].GetContent();

                    tiles[j + 2].FillWithString(zeroContent);
                    tiles[j + 1].FillWithString(twoContent);
                    tiles[j + 3].FillWithString(oneContent);
                }
            }
            else // shifting to the right 
            {
                if (j == 0)
                {
                    string zeroContent = tiles[j].GetContent();
                    string oneContent = tiles[j + 1].GetContent();
                    string twoContent = tiles[j + 2].GetContent();

                    tiles[j].FillWithString(oneContent);
                    tiles[j + 2].FillWithString(zeroContent);
                    tiles[j + 1].FillWithString(twoContent);
                }
                else
                {
                    string zeroContent = tiles[j +1].GetContent();
                    string oneContent = tiles[j+2].GetContent();
                    string twoContent = tiles[j + 3].GetContent();

                    tiles[j+2].FillWithString(twoContent);
                    tiles[j +1].FillWithString(oneContent);
                    tiles[j + 3].FillWithString(zeroContent);
                }
            }
        }
    }


    private void OnBoardRotated(bool isClockwise)
    {
        Vector3 eulerAngles = transform.eulerAngles;
       

        if (isClockwise)
        {
            float angle = eulerAngles.z += 90;
            transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, angle);
        }
        else
        {
            float angle = eulerAngles.z -=90;
            transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, angle);
        }
    }



    public void ClearColumn(int n) // 1 2 3 but really itll be 0 1 2
    {
        n -= 1;
        // column 1 are tiles 0, 3, and 6
        // column 2 are tiles 1, 4, and 7
        // column 3 are tiles 2, 5, and 8

        for (int i = n; i <= 6; i += 3)
        {

            tiles[i].ClearTile();
        
        }
    }

    public void ClearRow(int n) // 1 2 3 but really itll be 0 1 2
    {
        // rows 1 are tiles 0, 1, and 2
        // row 2 are tiles 3, 4, and 5
        // row 3 are tiles 6, 7, and 8

        for (int i = n; i <= 2; i++)
        {
            tiles[i+1].ClearTile();
            tiles[i + 2].ClearTile();
            tiles[i + 3].ClearTile();

        }

    }
}
