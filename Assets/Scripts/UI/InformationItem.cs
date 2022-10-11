using UnityEngine;
using UnityEngine.EventSystems;

public class InformationItem: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BuildingType _buildingType;


    public void OnPointerEnter(PointerEventData eventData)
    {
        InformationPanel.Instance.ShowText(_buildingType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InformationPanel.Instance.HideText();
    }
}