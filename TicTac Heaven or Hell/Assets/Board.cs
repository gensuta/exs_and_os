using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    public List<Cell> cells;
    [SerializeField] GameObject cellPrefab;
    [SerializeField] int gridSize = 3;


    public void buildBoard()
    {
        cells = new List<Cell>();
        for (int i = 0; i < (gridSize*gridSize); i++)
        {
            GameObject c = Instantiate(cellPrefab, transform);
            cells.Add(c.GetComponent<Cell>());
        }
    }

    public void ResetBoard()
    {
        foreach(Cell c in cells)
        {
            c._text.text = "";
            c._button.interactable = true;
        }
    }


   public bool CheckForWinner()
    {
        
        for(int i = 0; i <= 6;i+=3)
        {

            //horizontal
            if (!CheckValues(i, i + 1))
                continue;

            if (!CheckValues(i, i + 2))
                continue;

            return true;
        }

        for (int i = 0; i <= 2; i ++)
        {

            //vertical
            if (!CheckValues(i, i + 3))
                continue;

            if (!CheckValues(i, i + 6))
                continue;

            return true;
        }

        // Left Diagonal
        if (CheckValues(0, 4) && CheckValues(0, 8))
            return true;


        // Right Diagonal
        if (CheckValues(2, 6) && CheckValues(2, 4))
            return true;

        return false;
    }

    public int GetWinningSpot() // get the spot your opponent is abt to win with
    {
        for (int i = 0; i <= 6; i += 3)
        {
            //horizontal
            if (CheckValues(i, i + 1))
                return i +2;

            if (CheckValues(i, i + 2))
                return i+1;

            if (CheckValues(i+1, i + 2))
                return i;
        }

        for (int i = 0; i <= 2; i++)
        {

            //vertical
            if (CheckValues(i, i + 3))
                return i+6;

            if (CheckValues(i, i + 6))
                return i+3;

            if (CheckValues(i+3, i + 6))
                return i;
        }

        // Left Diagonal
        if (CheckValues(0, 4))
            return 8;
        if (CheckValues(0, 8))
            return 4;
        if (CheckValues(4, 8))
            return 0;


        // Right Diagonal
        if (CheckValues(2, 4))
            return 6;
        if (CheckValues(2, 6))
            return 4;
        if (CheckValues(4, 6))
            return 2;

        return -1;

        // 0 1 2
        // 3 4 5
        // 6 7 8
    }

    public int getEmptyCell()
    {
        List<int> emptyCells = new List<int>();

        for(int i = 0; i < cells.Count;i++)
        {
            if(cells[i]._button.interactable)
            {
                emptyCells.Add(i);
            }
        }
        int randNum = Random.Range(0, emptyCells.Count);

        return emptyCells[randNum];

    }

    public bool CheckForTie()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i]._button.interactable)
            {
                return false;
            }
        }

        return true;
    }

    bool CheckValues(int i, int n)
    {
        string a = cells[i]._text.text;
        string b = cells[n]._text.text;

        if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return false;

        if (a == b) return true;
        else return false;
    }
}
