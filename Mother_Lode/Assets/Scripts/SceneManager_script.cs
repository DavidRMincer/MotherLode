using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_script : MonoBehaviour
{
    public List<Action_script> Timeline = new List<Action_script>();

    internal bool _finished = false;

    private int _index = 0;
    private bool _indexCompleted = false;

    private void Start()
    {
        StartCoroutine(AnimateEnum());
    }

    private IEnumerator AnimateEnum()
    {
        foreach (var item in Timeline)
        {
            item.Act();

            if (item.actionType == Action_script.ActionTypeEnum.WAIT)
            {
                do
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                } while (item.GetComponent<WaitAction_script>().CompletionState != WaitAction_script.CompletionStateEnum.FINISHED);
            }
        }

        yield return 0;
    }
}
