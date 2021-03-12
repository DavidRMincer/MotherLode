using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_script : Character_script
{
    private void Update()
    {
        // Acceleration
        if (Input.GetButton("Fire1"))
        {
            Accelerate();
        }

        // Rotate
        Vector2 newRotate = Vector2.zero;

        if (Input.GetAxis("Horizontal") != 0)
        {
            newRotate.y = Input.GetAxis("Horizontal") * rotateSpeed;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            newRotate.x = -Input.GetAxis("Vertical") * rotateSpeed;
        }

        Rotate(newRotate.x, newRotate.y);

        // Roll
        Roll(Input.GetAxis("Roll"));
        //if (Input.GetAxis("Roll") != 0)
        //{
        //    Roll(Input.GetAxis("Roll"));
        //}
    }
}
