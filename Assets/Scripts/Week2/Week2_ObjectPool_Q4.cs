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

    public bool collectionChecks = true;
    private const int minSize = 50;
    private const int maxSize = 300;
    private Queue<GameObject> activePool; //활성화된 오브젝트를 저장하는 컨테이너 

    private GameObject container;
    void Awake()
    {
        container = new GameObject(prefab.name + "_Container");
        activePool = new Queue<GameObject>();

       pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject, DestroyObject, collectionChecks, minSize, maxSize);

        for (int i = 0; i < minSize; i++)
        {
            GameObject obj = CreateObject();
            activePool.Enqueue(obj);
            pool.Release(obj);
        }



        Debug.Log($"오브젝트 초기 생성 : {pool.CountAll} 개");
    }

    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object

        //Instantiate();
        GameObject obj = Instantiate(prefab, container.transform);
        return obj;
    }

    public void GetObject(GameObject obj)
    {
        // [요구스펙 2] Get Object
        if(pool.CountActive >= maxSize)
        {
            pool.Release(activePool.Peek());
        }

        obj.gameObject.SetActive(true);
        activePool.Enqueue(obj);
        obj.transform.position = transform.position;
    }

    public void ReleaseObject(GameObject obj)
    {
        activePool.Dequeue();
        // [요구스펙 3] Release Object
        obj.gameObject.SetActive(false);
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

            Debug.Log($"활성화된 오브젝트 갯수 : {pool.CountActive} 개");
        }
    }
}
