using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableAndPutableItem : MenuItem, IDragrable,IPutable
{
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        var checkPos = new Vector2[ItemData.BorderSize.Length];
        for (int i = 0; i < checkPos.Length; i++)
        {
            var pos = Camera.main.ScreenToWorldPoint(transform.position);
            checkPos[i] =  new Vector2(pos.x,pos.y) + ItemData.BorderSize[i];
        }
        
        GridManager.Instance.GridChecker.CanBePlaced(ref checkPos);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetParent(canvas.transform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        var checkPos = new Vector2[ItemData.BorderSize.Length];
        for (var i = 0; i < checkPos.Length; i++)
        {
            var pos = Camera.main.ScreenToWorldPoint(transform.position);
            checkPos[i] =  new Vector2(pos.x,pos.y) + ItemData.BorderSize[i];
        }

        var canBePlaced = GridManager.Instance.GridChecker.CanBePlaced(ref checkPos);
        

        
        if (canBePlaced.Cells != null)
        {
            foreach (var t in canBePlaced.Cells)
            {
                t._BuildingType = ItemData.Type;
            }
            
            PoolManager.Instance.Spawn(ref ItemData.Prefab, canBePlaced.CenterPoint, Quaternion.identity);

        }
        
        transform.SetParent(parent);
        rectTransform.anchoredPosition = Vector2.zero;
        GridManager.OnChanged.Invoke();
    }
}
