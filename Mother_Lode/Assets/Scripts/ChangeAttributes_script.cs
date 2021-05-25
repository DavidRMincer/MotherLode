using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAttributes_script : Action_script
{
    public GameObject asset;
    public bool active;

    public override void Act()
    {
        //Debug.Log("Change Attributes");
        asset.SetActive(active);
    }
}
