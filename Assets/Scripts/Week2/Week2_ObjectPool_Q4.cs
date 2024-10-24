using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Pool;


//최소 50개의 오브젝트 수 보장, 부족할 경우 누적 300개까지 추가 생성, 300개가 넘어갈 경우 가장 오래전에 생성된 오브젝트를 반환 후 재사용
public class Week2_OjbectPool_Q4 : Singleton<Week2_OjbectPool_Q4>
{
    [SerializeField] private GameObject prefab;
    public ObjectPool<GameObject> pool;
    private Queue<GameObject> activePool = new Queue<GameObject>();

    public bool collectionChecks = true;
    private const int minSize = 50;
    private const int maxSize = 300;

    private GameObject container;
    void Awake()
    {
        container = new GameObject(prefab.name + "_Container");
        pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject, DestroyObject, collectionChecks, minSize, maxSize);

        for (int i =0; i <minSize; i++)
        {
            pool.Get();
        }
        for (int i = 0; i < minSize; i++)
        {
            pool.Release(activePool.Peek());
        }

    }

    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object
        GameObject obj = Instantiate(prefab, container.transform);
        return obj;
    }

    public void GetObject(GameObject obj)
    {
        if(activePool.Count > maxSize)
        {
            pool.Release(activePool.Peek());
        }

        // [요구스펙 2] Get Object
        obj.gameObject.SetActive(true);
        activePool.Enqueue(obj);
        obj.transform.position = transform.position + new Vector3(Random.Range(-5.0f, 5.0f), 0,0);
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        obj.gameObject.SetActive(false);
        activePool.Dequeue();
    }

    public void DestroyObject(GameObject obj)
    {
        //오브젝트 파괴 함수
        Destroy(obj.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 10; i++)
            {
                pool.Get();
            }
        }
    }
}
