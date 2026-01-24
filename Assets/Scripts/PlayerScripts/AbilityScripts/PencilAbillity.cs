//Author: Lawson Pennel
//Editors:
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
        //Checks if the player can use pencil
        if(Input.GetButton("UsePencil") && canUsePencil == true){
            //Make cursor invisable
            Cursor.visible = false;
            
            if(ren != null)
            {
                ren.enabled = true;
            }

            //Have the pencil cursor track to the mouse position
            Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseCursorPos;
            pos = mouseCursorPos;

            //Time slow during pencil use
            Time.timeScale = 0.75f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;

        }
        else {
            //Reset time scale and make mouse viasable again
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
