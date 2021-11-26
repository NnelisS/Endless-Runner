using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    private bool did_press;

    private Rigidbody rb;

    private float start_y_pos;

    public Animator gateOpen;
    public Animator gateOpenCutscene;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        start_y_pos = transform.position.y;

    }

    private void Update()
    {
        if (did_press)
        {
            rb.MovePosition((new Vector3(transform.position.x, start_y_pos - 0.20f, transform.position.z)));
            gateOpen.Play("GateOpen");
            gateOpenCutscene.Play("GateOpenCutscene");
            did_press = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            did_press = true;
            collision.gameObject.layer = 7;
        }
    }
}
