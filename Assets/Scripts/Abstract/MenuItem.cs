using UnityEngine;
using UnityEngine.UI;

public abstract class MenuItem : RecyclingListViewItem
{
    public Item ItemData;
    private Image image;
    protected RectTransform rectTransform;
    protected Canvas canvas;
    protected Transform parent;
    
    protected virtual void Awake()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        parent = transform.parent;
    }
    
    public void Init(Item itemData)
    {
        ItemData = itemData;
        image.sprite = itemData.Icon;
    }
}