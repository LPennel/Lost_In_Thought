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
        if (Input.GetButtonDown("Attack"))
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

    //Spawns the platform
    public void drawPlatform()
    {
        if(crosshair != null)
        {
            Instantiate(drawnPlatform, pos, Quaternion.identity);
        }
    }
}
