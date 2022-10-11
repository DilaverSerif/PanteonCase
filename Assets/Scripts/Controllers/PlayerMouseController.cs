using System;
using UnityEngine;

public class PlayerMouseController :MonoBehaviour, IPlayerController
{
    private GridItemMoveable moveableItem;
    private IRaySelector _raySelector;

    private void Awake()
    {
        _raySelector = GetComponent<IRaySelector>();
    }

    public void SelectObject()
    {
        var hit = _raySelector.GetItemByRaycast();
        if(!hit) return;
        
        
        switch (hit)
        {
            case Soldier soldier:
                    moveableItem = soldier;
                    ScrollManager.ChangerMenu.Invoke(0);
                    break;
                case Barracks barracks:
                    Factory.Instance.SetSelectedGridItemProducer(barracks);
                    break;
                case PowerPlant powerPlant:
                    ScrollManager.ChangerMenu.Invoke(0);
                    break;
                case Cell cell:
                    ScrollManager.ChangerMenu.Invoke(0);
                    break;
            }
        
    }

    public void MoveSoldier()
    {
        if (!moveableItem)
             return;
        
        var cell = _raySelector.GetCellByRaycast(
            Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (!cell) return;
        moveableItem.Move(ref cell);
    }
}