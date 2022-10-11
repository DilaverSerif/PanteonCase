using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool //abstract T generıc yap
{
    public GameObject prefab;
    public string Tag => prefab.tag;
    public int PoolSize;
    private Stack<GameObject> PoolTheObject = new Stack<GameObject>();
    
    public void Initialize()
    {
        AddObjects(PoolSize);
    }
    
    public virtual GameObject Get(Vector3 pos = default,Quaternion rot = default,Transform parent = null)
    {
        if (PoolTheObject.Count == 0)
        {
            AddObjects(1);
        }
        
        var obj = PoolTheObject.Pop();
        
        obj.transform.parent = parent;

        if (parent)
            obj.transform.localPosition = pos;
        else         
            obj.transform.position = pos;
        
        obj.transform.rotation = rot;
        
        obj.SetActive(true);
        return obj;
    }
    
    public virtual void ReturnToPool(ref GameObject objectToReturn)
    {
        PoolTheObject.Push(objectToReturn);
    }
    
    protected virtual void AddObjects(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            var newObject = GameObject.Instantiate(prefab);
            newObject.SetActive(false);
            PoolTheObject.Push(newObject);
        }
    }
}
