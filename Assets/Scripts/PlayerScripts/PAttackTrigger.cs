using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttackTrigger : MonoBehaviour
{
    public int damageAmount;
    PlayerCombat playerCombat;

    public void setPlayerCombat(PlayerCombat pc)
    {
        playerCombat = pc;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        if(playerCombat != null)
        {
            damageAmount = playerCombat.damage;
        }

        Destroy(gameObject, 0.25f);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyCombat enemy = other.GetComponent<EnemyCombat>();
        if (enemy != null)
        {
            enemy.ChangeHealth(damageAmount);
            Destroy(gameObject);
        }
    }
}
