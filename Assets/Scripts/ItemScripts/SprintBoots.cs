using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintBoots : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other){
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.canSprint = true;
            Destroy(gameObject);
        }
    }
}
