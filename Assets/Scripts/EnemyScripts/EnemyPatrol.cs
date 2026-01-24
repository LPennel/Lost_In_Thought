//Original Author Lawson Pennel
//Editors:

using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject Player;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Vector3 currentPoint;
    private Vector3 playerPoint;
    private Vector3 spawnPoint;
    public float speed;
    public float chaseDistance;
    public float sightDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = transform.position;
        currentPoint = pointB.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPoint = Player.transform.position;

        //Movement to point B
        if(currentPoint == pointB.transform.position)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime * 50, 0); // Point B must be to the right
        }
        //Movement to point A
        else if(currentPoint == pointA.transform.position)
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime * 50, 0); // Point A must be to the left
        }
        //Return to spawn point if enemy is to the right of spawn
        else if(currentPoint == spawnPoint && transform.position.x < spawnPoint.x)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime * 50, 0);
        }
        //Return to spawn point if enemy is the the left of spawn
        else if (currentPoint == spawnPoint && transform.position.x > spawnPoint.x)
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime * 50, 0);
        }

        //Change point to point A, after reaching point B
        if(Vector2.Distance(transform.position, currentPoint) <= 0.5f && currentPoint == pointB.transform.position)
        {
            currentPoint = pointA.transform.position;
        }

        //Change point to point B, after reaching point A
        if(Vector2.Distance(transform.position, currentPoint) <= 0.5f && currentPoint == pointA.transform.position)
        {
            currentPoint = pointB.transform.position;
        }

        //Change point to point B, after reaching spawn point
        if(Vector2.Distance(transform.position, currentPoint) <= 0.5f && currentPoint == spawnPoint)
        {
            currentPoint = pointB.transform.position;
        }

        //Starts the chase by setting goal point to the player
        if((Vector2.Distance(transform.position, playerPoint) < sightDistance) && 
        !(Vector2.Distance(transform.position, spawnPoint) > chaseDistance))
        {
            currentPoint = playerPoint;
        }

        //Sets the point to the spawn point after chasing the max distance
        if(Vector2.Distance(transform.position, spawnPoint) > chaseDistance)
        {
            currentPoint = spawnPoint;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}

//TODO For some reason changing a variable and then running the game a few times causes the enemy to dramatically speed up ad studder
//I have no idea why, only seen when changing chase distance, but may happen with other variables
//The speed increase has nothing to do with the acutal value of the variable itself