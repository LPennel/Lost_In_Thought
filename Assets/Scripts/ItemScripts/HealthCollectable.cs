using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{

    public int HealAmount = 1;

    void OnTriggerStay2D(Collider2D other){
        PlayerCombat controller = other.GetComponent<PlayerCombat>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(HealAmount);
            Destroy(gameObject);
        }
    }
}
