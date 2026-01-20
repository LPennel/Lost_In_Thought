using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int maxHealth = 10;
    public int health { get { return currentHealth; } }
    private int currentHealth;
    public float timeInvincible = 0.2f;
    bool isInvincible;
    float damageCooldown;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }
    
    public void ChangeHealth(int amount)
    {
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
