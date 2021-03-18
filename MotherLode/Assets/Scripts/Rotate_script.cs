using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rotate_script : MonoBehaviour
{
    public float rotationSpeed;
    public Vector3 rotationVec;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;

        rotationVec = rotationVec.normalized;
    }

    private void FixedUpdate()
    {
        _rb.angularVelocity = rotationVec * rotationSpeed;
    }
}
