using UnityEngine;

public class GiveDamage : MonoBehaviour
{

    public int damage;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player.isHurt = true;
        }    
    }
}
