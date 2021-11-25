using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class StartManager : MonoBehaviour
{
    public Animator virtualCamera;
    public Animator playerCharacter;
    public Animator startFade;
    public Animator toolTips;
    public Animator toolTipJump;

    public GameManager gameManager;

    public float timer = 5.0f;
    public bool timerOn = false;

    public PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement.enabled = false;
    }

    private void Update()
    {
        if (timerOn)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                playerMovement.enabled = true;
            }
        }
    }

    public void StartGame()
    {
        timerOn = true;
        playerCharacter.Play("Standing Up");
        virtualCamera.Play("StartScene");
        startFade.Play("Fade");
        toolTips.Play("Movement_Tooltip");
        toolTipJump.Play("Jump_Tooltip");
        gameManager.playing = true;
    }
}
