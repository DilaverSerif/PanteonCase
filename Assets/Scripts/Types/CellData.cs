using UnityEngine;

public struct CellData
{
    public Cell[] Cells;
    public Vector2 CenterPoint;
        
    public CellData(Cell[] cells, Vector2 centerPoint)
    {
        Cells = cells;
        CenterPoint = centerPoint;
    }
}