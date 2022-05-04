using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NkE1.Utilities;

public class Player_Movement : MonoBehaviour
{
    public float movementSpd = 5;
    public Rigidbody2D rb2d;

    Vector2 movement;
    
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        Utils.RotateDirectionToMouse(transform);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * movementSpd * Time.deltaTime);
    }
}