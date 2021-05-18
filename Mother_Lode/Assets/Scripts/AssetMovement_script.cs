using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetMovement_script : Action_script
{
    public GameObject asset;
    public Transform newTransform;
    public float duration;
    public AnimationCurve curve;

    private void Start()
    {
        actionType = ActionTypeEnum.MOVE;
    }

    public virtual void Act()
    {
        base.Act();
        StartCoroutine(MoveAssetIEnum());
    }

    private IEnumerator MoveAssetIEnum()
    {
        float counter = 0;
        Transform prevTransform = asset.transform;

        do
        {
            counter = (counter + Time.deltaTime > duration) ? duration : counter + Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);

            asset.transform.position = Vector3.Lerp(prevTransform.position, newTransform.position, curve.Evaluate(counter / duration));
            asset.transform.rotation = Quaternion.Lerp(prevTransform.rotation, newTransform.rotation, curve.Evaluate(counter / duration));

            Debug.Log("Counter: " + curve.Evaluate(counter / duration));
        } while (counter < duration);
    }
}
