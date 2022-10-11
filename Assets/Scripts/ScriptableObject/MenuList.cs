using UnityEngine;

[CreateAssetMenu(fileName = "New Menu List", menuName = "Menu List")]
public class MenuList: ScriptableObject
{
    public Item[] Slot;
}