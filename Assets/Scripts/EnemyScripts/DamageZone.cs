//Author: Lawson Pennel
//Editors:
using UnityEngine;


public class DamageZone : MonoBehaviour
{
    public int damageAmount = -1;
    
    //Changing player health when standing in the trigger
   void OnTriggerStay2D(Collider2D other)
   {
       PlayerCombat controller = other.GetComponent<PlayerCombat>();

       if (controller != null)
       {
           controller.ChangeHealth(damageAmount);
       }
   }
}
