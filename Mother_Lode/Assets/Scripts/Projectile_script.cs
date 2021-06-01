using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_script : MonoBehaviour
{
    public float speed,
        life;

    private Rigidbody _rb;
    private float duration = 0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _rb.velocity = transform.forward * speed;
    }

    private void Update()
    {
        if (duration < life)
        {
            duration += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
