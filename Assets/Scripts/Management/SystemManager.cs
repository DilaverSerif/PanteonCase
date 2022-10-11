using UnityEngine;

public class SystemManager : MonoBehaviour
{
    private PoolManager poolManager;
    private GridManager gridManager;

    private void Awake()
    {
        poolManager = GetComponentInChildren<PoolManager>();
        gridManager = GetComponentInChildren<GridManager>();
        
        Initialize();
    }
    
    private async void Initialize()
    {
        await poolManager.Initialize();
        await gridManager.Initialize();
        
        Debug.Log("Game Started");
    }
}
