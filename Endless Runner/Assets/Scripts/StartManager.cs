using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class StartManager : MonoBehaviour
{
    public Animator virtualCamera;

    public Animator startFade;

    public void StartGame()
    {
        virtualCamera.Play("StartScene");
        startFade.Play("Fade");
    }
}
