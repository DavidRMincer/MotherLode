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

    /// <summary>
    /// Lerp asset to new transform
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveAssetIEnum()
    {
        float counter = 0;
        Transform prevTransform = asset.transform;
        Vector3 distance = newTransform.position - asset.transform.position;
        
        do
        {
            counter = (counter + Time.deltaTime > duration) ? duration : counter + Time.deltaTime;
            float time = curve.Evaluate(counter / duration);

            Vector3 newPos = prevTransform.position + (distance * time);

            Debug.Log(counter / duration);

            asset.transform.position = newPos;

            //asset.transform.position = Vector3.Lerp(prevTransform.position, newTransform.position, curve.Evaluate(counter / duration));
            //asset.transform.rotation = Quaternion.Lerp(prevTransform.rotation, newTransform.rotation, curve.Evaluate(counter / duration));

            yield return new WaitForSeconds(Time.deltaTime);

        } while (counter < duration);
    }
}
