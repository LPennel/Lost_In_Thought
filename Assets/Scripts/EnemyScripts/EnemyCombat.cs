//Author: Lawson Pennel
//Editors:
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
        //Countdown of invincibility timer every frame
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
        //Gives an enenmy short invincibility so it does not get spam attacked to death
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }

        //Ensures enemy health cant go below zero and cause problems
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
