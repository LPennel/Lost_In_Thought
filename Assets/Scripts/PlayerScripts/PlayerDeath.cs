using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;
    PlayerCombat playerCombat;
    public int playerHealth;
    public Transform respawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCombat = player.GetComponent<PlayerCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCombat != null){
            playerHealth = playerCombat.health;
        }

        if(playerHealth == 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
