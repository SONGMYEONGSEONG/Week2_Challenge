//using System.Collections.Generic;
//using UnityEngine;

//public class ObjectPool : MonoBehaviour
//{
//    private List<GameObject> pool;
//    private const int minSize = 50;
//    private const int maxSize = 300;

//    void Awake()
//    {
//        pool = new List<GameObject>();
//        for (int i = 0; i < minSize; i++)
//        {
//            pool.Add(CreateObject());
//        }
//    }

//    private GameObject CreateObject()
//    {
//        // [�䱸���� 1] Create Object
//    }

//    public GameObject GetObject()
//    {
//        // [�䱸���� 2] Get Object
//    }

//    public void ReleaseObject(GameObject obj)
//    {
//        // [�䱸���� 3] Release Object
//    }
//}