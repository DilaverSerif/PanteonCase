using UnityEngine;

public interface IRaySelector
{
    Cell GetCellByRaycast(Vector2 position);
    Cell GetCellByRaycast();
    GridItem GetItemByRaycast(Vector2 position);
    GridItem GetItemByRaycast();
}