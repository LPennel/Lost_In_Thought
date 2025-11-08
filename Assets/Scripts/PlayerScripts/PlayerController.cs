using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d;
    public Rigidbody2D body { get { return rigidbody2d; } }
    public bool canSprint = false;
    private bool isSprinting = false;
    public InputAction MoveAction;
    private float Move;
    public float direction {get { return Move; }}
    private bool jumpRequest;
    [SerializeField] public float MoveSpeed = 4.0f;
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private bool isGrounded;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();

        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Horizontal Movment
        Move = Input.GetAxis("Horizontal");

        if (Input.GetButton("Sprint") && canSprint == true && isGrounded == true)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }


        //Coyote Time
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }


        //Check if player jumps
        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            jumpRequest = true;
            coyoteTimeCounter = 0f;
        }
    }

    void FixedUpdate()
    {
        // Horizontal Movement
        if (isSprinting == false)
        {
            rigidbody2d.velocity = new Vector2(MoveSpeed * Move, rigidbody2d.velocity.y);
        }
        else if (isSprinting == true)
        {
            rigidbody2d.velocity = new Vector2((MoveSpeed + 1.5f) * Move, rigidbody2d.velocity.y); //37.5% faster movement
        }


        //Ground Check Debug Line
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

        //Is grounded check
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        // Jump Logic
        if (jumpRequest)
        {
            rigidbody2d.AddForce(new Vector2(rigidbody2d.velocity.x, jumpForce * 20));
            jumpRequest = false;
        }
    }
}
