using UnityEngine;

public struct CellGetDistance
{
    public static float GetDistance(Cell cell1, Cell cell2)
    {
        var dist = new Vector2Int(Mathf.Abs((int)cell1.Position.x - (int)cell2.Position.x), Mathf.Abs((int)cell1.Position.y - (int)cell2.Position.y));

        var lowest = Mathf.Min(dist.x, dist.y);
        var highest = Mathf.Max(dist.x, dist.y);

        var horizontalMovesRequired = highest - lowest;

        return lowest * 14 + horizontalMovesRequired * 10 ;
    }
    
}