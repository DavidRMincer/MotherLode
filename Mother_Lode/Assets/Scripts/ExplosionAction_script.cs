using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAction_script : Action_script
{
    public ShipExplosion_script explosion_Script;

    public override void Act()
    {
        explosion_Script.Explode();
    }
}
