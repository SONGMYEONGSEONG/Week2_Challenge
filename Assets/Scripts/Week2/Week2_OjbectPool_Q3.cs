using System.Collections.Generic;
using UnityEngine;

//������Ʈ�� �̸� �������� �ʰ� ������ ��� ���� 100������ �߰� ����, 100���� �Ѿ ��� �ӽ÷� ���� �� ��ȯ �� �ı�
//List�� Queueó�� ����ؼ� ������ �����ض�
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
        Debug.Log($"������Ʈ ���� {minSize} �� �߰�!");
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
        //������Ʈ�� �����Ҷ����� 50���� �߰�
        if (pool.Count <= 0)
        {
            Debug.Log("������Ʈ ���� ����!");
            InitObjectPool();
        }
        // [�䱸���� 2] Get Object

        GameObject obj = pool[0];
        pool.RemoveAt(0);
        Debug.Log($"������Ʈ Pool! ���� ������Ʈ ���� : {pool.Count}");
        obj.SetActive(true);
        obj.transform.position = transform.position;

        return obj;
    }

    public void ReleaseObject(GameObject obj)
    {
        // [�䱸���� 3] Release Object
        if (pool.Count >= maxSize)
        {
            DestroyObject(obj);
            return;
        }
        obj.SetActive(false);
        pool.Add(obj);
        Debug.Log($"������Ʈ Push! ���� ������Ʈ ���� : {pool.Count}");
    }

    private void DestroyObject(GameObject obj)
    {
        Destroy(obj.gameObject);
        Debug.Log($"������Ʈ �ı�! ���� ������Ʈ ���� : {pool.Count}");
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