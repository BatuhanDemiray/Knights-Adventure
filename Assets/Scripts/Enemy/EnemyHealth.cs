using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxEnemyHealth = 100;
    public float currentEnemyHealth;
    internal bool gotDamage;
    public float playerDamageToEnemy;
    public GameObject deathParticle;
    SpriteRenderer spriteRenderer;
    CircleCollider2D cir2D;
    Rigidbody2D body2D;

    Player player;

    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;
        player = FindObjectOfType<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        cir2D = GetComponent<CircleCollider2D>();
        body2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (currentEnemyHealth <= 0)
        {
            spriteRenderer.enabled = false;
            cir2D.enabled = false;
            body2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            deathParticle.SetActive(true);
            Destroy(gameObject, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerItem" && player.canDamage)
        {
            currentEnemyHealth -= playerDamageToEnemy;
        }
    }
}
