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

    public override void Act()
    {
        //base.Act();
        StartCoroutine(MoveAssetIEnum());
    }

    /// <summary>
    /// Lerp asset to new transform
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveAssetIEnum()
    {
        if (duration == 0)
        {
            asset.transform.position = newTransform.position;
            asset.transform.rotation = newTransform.rotation;

            yield return 0;
        }
        else
        {
            float counter = 0;
            Vector3 prevPos = asset.transform.position;
            Quaternion prevRot = asset.transform.rotation;

            do
            {
                counter = (counter + Time.deltaTime > duration) ? duration : counter + Time.deltaTime;
                float percentage = curve.Evaluate(counter / duration);

                asset.transform.position = Vector3.Lerp(prevPos, newTransform.position, percentage);
                asset.transform.rotation = Quaternion.Lerp(prevRot, newTransform.rotation, percentage);

                yield return new WaitForSeconds(Time.deltaTime);
            } while (counter < duration);

        }
    }
}
