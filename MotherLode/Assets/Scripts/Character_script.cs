using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_script : MonoBehaviour
{
    public float speed,
        rotateSpeed,
        rollSpeed;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    internal void Accelerate()
    {
        Vector3 addedForce = (transform.forward * speed) - _rb.velocity;

        _rb.AddForce(addedForce);
    }

    internal void Rotate(float x, float y)
    {
        _rb.transform.Rotate(new Vector3(x, y, 0f));
    }

    internal void Roll(float rollDir)
    {
        _rb.transform.Rotate(new Vector3(0, 0, rollDir * rollSpeed));
    }

    private void LateUpdate()
    {
        Debug.Log(_rb.velocity);
    }
}
