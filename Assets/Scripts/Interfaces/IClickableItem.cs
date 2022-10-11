using UnityEngine.EventSystems;

interface IClickableItem:IPointerClickHandler
{
    void OnClick();
}