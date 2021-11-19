using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle = 0,
    walking,
    jumping,
}

public class PlayerAnimation : MonoBehaviour
{
    public PlayerState playerState;

    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;

    public Animator anim;

    private PlayerMovement playerScript;

    void Start()
    {
        playerState = PlayerState.idle;

        playerScript = gameObject.GetComponent<PlayerMovement>();

    }

    void Update()
    {
        CheckMovement();
    }

    public void CheckMovement()
    {

        if (playerScript.x_dir != 0 && playerScript.is_jumping == false)
        {
            playerState = PlayerState.walking;
        }
        else if (playerScript.is_jumping == false)
        {
            playerState = PlayerState.idle;
        }
        else
        {
            playerState = PlayerState.jumping;
        }

        anim.SetInteger("PlayerState", (int)playerState);
    }
    public void setAnimPlayerState(PlayerState state)
    {
        playerState = state;
        anim.SetInteger("PlayerState", (int)playerState);
    }
}
