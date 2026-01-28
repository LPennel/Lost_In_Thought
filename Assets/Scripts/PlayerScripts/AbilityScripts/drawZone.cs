//Author: Lawson Pennel
//Editors:
using UnityEngine;

public class drawZone : MonoBehaviour
{
    public GameObject drawnPlatform;
    private PencilAbillity crosshair = null;
    private Vector2 pos;

    void Update()
    {
        //Check if the player clicks to draw a platform.
        if (Input.GetButtonDown("Attack") && pos != Vector2.zero)
        {
            drawPlatform();
        }
    }

    //Checks to see if the pencil crosshair is in the draw zone trigger
    void OnTriggerStay2D(Collider2D other)
    {
        crosshair = other.GetComponent<PencilAbillity>();
        
        pos = crosshair.pos;
    }

    //Changes value of crosshair to null so multiple draw zones dont draw platforms when not suppose to
    void OnTriggerExit2D(Collider2D collision)
    {
        crosshair = null;
    }

    //Spawns the platform
    public void drawPlatform()
    {
        if(crosshair != null)
        {
            Instantiate(drawnPlatform, pos, Quaternion.identity);
        }
    }
}
