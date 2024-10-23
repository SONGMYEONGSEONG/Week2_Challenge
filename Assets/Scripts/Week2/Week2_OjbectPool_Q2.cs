using System.Collections.Generic;
using UnityEngine;

//최소 50개의 오브젝트 수 보장, 부족할 경우 누적 300개까지 추가 생성, 300개가 넘어갈 경우 가장 오래전에 생성된 오브젝트를 반환 후 재사용
//List를 Queue처럼 사용해서 문제를 구현해라
public class Week2_OjbectPool_Q2 : Singleton<Week2_OjbectPool_Q2>
{
    [SerializeField] private GameObject prefab;

    private List<GameObject> pool;
    private Queue<GameObject> activePool; //활성화된 오브젝트를 저장하는 컨테이너 
    private const int minSize = 50;
    private const int maxSize = 300;

    private GameObject container;
    private int poolSize = 0;
    void Awake()
    {
        container = new GameObject(prefab.name + "_Container");
        pool = new List<GameObject>();
        activePool = new Queue<GameObject>();
        InitObjectPool();
    }

    private void InitObjectPool()
    {
      
        for (int i = 0; i < minSize; i++)
        {
            pool.Add(CreateObject());
        }
        Debug.Log($"오브젝트 갯수 {minSize} 개 추가!");
        poolSize += pool.Count;
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
        //가장 오래전에 생성된 오브젝트를 반환 후 재사용
        if (pool.Count <= 0)
        {
            Debug.Log("오브젝트 갯수 부족!");
            if (poolSize < maxSize)
            {
                Debug.Log($"생성된 Pool 갯수 : {poolSize} \n 오브젝트 풀을 {minSize} 개 추가 생성합니다.");
                InitObjectPool();
            }
            else
            {
                Debug.Log($"생성된 Pool 갯수 : {poolSize} \n {poolSize}를 초과하였으므로 반환후 생성합니다.");
                ReleaseObject(activePool.Peek());
            }
        }
        // [요구스펙 2] Get Object

        GameObject obj = pool[0];
        activePool.Enqueue(pool[0]);
        pool.RemoveAt(0);
        Debug.Log($"오브젝트 Pool! 현재 오브젝트 갯수 : {pool.Count}");
        obj.SetActive(true);
        obj.transform.position = transform.position;

        return obj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object\

        activePool.Dequeue();
        obj.SetActive(false);
        pool.Add(obj);
        Debug.Log($"오브젝트 Push! 현재 오브젝트 갯수 : {pool.Count}");
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