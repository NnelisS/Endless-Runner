using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LookDirection
{
    left = 0,
    right,
}

public enum PlayerState
{
    idle = 0,
    walking,
    jumping,
}

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private LookDirection lookDirection;
    [SerializeField] private PlayerState playerState;

    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
        anim.SetInteger("Playerstate", (int)playerState);
    }
    public void setAnimPlayerState(PlayerState state)
    {
        playerState = state;
        anim.SetInteger("Playerstate", (int)playerState);
    }

    public LookDirection GetDirection()
    {
        return lookDirection;
    }
}
