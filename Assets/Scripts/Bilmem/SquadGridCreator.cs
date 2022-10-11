using System.Collections.Generic;
using UnityEngine;

public class SquadGridCreator : MonoBehaviour,IGridCreater
{
    public int GridX;
    public int GridY;
    private List<Cell> _cells = new List<Cell>();

    public void CreateGrid()
    {
        for (int x = 0; x < GridX; x++)
        {
            for (int y = 0; y < GridY; y++)
            {
                var cell = PoolManager.Instance.Spawn("Cell");
                cell.transform.SetParent(transform);
                cell.transform.localPosition = new Vector3(x, y, 0);
                cell.GetComponent<Cell>().Setup(new Vector2Int(x, y),BuildingType.None);
                cell.name = "Cell " + x + " " + y;
                
                _cells.Add(cell.GetComponent<Cell>());
            }
        }
        transform.position = new Vector3(-GridX / 2f, -GridY / 2f, 0);

        SetCameraByGridSize();
    }

    public void AllCellCheck()
    {
        foreach (var cell in _cells)
        {
            cell.SetColor(Color.white);
        }
    }
    
    private void SetCameraByGridSize()
    {
        Camera.main.orthographicSize = GridX / 2f;
    }
}
