using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPressurePlate : MonoBehaviour
{
    private bool did_press;

    private Rigidbody rb;

    private float start_y_pos;

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
            did_press = false;
            SceneManager.LoadScene("EndCutscene");
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
