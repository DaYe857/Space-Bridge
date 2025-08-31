using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager Instance;
    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();
    [SerializeField] private List<PoolObject> poolObjects;
    
    [System.Serializable]
    private class PoolObject
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    private void Awake()
    {
        if(Instance == null){Instance = this;}
        else{Destroy(gameObject);}
        if(poolObjects == null){return;}

        foreach (var obj in poolObjects)
        {
            CreatePool(obj.tag,obj.prefab,obj.size);
        }
    }

    public void CreatePool(string tag, GameObject prefab, int size) 
    {
        Queue<GameObject> queue = new Queue<GameObject>();
        for (int i = 0; i < size; i++) 
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
        poolDictionary.Add(tag, queue);
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) 
    {
        GameObject obj = poolDictionary[tag].Dequeue();
        obj.transform.SetPositionAndRotation(position, rotation);
        obj.SetActive(true);
        return obj;
    }

    public void ReturnToPool(string tag, GameObject obj) 
    {
        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }

    public int GetPoolSize(string tag)
    {
        foreach (var obj in poolObjects)
        {
            if (obj.tag == tag)
            {
                return obj.size;
            }
        }
        return 0;
    }
}
