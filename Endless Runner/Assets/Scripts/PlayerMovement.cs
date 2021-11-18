using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField, Tooltip("Player's max speed.")] 
    private float max_speed = 6.5f;
    [SerializeField, Tooltip("Smoothness of the movement.")]
    private float smoothness = 0.12f;
    [SerializeField, Tooltip("Jump Force.")]
    private float jump_force;
    [SerializeField, Tooltip("Jump modifier.")]
    private float fall_modifier = 5f;
    [SerializeField, Tooltip("Rotate speed.")]
    private float rotate_speed = 5f;

    [Header("Settings")]
    [SerializeField, Tooltip("Ground Layer Mask.")]
    private LayerMask ground_layer_mask;
    [SerializeField, Tooltip("Height from hips to ground.")]
    private float hip_height;

    private Rigidbody rb;

    private Vector3 current_vector;
    private Vector3 smooth_vector;
    private float x_dir;
    private Vector3 vel;


    private bool facing_right = true;
    private bool on_ground = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Raycast to check if player is on the ground.
        RaycastHit hit;

        on_ground = Physics.SphereCast(transform.position, 0.25f, Vector2.down, out hit, hip_height, ground_layer_mask);

         x_dir = Input.GetAxis("Horizontal");
        smooth_vector = Vector3.SmoothDamp(smooth_vector, new Vector3(x_dir, 0, 0), ref vel, smoothness);
        current_vector = new Vector3(smooth_vector.x, 0, 0);

        //When spacebar is pressed and the player is on the ground call the jump function.
        if (Input.GetButtonDown("Jump") && on_ground)
        {
            Jump();
        }

        Rotate();
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(Vector2.up * jump_force, ForceMode.Impulse);
    }

    void FixedUpdate()
    { 

        if((x_dir > 0 && facing_right) || (x_dir < 0 && !facing_right))
        {
            facing_right = !facing_right;
        }

        rb.MovePosition(transform.position + (current_vector * max_speed * Time.fixedDeltaTime));
        rb.velocity += Vector3.up * Physics.gravity.y * fall_modifier * Time.fixedDeltaTime;
    }

    void Rotate()
    {

        Quaternion torotation = Quaternion.Euler(0, facing_right ? 90 : 270, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, torotation, rotate_speed * Time.deltaTime);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * hip_height);
    }

}
