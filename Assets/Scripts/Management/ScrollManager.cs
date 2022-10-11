using System;
using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    public RecyclingListViewItem Clickable;
    public RecyclingListViewItem Dragable;

    
    public RecyclingListView scrollView;
    private ScrollRect scrollRect;
    public MenuList[] menuList;
    public int menuIndex;
    public static Action<int> ChangerMenu;

    private void OnEnable()
    {
        ChangerMenu += ChangeMenu;
    }
    
    private void OnDisable()
    {
        ChangerMenu -= ChangeMenu;
    }

    private void Start()
    {
        scrollRect = scrollView.GetComponent<ScrollRect>();
        
        scrollView.ItemCallback = UpdateItem;
        
        scrollView.RowCount = 999;
        
        scrollRect.horizontalScrollbarSpacing = scrollRect.horizontalScrollbarSpacing;
    }
    
    private void UpdateItem(RecyclingListViewItem i, int rowIndex)
    {
        var _newItem = (MenuSlot) i;
        
        _newItem.SetData(menuList[menuIndex].Slot[(rowIndex % 2)]);
    }
    
    private void ChangeMenu(int index)
    {
        scrollView.ChildPrefab = index == 0 ? Dragable : Clickable;

        scrollView.DeleteAll();
        menuIndex = index;
        
        scrollView.CheckChildItems();
        scrollView.Refresh();
    }
    
    
}