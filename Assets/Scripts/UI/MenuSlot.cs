public class MenuSlot : RecyclingListViewItem
{
    public MenuItem menuItem;
    
    public void SetData(Item ItemData)
    {
        menuItem.Init(ItemData);
    }
}
