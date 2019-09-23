using UnityEngine;

public class GridManagar : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;
    private Cell[] cells = new Cell[9];  

    public void BuildGrid(GameManager gameManager)
    {
        for(int i =0; i < 9; i++)
        {
            GameObject newCell = Instantiate(cellPrefab, transform);
            cells[i] = newCell.GetComponent<Cell>();
            cells[i].gameManager = gameManager;
            cells[i].CellIter = i;
        }
    }

    public Cell GetCell(int i)
    {
        return cells[i];
    }

    public Cell[] GetCells()
    {
        return cells;
    }
}
