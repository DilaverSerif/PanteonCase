using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour, IMovedable
{
    public float speed = 5f;
    private Cell lastCell;

    public IEnumerator Move(Cell TargetCell)
    {
        if (!lastCell)
            lastCell = GridManager.Instance.RaySelector.GetCellByRaycast(transform.position);

        var calculatedPath = lastCell.FindPath(ref TargetCell);
        calculatedPath.Reverse();

        var path = new Queue<Cell>(calculatedPath);
        var nextCell = path.Peek();
        lastCell._BuildingType = BuildingType.None;

        while (path.Count > 0)
        {
            nextCell._BuildingType = BuildingType.None;
            nextCell = path.Dequeue();

            var direction = nextCell.transform.position - transform.position;
            var distance = direction.magnitude;
            var moveDistance = speed * Time.deltaTime;

            Debug.Log("GO TO " + nextCell.transform.name);

            while (moveDistance < distance)
            {
                transform.position += direction * moveDistance;
                direction = nextCell.transform.position - transform.position;
                distance = direction.magnitude;
                yield return new WaitForEndOfFrame();
            }

            lastCell = nextCell;
            nextCell._BuildingType = BuildingType.Soldier;
            transform.position = nextCell.transform.position;
            yield return new WaitForEndOfFrame();
        }
    }
}
