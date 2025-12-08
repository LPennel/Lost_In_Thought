using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PencilAbillity : MonoBehaviour
{
    public bool canUsePencil = false;
    public Vector2 pos;
    private Renderer ren;

    void Start()
    {
        ren = GetComponent<Renderer>();

        if(ren != null)
        {
            ren.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("UsePencil") && canUsePencil == true){
            Cursor.visible = false;
            
            if(ren != null)
            {
                ren.enabled = true;
            }

            Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseCursorPos;
            pos = mouseCursorPos;

            Time.timeScale = 0.75f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

        }
        else {
            Cursor.visible = true;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;

            if(ren != null)
            {
                ren.enabled = false;
            }
        }
    }
}
