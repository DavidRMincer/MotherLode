using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_script : MonoBehaviour
{
    public enum ActionTypeEnum
    {
        MOVE, WAIT
    }

    public ActionTypeEnum actionType;

    public virtual void Act()
    {
        
    }
}
