using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequiredComponent(typeof(BoxCollider2D))]
public class Player : Mover
{
    private void FixedUpdate()
    {
        // Get input x / y
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }
}