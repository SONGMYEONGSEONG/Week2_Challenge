using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // get instance of singleton
            if(instance == null) //�ش� �̱��� Ŭ������ �����ϴ��� Ȯ��(���Ҵ��� ���)
            {
                instance = FindObjectOfType<T>();//���̾��Ű�� ��������ִ��� �˻�
                if(instance == null)//���̾��Ű�� ���°�� ���� ����(�������� ���� ���)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name + "Auto";
                    instance = obj.AddComponent<T>();
                }
            }
            //�̱��� Ŭ���� ��ȯ
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