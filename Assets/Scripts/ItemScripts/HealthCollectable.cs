//Author: Lawson Pennel
//Editors: 
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    public int HealAmount = 1;

    //Heals player when they step into the trigger
    void OnTriggerStay2D(Collider2D other){
        PlayerCombat controller = other.GetComponent<PlayerCombat>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            //Runs player change health function
            controller.ChangeHealth(HealAmount);
            Destroy(gameObject);
        }
    }
}
