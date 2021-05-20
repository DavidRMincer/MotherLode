using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAction_script : Action_script
{
    public enum CompletionStateEnum
    {
        BEGINNING, ACTIVE, FINISHED
    }

    public float Duration;

    private CompletionStateEnum CompletionState = CompletionStateEnum.BEGINNING;

    private void Start()
    {
        actionType = ActionTypeEnum.WAIT;
    }

    public override void Act()
    {
        //base.Act();
        CompletionState = CompletionStateEnum.ACTIVE;
        StartCoroutine(WaitIEnumerator());
    }

    private IEnumerator WaitIEnumerator()
    {
        yield return new WaitForSeconds(Duration);
        CompletionState = CompletionStateEnum.FINISHED;
    }
}
