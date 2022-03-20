using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab, actualBoard;
    [SerializeField] int gridSize = 3;
    public void buildBoard()
    {
        GameHandler.Instance.board.tiles = new List<Tile>();
        for (int i = 0; i < (gridSize * gridSize); i++)
        {
            GameObject t = Instantiate(tilePrefab, actualBoard.transform);
            GameHandler.Instance.board.tiles.Add(t.GetComponent<Tile>());
        }
        GameHandler.Instance.board.isBoardBuilt = true;
    }

    // for connectfour specifically we need a 4 by four
    public void AddTiles(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject t = Instantiate(tilePrefab, actualBoard.transform);
            GameHandler.Instance.board.tiles.Add(t.GetComponent<Tile>());
        }
    }

    public void ResetBoard()
    {
        foreach (Tile t in GameHandler.Instance.board.tiles)
        {
            t.ClearTile();
        }
    }
}
