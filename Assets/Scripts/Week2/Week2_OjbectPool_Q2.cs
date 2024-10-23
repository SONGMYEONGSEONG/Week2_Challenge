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
//        // [¿ä±¸½ºÆå 1] Create Object
//    }

//    public GameObject GetObject()
//    {
//        // [¿ä±¸½ºÆå 2] Get Object
//    }

//    public void ReleaseObject(GameObject obj)
//    {
//        // [¿ä±¸½ºÆå 3] Release Object
//    }
//}