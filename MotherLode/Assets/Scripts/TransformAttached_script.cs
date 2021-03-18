using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAttached_script : MonoBehaviour
{
    public GameObject parentObj;

    void Update()
    {
        transform.position = parentObj.transform.position;
    }
}
