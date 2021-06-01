using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstLaserFire_script : Action_script
{
    public FireLasers_script gun;
    public int shots;
    public float duration;

    private float _spacing;

    private void Start()
    {
        _spacing = duration / shots;
    }

    public override void Act()
    {
        StartCoroutine(ShootingIEnum());
    }

    private IEnumerator ShootingIEnum()
    {
        for (int index = 0; index < shots; index++)
        {
            yield return new WaitForSeconds(_spacing);
            gun.Act();
        }
    }
}
