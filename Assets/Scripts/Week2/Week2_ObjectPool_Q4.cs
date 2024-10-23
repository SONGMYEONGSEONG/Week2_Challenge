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

    private GameObject container;
    void Awake()
    {
        container = new GameObject(prefab.name + "_Container");

        /*
        createFunc: 오브젝트 생성 함수 (Func)
        actionOnGet: 풀에서 오브젝트를 가져오는 함수 (Action)
        actionOnRelease: 오브젝트를 비활성화할 때 호출하는 함수 (Action)
        actionOnDestroy: 오브젝트 파괴 함수 (Action)
        collectionCheck: 중복 반환 체크 (bool)
        defaultCapacity: 처음에 미리 생성하는 오브젝트 갯수 (int)
        maxSize: 저장할 오브젝트의 최대 갯수 (int)
         */
        pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject, DestroyObject, collectionChecks, minSize, maxSize);
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
        obj.gameObject.SetActive(true);
    }

    public void ReleaseObject(GameObject obj)
    {
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
        }
    }
}
