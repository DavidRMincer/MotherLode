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
    internal CompletionStateEnum CompletionState = CompletionStateEnum.BEGINNING;

    private float _remainingTime;

    private void Start()
    {
        actionType = ActionTypeEnum.WAIT;
        _remainingTime = Duration;
    }

    public override void Act()
    {
        //base.Act();
        CompletionState = CompletionStateEnum.ACTIVE;
        StartCoroutine(WaitIEnumerator());
    }

    private IEnumerator WaitIEnumerator()
    {
        do
        {
            _remainingTime -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        } while (_remainingTime > 0f);
        
        CompletionState = CompletionStateEnum.FINISHED;
    }

    public float GetRemainingTime()
    {
        return _remainingTime;
    }
}
