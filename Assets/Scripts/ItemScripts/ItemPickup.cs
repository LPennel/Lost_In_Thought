using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public PlayerCombat combat;
    public PlayerController controller;

    void OnTriggerStay2D(Collider2D other){
        combat = other.GetComponent<PlayerCombat>();
        controller = other.GetComponent<PlayerController>();
    }
}
