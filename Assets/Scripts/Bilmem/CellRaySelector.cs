using JetBrains.Annotations;
using UnityEngine;

public class CellRaySelector : MonoBehaviour, IRaySelector
{
    public LayerMask CellMask;
    
    public Cell GetCellByRaycast(Vector2 position)
    {
        var hit = Physics2D.Raycast(position, Vector2.zero, Mathf.Infinity, CellMask);

        if (!hit) return null;
        
        return hit.collider.TryGetComponent(out Cell cell) ? cell : null;
    }

    public Cell GetCellByRaycast()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        var hit = Physics2D.Raycast(worldPosition, Vector2.zero, Mathf.Infinity, CellMask);

        if (!hit) return null;
        
        return hit.collider.TryGetComponent(out Cell cell) ? cell : null;
    }

    public GridItem GetItemByRaycast(Vector2 position)
    {
        var hit = Physics2D.Raycast(position, Vector2.zero);
        
        if (!hit) return null;
        
        return hit.collider.TryGetComponent(out GridItem item) ? item : null;
    }

    [CanBeNull]
    public GridItem GetItemByRaycast()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (!hit) return null;
        
        return hit.collider.TryGetComponent(out GridItem item) ? item : null;
    }
}