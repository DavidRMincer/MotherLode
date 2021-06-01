using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLasers_script : Action_script
{
    public GameObject projectile;
    public Transform leftGun,
        rightGun;

    public override void Act()
    {
        GameObject leftProjectile = Instantiate(projectile, leftGun.transform.position, leftGun.transform.rotation);
        GameObject rightProjectile = Instantiate(projectile, rightGun.transform.position, rightGun.transform.rotation);
    }
}
