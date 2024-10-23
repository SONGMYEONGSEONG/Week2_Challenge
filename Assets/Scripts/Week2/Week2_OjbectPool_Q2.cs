using System.Collections.Generic;
using UnityEngine;

//�ּ� 50���� ������Ʈ �� ����, ������ ��� ���� 300������ �߰� ����, 300���� �Ѿ ��� ���� �������� ������ ������Ʈ�� ��ȯ �� ����
//List�� Queueó�� ����ؼ� ������ �����ض�
public class Week2_OjbectPool_Q2 : Singleton<Week2_OjbectPool_Q2>
{
    [SerializeField] private GameObject prefab;

    private List<GameObject> pool;
    private Queue<GameObject> activePool; //Ȱ��ȭ�� ������Ʈ�� �����ϴ� �����̳� 
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
        Debug.Log($"������Ʈ ���� {minSize} �� �߰�!");
        poolSize += pool.Count;
    }

    private GameObject CreateObject()
    {
        // [�䱸���� 1] Create Object
        GameObject obj = Instantiate(prefab, container.transform);
        obj.SetActive(false);
        return obj;
    }

    public GameObject GetObject()
    {
        //�����Ϸ��� ������Ʈ �ε����� pool�� �������� ū ��� -> ������Ʈ ���� ����
        //���� �������� ������ ������Ʈ�� ��ȯ �� ����
        if (pool.Count <= 0)
        {
            Debug.Log("������Ʈ ���� ����!");
            if (poolSize < maxSize)
            {
                Debug.Log($"������ Pool ���� : {poolSize} \n ������Ʈ Ǯ�� {minSize} �� �߰� �����մϴ�.");
                InitObjectPool();
            }
            else
            {
                Debug.Log($"������ Pool ���� : {poolSize} \n {poolSize}�� �ʰ��Ͽ����Ƿ� ��ȯ�� �����մϴ�.");
                ReleaseObject(activePool.Peek());
            }
        }
        // [�䱸���� 2] Get Object

        GameObject obj = pool[0];
        activePool.Enqueue(pool[0]);
        pool.RemoveAt(0);
        Debug.Log($"������Ʈ Pool! ���� ������Ʈ ���� : {pool.Count}");
        obj.SetActive(true);
        obj.transform.position = transform.position;

        return obj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // [�䱸���� 3] Release Object\

        activePool.Dequeue();
        obj.SetActive(false);
        pool.Add(obj);
        Debug.Log($"������Ʈ Push! ���� ������Ʈ ���� : {pool.Count}");
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