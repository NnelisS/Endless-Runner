using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField, Tooltip("Player's max speed.")] 
    private float max_speed;
    [SerializeField, Tooltip("Smoothness of the movement.")]
    private float smoothness;

    private Rigidbody rb;

    private Vector3 current_vector;
    private Vector3 smooth_vector;
    private Vector3 vel;
   

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x_dir = Input.GetAxis("Horizontal");

        smooth_vector = Vector3.SmoothDamp(smooth_vector, new Vector3(x_dir, 0, 0), ref vel, smoothness);
        current_vector = new Vector3(smooth_vector.x, 0, 0);
    }
    void FixedUpdate()
    {

        rb.MovePosition(transform.position + (current_vector * max_speed * Time.fixedDeltaTime));
    }
}
