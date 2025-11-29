using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upTrigger : MonoBehaviour
{
    private float upForce = 50f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D controller = collision.GetComponent<Rigidbody2D>();

        if (controller != null)
        {
            controller.velocity = new Vector2(controller.velocity.x, 0);
            controller.AddForce(new Vector2(0, upForce * 15));
        }
    }
}
