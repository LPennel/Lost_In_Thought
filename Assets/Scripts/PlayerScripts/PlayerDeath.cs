//Author: Lawson Pennel
//Editors:
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
        //Get reference to player combat for health reference
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
            //Resets the scene when the player dies, sets all enemies back to default position
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
