using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GridExtensions
{
    //a* algorithm
    public static List<Cell> FindPath(this Cell startCell,ref Cell targetCell)
    {
        Debug.Log("Calculating path");
        var start = new List<Cell> {startCell};
        var closedList = new List<Cell>();

        while (start.Any())
        {
            var current = start.OrderBy(c => c.F).First();
            
            closedList.Add(current);
            start.Remove(current);
            
            if (current == targetCell)
            {
                var currentCell = targetCell;
                var path = new List<Cell>();
                
                while (currentCell != startCell)
                {
                    path.Add(currentCell);
                    currentCell = currentCell.NextCell;
                }

                foreach (var thePath in path)
                {
                    thePath.SetColor(Color.green);
                    //Debug.Log(thePath.transform.name);
                }
                
                targetCell.SetColor(Color.red);
                startCell.SetColor(Color.blue);
                // Debug.Log(path.Count);
                return path;
            }
            
            foreach (var neighbour in current.Neighbours.Where(x=> !x.IsBusy))
            {
                var search = closedList.FirstOrDefault(c => c == neighbour);
                var CalculateG = current.g + current.GetDistance(neighbour);
                
                if(search == null || CalculateG < neighbour.g)
                {
                    neighbour.SetG(CalculateG);
                    neighbour.SetNextCell(ref current);

                    if (search == null)
                    {
                        neighbour.SetH(neighbour.GetDistance(targetCell));
                        start.Add(neighbour);
                    }
                }
            }
        }
        
        return null;
    }
}