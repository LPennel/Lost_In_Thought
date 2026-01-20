using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    PlayerController playerController;
    public GameObject AttackTrigger;
    private new Rigidbody2D rigidbody2D;
    private float playerMovementDirection = 1; //Can be any positive number as default
    private bool playerDirection = true; //True == Right     False == Left
    Vector2 attackSpawnPosition;
    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    private int currentHealth;
    private int damageAmount = -5;
    public int damage { get { return damageAmount; } }
    public float timeInvincible = 0.2f;
    bool isInvincible;
    float damageCooldown;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController != null)
        {
            rigidbody2D = playerController.body;
        }
        
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementDirection = playerController.direction;

        if (playerMovementDirection > 0)
        {
            playerDirection = true;
            attackSpawnPosition = new Vector2(rigidbody2D.transform.position.x + 0.75f, rigidbody2D.transform.position.y);
        }
        else if (playerMovementDirection < 0)
        {
            playerDirection = false;
            attackSpawnPosition = new Vector2(rigidbody2D.transform.position.x - 0.75f, rigidbody2D.transform.position.y);
        }
        else if (playerMovementDirection == 0 && playerDirection == true)
        {
            attackSpawnPosition = new Vector2(rigidbody2D.transform.position.x + 0.75f, rigidbody2D.transform.position.y);
        }
        else if (playerMovementDirection == 0 && playerDirection == false)
        {
            attackSpawnPosition = new Vector2(rigidbody2D.transform.position.x - 0.75f, rigidbody2D.transform.position.y);
        }
        
        //Attack
        if(Input.GetButtonDown("Attack") == true)
        {
            Attack();
        }

        //Player temporary invincibility after taking damage
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
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    public void Attack()
    {
        GameObject AttackTriggerRef = Instantiate(AttackTrigger, attackSpawnPosition, Quaternion.identity);
        PAttackTrigger attackTrigger = AttackTriggerRef.GetComponent<PAttackTrigger>();
        if(attackTrigger != null)
        {
            attackTrigger.setPlayerCombat(this);
        }
    }
}

