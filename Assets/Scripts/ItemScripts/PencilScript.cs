using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilScript : MonoBehaviour
{
    private GameObject Crosshair;
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
