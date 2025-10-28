using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d;

    public int maxHealth = 5;
    public int health { get { return currentHealth; }}
    private int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown;

    public InputAction MoveAction;
    private float Move;
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

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            jumpRequest = true;
            coyoteTimeCounter = 0f;
            Debug.Log(coyoteTimeCounter);
        }

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }

    void FixedUpdate()
    {
        // Horizontal Movement
        rigidbody2d.velocity = new Vector2(MoveSpeed * Move, rigidbody2d.velocity.y);

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

    public void ChangeHealth (int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
