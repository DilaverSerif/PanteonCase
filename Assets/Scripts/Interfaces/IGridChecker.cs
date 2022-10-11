using UnityEngine;

public interface IGridChecker
{
    CellData CanBePlaced(ref Vector2[] Size);
    Vector2 CalculateCenterPoint(ref Cell[] cells);
}