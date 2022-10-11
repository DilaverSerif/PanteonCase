using System;
using TMPro;
using UnityEngine;

public class InformationPanel : Singlenton<InformationPanel>
{
    private const string SoldierInfo = "Soldier Can Move";
    private const string BarrackInfo = "Barrack Can Produce Soldier (Need Power Plant)";
    private const string PowerPlantInfo = "Power Plant Can Produce Power (Need Barrack)";
    
    private Transform _textPanel;
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _textPanel = transform.GetChild(transform.childCount-1);
        _text = _textPanel.GetComponentInChildren<TextMeshProUGUI>();
        
        HideText();
    }
    
    public void ShowText(BuildingType buildingType)
    {
        switch (buildingType)
        {
            case BuildingType.Soldier:
                _text.text = SoldierInfo;
                break;
            case BuildingType.Barrack:
                _text.text = BarrackInfo;
                break;
            case BuildingType.PowerPlant:
                _text.text = PowerPlantInfo;
                break;
        }
        
        _textPanel.gameObject.SetActive(true);
    }
    
    public void HideText()
    {
        _textPanel.gameObject.SetActive(false);
    }
}