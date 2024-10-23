using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObject : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Week2_OjbectPool_Q1.Instance.ReleaseObject(this.gameObject);
        }
    }
}
