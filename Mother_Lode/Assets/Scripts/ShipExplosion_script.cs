using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipExplosion_script : MonoBehaviour
{
    public GameObject shipMesh;
    public ParticleSystem particles;

    public void Explode()
    {
        StartCoroutine(ExplosionIEnum());
    }

    private IEnumerator ExplosionIEnum()
    {
        shipMesh.SetActive(false);
        particles.Play();

        yield return new WaitForSeconds(3);

        shipMesh.SetActive(true);
        gameObject.SetActive(false);
    }
}
