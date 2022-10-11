using System.Threading.Tasks;
using UnityEngine;

public class PoolManager : Singlenton<PoolManager>
{
    public Pool[] Pools;
    
    public Task Initialize()
    {
        foreach (var pool in Pools)
        {
            pool.Initialize();
        }
        
        return Task.CompletedTask;
    }
    
    public GameObject Spawn(string Tag, Vector3 position = default, Quaternion rotation = default)
    {
        foreach (var pool in Pools)
        {
            if (pool.prefab.CompareTag(Tag))
            {
                return pool.Get(position, rotation);
            }
        }
        
        Debug.Log("Pool not found");
        return null;
    }
    
    public GameObject Spawn(ref GameObject obj, Vector3 position, Quaternion rotation = default)
    {
        foreach (var pool in Pools)
        {
            if (pool.prefab == obj)
            {
                return pool.Get(position, rotation);
            }
        }
        
        Debug.Log("Pool not found");
        return null;
    }
    
    public void Despawn(GameObject obj)
    {
        foreach (var pool in Pools)
        {
            if (pool.prefab != obj) 
                continue;
            pool.ReturnToPool(ref obj);
            break;
        }
    }
    
}
