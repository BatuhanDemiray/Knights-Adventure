using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    internal Rigidbody2D body2D;
    public float knockBackForce = 15000;

    BoxCollider2D box2D;
    CircleCollider2D cir2D;

    [Tooltip("Player'ýn yürüme hýzýný belirler.")]
    [Range(0, 20)]
    public float playerSpeed = 15;

    [Tooltip("Player zýpladýðýnda ne kadar yükseðe çýkacacaðýný belirler.")]
    [Range(500, 1500)]
    public float jumpPower = 1000;

    [Tooltip("Player 2. kez zýpladýðýnda ne kadar yükseðe çýkacacaðýný belirler.")]
    [Range(500, 1000)]
    public float doubleJumpPower = 600;

    internal bool canDoubleJump;
    internal bool canDamage;

    // Player Scale
    bool facingRight = true;

    [Tooltip("Player'ýn yerde olup olmadýðýnýn bilgisini tutar.")]
    public bool isGround = true;

    Transform groundCheck;
    const float GroundCheckRadius = .1f;

    [Tooltip("Ground layer'ýný belirler.")]
    public LayerMask groundLayer;

    // Anim Controller
    Animator playerAnimController;

    // Player Health
    internal int maxPlayerHealth = 100;
    public int currentPlayerHealth;
    internal bool isHurt;
    internal bool addHealth;
    internal bool earnCoin;
    GiveDamage giveDamage;
    GiveHealth giveHealth;

    public int currentCoin = 0;
    AddCoin addCoin;

    internal bool isDead;
    public float deadForce = 5;

    TextMeshProUGUI coinText;

    AudioSource audioSource;
    AudioClip audioJump;
    AudioClip audioHurt;
    AudioClip audioCoin;
    AudioClip audioHealth;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        body2D.gravityScale = 5;
        body2D.freezeRotation = true;
        body2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        box2D = GetComponent<BoxCollider2D>();
        cir2D = GetComponent<CircleCollider2D>();

        groundCheck = transform.Find("GroundCheck");

        playerAnimController = GetComponent<Animator>();

        currentPlayerHealth = maxPlayerHealth;
        giveDamage = FindObjectOfType<GiveDamage>();
        giveHealth = FindObjectOfType<GiveHealth>();
        addCoin = FindObjectOfType<AddCoin>();

        coinText = GameObject.Find("HUD/CoinCanvas/CoinCounterText").GetComponent<TextMeshProUGUI>();

        //Audio Paths
        audioSource = GetComponent<AudioSource>();
        audioJump = Resources.Load("Sounds/Jump") as AudioClip;
        audioHurt = Resources.Load("Sounds/Hurt") as AudioClip;
        audioCoin = Resources.Load("Sounds/Coin") as AudioClip;
        audioHealth = Resources.Load("Sounds/Health") as AudioClip;
    }

    void Update()
    {
        UpdateAnimations();
        ReduceHealth();
        BoostHealth();
        AddCoin();

        isDead = currentPlayerHealth <= 0;

        if (currentPlayerHealth > maxPlayerHealth)
            currentPlayerHealth = maxPlayerHealth;

        if (transform.position.y <= -6)
            isDead = true;

        if (isDead)
            KillPlayer();
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, GroundCheckRadius, groundLayer);

        float horizontal = Input.GetAxis("Horizontal");

        body2D.velocity = new Vector2(horizontal * playerSpeed, body2D.velocity.y);

        Flip(horizontal);

        if (isGround)
            canDamage = false;
    }

    public void Jump()
    {
        body2D.AddForce(new Vector2(0, jumpPower));
        audioSource.PlayOneShot(audioJump);
    }

    public void DoubleJump()
    {
        body2D.AddForce(new Vector2(0, doubleJumpPower));
        canDamage = true;
        audioSource.PlayOneShot(audioJump);
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector2 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    void UpdateAnimations()
    {
        playerAnimController.SetFloat("VelocityX", Mathf.Abs(body2D.velocity.x));
        playerAnimController.SetFloat("VelocityY", body2D.velocity.y);
        playerAnimController.SetBool("isGround", isGround);
        playerAnimController.SetBool("isDead", isDead);
        if (isHurt && !isDead)
            playerAnimController.SetTrigger("isHurt");
    }

    void ReduceHealth()
    {
        if (isHurt)
        {
            currentPlayerHealth -= giveDamage.damage;
            isHurt = false;
            audioSource.PlayOneShot(audioHurt);

            if (facingRight && !isGround)
                body2D.AddForce(new Vector2(-knockBackForce, 1000), ForceMode2D.Force);
            else if (!facingRight && !isGround)
                body2D.AddForce(new Vector2(knockBackForce, 1000), ForceMode2D.Force);

            if (facingRight && isGround)
                body2D.AddForce(new Vector2(-knockBackForce, 0), ForceMode2D.Force);
            else if (!facingRight && isGround)
                body2D.AddForce(new Vector2(knockBackForce, 0), ForceMode2D.Force);
        }
    }

    void BoostHealth()
    {
        if (addHealth)
        {
            currentPlayerHealth += giveHealth.health;
            addHealth = false;
            audioSource.PlayOneShot(audioHealth);
        }
    }

    void AddCoin()
    {
        if (earnCoin)
        {
            currentCoin += addCoin.coin;
            coinText.text = currentCoin.ToString();
            earnCoin = false;
            audioSource.PlayOneShot(audioCoin);
        }
    }

    void KillPlayer()
    {
        isHurt = false;
        body2D.AddForce(new Vector2(0, deadForce), ForceMode2D.Impulse);
        body2D.drag = Time.deltaTime * 20;
        deadForce -= Time.deltaTime * 25;
        body2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        box2D.enabled = false;
        cir2D.enabled = false;
        audioSource.PlayOneShot(audioHurt);
    }
}