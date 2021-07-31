using UnityEngine;

public class AddCoin : MonoBehaviour
{
    public int coin;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player.earnCoin = true;
            Destroy(gameObject);
        }
    }
}
