using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : MonoBehaviour
{
    public enum ObjectPoolType
    {
        Q1 =0,
        Q2,
        Q3,
        Q4
    }

    [SerializeField] private ObjectPoolType type;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            switch (type)
            {
                case ObjectPoolType.Q1:
                    Week2_OjbectPool_Q1.Instance.ReleaseObject(this.gameObject);
                    break;
                case ObjectPoolType.Q2:
                    Week2_OjbectPool_Q2.Instance.ReleaseObject(this.gameObject);
                    break;
                case ObjectPoolType.Q3:
                    //Week2_OjbectPool_Q1.Instance.ReleaseObject(this.gameObject);
                    break;
                case ObjectPoolType.Q4:
                    //Week2_OjbectPool_Q1.Instance.ReleaseObject(this.gameObject);
                    break;
            }
           
        }
    }
}
