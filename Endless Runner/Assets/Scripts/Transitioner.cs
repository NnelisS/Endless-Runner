using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Transitioner : MonoBehaviour
{
    public Animator cineChange;
    public Animator scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TransitionStair"))
        {
            cineChange.Play("Stair");
            scene.Play("Scene");
        }

        if (other.gameObject.CompareTag("Transition"))
        {
            cineChange.Play("ChangeBody");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TransitionStair"))
        {
            cineChange.Play("Stair Back");
            scene.Play("SceneBack");
        }

        if (other.gameObject.CompareTag("Transition"))
        {
            cineChange.Play("ChangeBodyBack");
        }
    }
}
