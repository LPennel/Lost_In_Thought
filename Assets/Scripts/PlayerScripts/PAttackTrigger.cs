//Author Lawson Pennel
//Editors: 
using UnityEngine;

public class PAttackTrigger : MonoBehaviour
{
    public int damageAmount;
    PlayerCombat playerCombat;

    //Getting reference to player comabt, so damagenumbers can be accessed
    public void setPlayerCombat(PlayerCombat pc)
    {
        playerCombat = pc;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Reference player damage amount
        if(playerCombat != null)
        {
            damageAmount = playerCombat.damage;
        }
        //Destroy spawned hitbox
        Destroy(gameObject, 0.25f);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //Get reference to enemy combat so health can be retived and changed
        EnemyCombat enemy = other.GetComponent<EnemyCombat>();
        if (enemy != null)
        {
            enemy.ChangeHealth(damageAmount);
            Destroy(gameObject);
        }
    }
}
