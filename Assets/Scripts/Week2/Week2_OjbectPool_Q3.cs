using System.Collections.Generic;
using UnityEngine;

//오브젝트를 미리 생성하지 않고 부족할 경우 누적 100개까지 추가 생성, 100개가 넘어갈 경우 임시로 생성 후 반환 시 파괴
//List를 Queue처럼 사용해서 문제를 구현해라
public class Week2_OjbectPool_Q3 : Singleton<Week2_OjbectPool_Q3>
{
    [SerializeField] private GameObject prefab;

    private List<GameObject> pool;
    private const int minSize = 50;
    private const int maxSize = 100;

    private GameObject container;

    void Awake()
    {
        container = new GameObject(prefab.name + "_Container");
        pool = new List<GameObject>();
        //InitObjectPool();
    }

    private void InitObjectPool()
    {
        for (int i = 0; i < minSize; i++)
        {
            pool.Add(CreateObject());
        }
        Debug.Log($"오브젝트 갯수 {minSize} 개 추가!");
    }

    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object
        GameObject obj = Instantiate(prefab, container.transform);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetObject()
    {
        //접근하려는 오브젝트 인덱스가 pool의 갯수보다 큰 경우 -> 오브젝트 갯수 부족
        //오브젝트가 부족할때마다 50개씩 추가
        if (pool.Count <= 0)
        {
            Debug.Log("오브젝트 갯수 부족!");
            InitObjectPool();
        }
        // [요구스펙 2] Get Object

        GameObject obj = pool[0];
        pool.RemoveAt(0);
        Debug.Log($"오브젝트 Pool! 현재 오브젝트 갯수 : {pool.Count}");
        obj.SetActive(true);
        obj.transform.position = transform.position;

        return obj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        if (pool.Count >= maxSize)
        {
            DestroyObject(obj);
            return;
        }
        obj.SetActive(false);
        pool.Add(obj);
        Debug.Log($"오브젝트 Push! 현재 오브젝트 갯수 : {pool.Count}");
    }

    private void DestroyObject(GameObject obj)
    {
        Destroy(obj.gameObject);
        Debug.Log($"오브젝트 파괴! 현재 오브젝트 갯수 : {pool.Count}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 10; i++)
            {
                GetObject();
            }
        }
    }
}