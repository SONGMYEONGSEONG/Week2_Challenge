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

    public bool collectionChecks = true;
    private const int minSize = 50;
    private const int maxSize = 300;
    private Queue<GameObject> activePool; //Ȱ��ȭ�� ������Ʈ�� �����ϴ� �����̳� 

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



        Debug.Log($"������Ʈ �ʱ� ���� : {pool.CountAll} ��");
    }

    private GameObject CreateObject()
    {
        // [�䱸���� 1] Create Object

        //Instantiate();
        GameObject obj = Instantiate(prefab, container.transform);
        return obj;
    }

    public void GetObject(GameObject obj)
    {
        // [�䱸���� 2] Get Object
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
        // [�䱸���� 3] Release Object
        obj.gameObject.SetActive(false);
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

            Debug.Log($"Ȱ��ȭ�� ������Ʈ ���� : {pool.CountActive} ��");
        }
    }
}
