using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SquadGridChecker : MonoBehaviour, IGridChecker
{
    public List<Cell> lastCell = new List<Cell>();

    public CellData CanBePlaced(ref Vector2[] Size)
    {
        var canBePlaced = true;
        var checks = CellCheck(Size);

        if (checks[0] == null)
            return new CellData();

        if (lastCell.Count > 0)
        {
            foreach (var t in checks)
            {
                for (int j = 0; j < lastCell.Count; j++)
                {
                    if (lastCell[j] == t)
                    {
                        lastCell.Remove(t);
                    }
                }
            }

            for (int i = 0; i < lastCell.Count; i++)
            {
                if (lastCell[i] == null) continue;
                lastCell[i].SetColor(Color.white);
            }

        }

        lastCell = checks.ToList();

        for (int i = 0; i < checks.Length; i++)
        {
            if (checks[i] == null)
            {
                canBePlaced = false;
                break;
            }

            if (checks[i].IsBusy)
            {
                canBePlaced = false;
                break;
            }
        }

        if (!canBePlaced)
        {
            foreach (var checkCell in checks)
            {
                if (checkCell)
                    checkCell.SetColor(Color.red);
            }
            return new CellData();
        }
        foreach (var checkCell in checks)
        {
            if (checkCell)
                checkCell.SetColor(Color.green);
        }
        return new CellData(checks, CalculateCenterPoint(ref checks));
    }

    public Vector2 CalculateCenterPoint(ref Cell[] cells)
    {
        if (cells[0] == null)
            return Vector2.zero;

        var centerPoint = Vector3.zero;

        for (var i = 0; i < cells.Length; i++)
        {
            if (!cells[i]) continue;
            centerPoint += cells[i].transform.position;
        }

        centerPoint /= cells.Length;
        return centerPoint;
    }

    public Cell[] CellCheck(Vector2[] pos)
    {
        var cells = new Cell[pos.Length];
        RaycastHit2D[] hit = new RaycastHit2D[pos.Length];

        for (int i = 0; i < pos.Length; i++)
        {
            hit[i] = Physics2D.Raycast(pos[i], Vector2.zero);
            if (hit[i].collider != null)
            {
                cells[i] = hit[i].collider.GetComponent<Cell>();
            }
        }

        return cells;
    }
}