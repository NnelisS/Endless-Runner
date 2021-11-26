using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle = 0,
    walking,
    jumping,
    pushing,
    slide,
    push_idle,
    pushing_backwards
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
        //change animation state on movement state
        if (playerScript.x_dir != 0 && playerScript.is_jumping == false && playerScript.can_rotate == true && playerScript.is_sliding == false)
        {

            playerState = PlayerState.walking;
        }
        else if (playerScript.is_jumping)
        {
            playerState = PlayerState.jumping;
        }
        else if (playerScript.is_sliding)
        {
            playerState = PlayerState.slide;
        }
        else if (playerScript.can_rotate == false)
        {
            if (playerScript.x_dir == 0)
            {
                playerState = PlayerState.push_idle;
            }
            else if (playerScript.facing_right)
            {
                if (playerScript.x_dir < 0)
                {
                    playerState = PlayerState.pushing;
                }
                else
                {
                    playerState = PlayerState.pushing_backwards;
                }
            }
            else
            {
                if (playerScript.x_dir < 0)
                {
                    playerState = PlayerState.pushing_backwards;
                }
                else
                {
                    playerState = PlayerState.pushing;
                }
            }
        }   


        //change the animation to push animation when it's using the push box
        else if (playerScript.can_rotate == false && playerScript.x_dir >= 0)
        {
            if (playerScript.facing_right)
            {
                playerState = PlayerState.pushing;
            }

        }
        else if (playerScript.can_rotate == false & playerScript.x_dir <= 0)
        {
            playerState = PlayerState.pushing_backwards;
        }
        else
        {
            playerState = PlayerState.idle;
        }




        anim.SetInteger("PlayerState", (int)playerState);
    }

    public void setAnimPlayerState(PlayerState state)
    {
        playerState = state;
        anim.SetInteger("PlayerState", (int)playerState);
    }
}
