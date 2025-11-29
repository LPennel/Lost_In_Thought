using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawZone : MonoBehaviour
{
    public GameObject drawnPlatform;
    private PencilAbillity crosshair = null;
    private Vector2 pos;

    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            drawPlatform();
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        crosshair = other.GetComponent<PencilAbillity>();
        
        pos = crosshair.pos;
    }

    public void drawPlatform()
    {
        if(crosshair != null)
        {
            Instantiate(drawnPlatform, pos, Quaternion.identity);
        }
    }
}
