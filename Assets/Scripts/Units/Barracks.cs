using UnityEngine;

public class Barracks : GridItemProducer
{
    public override void Produce()
    {
        if (!CheckRequirements())
        {
            Debug.Log("Not enough resources");
            return;
        }
        
        var checkCell = 
            Physics2D.BoxCastAll(transform.position, Vector2.one * 5, 0, Vector2.zero);
        
        foreach (var cellHit in checkCell)
        {
            if (!cellHit.transform.TryGetComponent(out Cell cell))
            {
                continue;
            }

            if (cell.IsBusy) continue;

            PoolManager.Instance.Spawn("Soldier", cell.transform.position, Quaternion.identity);
            
            cell._BuildingType = BuildingType.Soldier;
            
            return;
        }
        
        Debug.Log("Cant find free cell");
    }
    
    protected override bool CheckRequirements()
    {
        var checkCell = Physics2D.BoxCastAll(transform.position, Vector2.one * 6, 0, Vector2.zero);
        
        foreach (var cellHit in checkCell)
        {
            if (!cellHit.collider.TryGetComponent(out Cell cell)) continue;
            
            if (cell._BuildingType == BuildingType.PowerPlant)
                return true;
        }

        return false;
    }
}




