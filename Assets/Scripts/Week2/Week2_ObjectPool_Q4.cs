//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Pool;


////�ּ� 50���� ������Ʈ �� ����, ������ ��� ���� 300������ �߰� ����, 300���� �Ѿ ��� ���� �������� ������ ������Ʈ�� ��ȯ �� ����
//public class Week2_ObjectPool : MonoBehaviour
//{
//    private ObjectPool<GameObject> pool;

//    private List<GameObject> poolList;
//    private const int minSize = 50;
//    private const int maxSize = 300;


//    void Awake()
//    {
//        /*
//        createFunc: ������Ʈ ���� �Լ� (Func)
//        actionOnGet: Ǯ���� ������Ʈ�� �������� �Լ� (Action)
//        actionOnRelease: ������Ʈ�� ��Ȱ��ȭ�� �� ȣ���ϴ� �Լ� (Action)
//        actionOnDestroy: ������Ʈ �ı� �Լ� (Action)
//        collectionCheck: �ߺ� ��ȯ üũ (bool)
//        defaultCapacity: ó���� �̸� �����ϴ� ������Ʈ ���� (int)
//        maxSize: ������ ������Ʈ�� �ִ� ���� (int)
//         */
//        pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject, DestroyObject, false, minSize, maxSize);

//        poolList = new List<GameObject>();
//        for (int i = 0; i < minSize; i++)
//        {
//            poolList.Add(CreateObject());
//        }
//    }

//    private GameObject CreateObject()
//    {
//        // [�䱸���� 1] Create Object

//        Instantiate()
//        GameObject obj = new GameObject();
//        return obj;
//    }

//    public void GetObject(GameObject obj)
//    {
//        // [�䱸���� 2] Get Object

//    }

//    public void ReleaseObject(GameObject obj)
//    {
//        // [�䱸���� 3] Release Object

//    }

//    public void DestroyObject(GameObject obj)
//    {
//        //������Ʈ �ı� �Լ�

//    }


//}
