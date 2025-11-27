using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilScript : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other){
        PlayerCombat controller = other.GetComponent<PlayerCombat>();

        controller.ChangeHealth(HealAmount);
         Destroy(gameObject);
    }
}
