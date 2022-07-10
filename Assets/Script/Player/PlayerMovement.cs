using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NkE1.Utilities;

public class PlayerMovement : MonoBehaviour
{
    // 元件
    public Rigidbody2D rb2d;

    // 數值
    public float movementSpd = 0;

    // 變數
    Vector2 movement;

    private void Start()
    {
        movementSpd = PlayerAttribute.Instance.movementSpd;
    }

    void Update()
    {
        InputAxis();
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * movementSpd * Time.deltaTime);
    }

    private void InputAxis()
    {
        if (WaveControl.Instance.isPlayerDead) return;

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        Utils.RotateDirectionToMouse(transform);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "ShopTrigger")
        {
            InfoCanvas.Instance.fhint.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "ShopTrigger")
        {
            InfoCanvas.Instance.fhint.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (col.name == "ShopTrigger")
            {
                InGameUIEvents.Instance.uiSwitchEvent.Invoke("Shop", true);
            }
        }
    }
}
