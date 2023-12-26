using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int size;
    }
    public static PoolManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public List<Pool> pool;
    Dictionary<string, Queue<GameObject>> poolDictionary;
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool p in pool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i=0; i<p.size; i++)
            {
                GameObject obj = Instantiate(p.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(p.name, objectPool);
        }
    }
    public GameObject SpawnPool(string name, Vector2 position, Quaternion rotation)
    {
        GameObject objSpawn = poolDictionary[name].Dequeue();
        objSpawn.SetActive(true);
        objSpawn.transform.position = position;
        objSpawn.transform.rotation = rotation;
        poolDictionary[name].Enqueue(objSpawn);
        return objSpawn;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
