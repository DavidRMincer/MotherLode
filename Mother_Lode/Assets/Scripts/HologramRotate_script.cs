using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramRotate_script : MonoBehaviour
{
    public Transform pivotPoint;
    public Vector3 rotateVector;
    public float rotationSpeed;

    private void Update()
    {
        Vector3 rotation = (rotateVector.x * transform.right)
            + (rotateVector.y * transform.up)
            + (rotateVector.z * transform.forward);

        //transform.localRotation = transform.localRotation * Quaternion.Euler(rotation * rotationSpeed * Time.deltaTime);
        //Debug.Log("Up: " + transform.up + ", Rotation: " + rotation);
        //transform.Rotate(rotation * rotationSpeed * Time.deltaTime);

        transform.RotateAround(pivotPoint.position, rotation, rotationSpeed * Time.deltaTime);
    }
}
