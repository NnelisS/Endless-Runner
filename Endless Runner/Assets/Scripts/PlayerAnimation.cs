using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookDirection
{
    left = 0,
    right,
    jump,
}

public enum PlayerState
{
    idle = 0,
    walking,
}

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private LookDirection lookDirection;
    [SerializeField] private PlayerState playerState;

    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;

    public Animator anim;

    void Start()
    {
        playerState = PlayerState.idle;
        lookDirection = LookDirection.right;
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
            lookDirection = LookDirection.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lookDirection = LookDirection.right;
        }
        anim.SetFloat("LookDir", (float)lookDirection);
        anim.SetInteger("PlayerState", (int)playerState);
    }
    public void setAnimPlayerState(PlayerState state)
    {
        playerState = state;
        anim.SetInteger("PlayerState", (int)playerState);
    }

    public LookDirection GetDirection()
    {
        return lookDirection;
    }
}
