using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Pool;


//�ּ� 50���� ������Ʈ �� ����, ������ ��� ���� 300������ �߰� ����, 300���� �Ѿ ��� ���� �������� ������ ������Ʈ�� ��ȯ �� ����
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
        // [�䱸���� 1] Create Object
        GameObject obj = Instantiate(prefab, container.transform);
        return obj;
    }

    public void GetObject(GameObject obj)
    {
        if(activePool.Count > maxSize)
        {
            pool.Release(activePool.Peek());
        }

        // [�䱸���� 2] Get Object
        obj.gameObject.SetActive(true);
        activePool.Enqueue(obj);
        obj.transform.position = transform.position + new Vector3(Random.Range(-5.0f, 5.0f), 0,0);
    }

    public void ReleaseObject(GameObject obj)
    {
        // [�䱸���� 3] Release Object
        obj.gameObject.SetActive(false);
        activePool.Dequeue();
    }

    public void DestroyObject(GameObject obj)
    {
        //������Ʈ �ı� �Լ�
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
