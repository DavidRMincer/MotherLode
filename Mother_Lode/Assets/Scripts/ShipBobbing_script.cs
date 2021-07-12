using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBobbing_script : MonoBehaviour
{
    public float bobIntensity,
        minBobFrequency,
        maxBobFrequency;
    public AnimationCurve bobAnimCurve;

    private Vector3 defaultRotation;

    private void Start()
    {
        defaultRotation = transform.rotation.eulerAngles;
        StartCoroutine(BobbingIEnum());
    }

    private IEnumerator BobbingIEnum()
    {
        do
        {
            Vector3 rotationVec = new Vector3(Random.Range(-bobIntensity, bobIntensity), Random.Range(-bobIntensity, bobIntensity), Random.Range(-bobIntensity, bobIntensity)) + defaultRotation;
            Quaternion newRotation = Quaternion.Euler(rotationVec),
                prevRotation = transform.rotation;
            float bobFrequency = Random.Range(minBobFrequency, maxBobFrequency),
                counter = 0f;

            while (counter < bobFrequency)
            {
                counter += Time.deltaTime;
                transform.rotation = Quaternion.Lerp(prevRotation, newRotation, bobAnimCurve.Evaluate(counter / bobFrequency));

                yield return new WaitForSeconds(Time.deltaTime);
            }
        } while (true);
    }
}
