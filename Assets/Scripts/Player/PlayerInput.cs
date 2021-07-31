using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && player.isGround)
        {
            player.Jump();
            player.canDoubleJump = true;
        }
        else if (Input.GetButtonDown("Jump") && !player.isGround && player.canDoubleJump)
        {
            player.DoubleJump();
            player.canDoubleJump = false;
        }

    }
}
