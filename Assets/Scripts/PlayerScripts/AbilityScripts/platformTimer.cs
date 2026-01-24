//Author: Lawson Pennel
//Editors:
using UnityEngine;

public class platformTimer : MonoBehaviour
{
    public int seconds = 4;
    // Destoys platform after 4 seconds
    void Start()
    {
        Destroy(gameObject, seconds);
    }
}
