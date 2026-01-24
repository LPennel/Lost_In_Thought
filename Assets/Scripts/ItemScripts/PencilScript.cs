//Author: Lawson Pennel
//Editors:
using UnityEngine;

public class PencilScript : MonoBehaviour
{
    private GameObject Crosshair;

    //Sets the player to be able to use the "Pencil Ability" when picking up the pencil object
    void OnTriggerStay2D(Collider2D other){
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null)
        {
            Destroy(gameObject);

            Crosshair = GameObject.Find("Crosshair");

            PencilAbillity pencil = Crosshair.GetComponent<PencilAbillity>();

            pencil.canUsePencil = true;
        }
    }
}
