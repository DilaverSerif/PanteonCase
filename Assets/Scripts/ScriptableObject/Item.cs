using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item:ScriptableObject
{
    public BuildingType Type;
    public Sprite Icon;
    public GameObject Prefab;
    public Vector2[] BorderSize;
}