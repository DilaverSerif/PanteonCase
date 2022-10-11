using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ClickableMenuItem: MenuItem,IClickableItem
{
    public abstract void OnClick();
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }
}