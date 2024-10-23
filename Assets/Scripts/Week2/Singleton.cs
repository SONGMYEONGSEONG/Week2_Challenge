using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // get instance of singleton
            if(instance == null) //해당 싱글톤 클래스가 존재하는지 확인(미할당인 경우)
            {
                instance = FindObjectOfType<T>();//하이어라키에 만들어져있는지 검색
                if(instance == null)//하이어라키에 없는경우 새로 생성(생성되지 않은 경우)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name + "Auto";
                    instance = obj.AddComponent<T>();
                }
            }
            //싱글톤 클래스 반환
            return instance;
        }
    }

    protected virtual void Awake()
    {
        // make it as dontdestroyobject
        if (instance != null)
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(this);

    }
}