//Author: Lawson Pennel
//Editors:
using UnityEngine;

public class SprintBoots : MonoBehaviour
{
    //Allows the player to sprint when they pick up the boots
    void OnTriggerStay2D(Collider2D other){
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.canSprint = true;
            Destroy(gameObject);
        }
    }
}
