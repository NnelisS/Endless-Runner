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
    [SerializeField] private PlayerState playerState;

    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;

    public Animator anim;

    void Start()
    {
        playerState = PlayerState.idle;
    }

    void Update()
    {
        CheckMovement();
    }

    public void CheckMovement()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        if (xAxis == 0 && yAxis == 0)
        {
            playerState = PlayerState.idle;
        }
        else
        {
            playerState = PlayerState.walking;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerState = PlayerState.walking;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerState = PlayerState.walking;
        }

        if (Input.GetKeyDown(KeyCode.Space))
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
