//Author: Lawson Pennel
//Editors:
using UnityEngine;

public class upTrigger : MonoBehaviour
{
    //Used specifically in level 1 to boost the player upward
    public float upForce = 50f;
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
