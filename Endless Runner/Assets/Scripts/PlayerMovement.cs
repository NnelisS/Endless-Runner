using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Attributes")]
    public float max_speed = 6.5f;
    [SerializeField, Tooltip("Smoothness of the movement.")]
    private float smoothness = 0.12f;
    [SerializeField, Tooltip("Jump Force.")]
    private float jump_force;
    [SerializeField, Tooltip("Jump modifier.")]
    private float fall_modifier = 5f;
    [SerializeField, Tooltip("Slide force.")]
    private float slide_force = 10f;
    [SerializeField, Tooltip("Rotate speed.")]
    private float rotate_speed = 5f;
    [SerializeField, Tooltip("Jump Cooldown.")]
    private float jump_cooldown = 2f;
    [SerializeField, Tooltip("Slide Cooldown.")]
    private float slide_cooldown = 3f;

    [Header("Settings")]
    [SerializeField, Tooltip("Ground Layer Mask.")]
    private LayerMask ground_layer_mask;
    [SerializeField, Tooltip("Height from hips to ground.")]
    private float hip_height;

    private Rigidbody rb;
    private PlayerAnimation player_animation_script;

    public bool is_jumping = false;
    public bool is_sliding = false;
    public bool can_jump = true;
    public bool can_slide = true;
    public bool can_rotate = true;
    public bool facing_right = false;
    public bool can_move = true;
    public float x_dir;

    private Vector3 current_vector;
    private Vector3 smooth_vector;
    private Vector3 vel;

    private bool on_ground = false;

    private float cooldown_timer;



    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player_animation_script = gameObject.GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        //Raycast to check if player is on the ground.
        RaycastHit hit;

        on_ground = Physics.SphereCast(transform.position, 0.25f, Vector2.down, out hit, hip_height, ground_layer_mask);
        if (on_ground)
        {
            is_jumping = false;
        }
        x_dir = Input.GetAxis("Horizontal");
        smooth_vector = Vector3.SmoothDamp(smooth_vector, new Vector3(x_dir, 0, 0), ref vel, smoothness);
        current_vector = new Vector3(smooth_vector.x, 0, 0);

        cooldown_timer += Time.deltaTime;


        if (((x_dir > 0 && facing_right) || (x_dir < 0 && !facing_right)) && can_rotate)
        {
            facing_right = !facing_right;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && can_slide && cooldown_timer >= slide_cooldown)
        {
            cooldown_timer = 0;
            is_sliding = true;
            can_jump = false;
            can_rotate = false;
            can_move = false;
            StartCoroutine(Slide());
        }

        //When spacebar is pressed and the player is on the ground call the jump function.
        if (Input.GetButtonDown("Jump") && on_ground && can_jump && cooldown_timer >= jump_cooldown)
        {
            cooldown_timer = 0;
            Jump();
        }

        if (can_rotate)
        {
            Rotate();
        }

    }


    IEnumerator Slide()
    {
        float current_direction = facing_right ? -1 : 1;
        rb.AddForce(Vector2.right * current_direction * slide_force, ForceMode.Impulse);
        yield return new WaitForSeconds(0.7f);
        can_jump = true;
        can_rotate = true;
        can_move = true;
        yield return new WaitForSeconds(0.6f);
        is_sliding = false;

    }


    void Jump()
    {
        is_jumping = true;
        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(Vector2.up * jump_force, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (can_move)
        {
            rb.MovePosition(transform.position + (current_vector * max_speed * Time.deltaTime));
        }

        rb.velocity += Vector3.up * Physics.gravity.y * fall_modifier * Time.deltaTime;
    }

    void Rotate()
    {

        Quaternion torotation = Quaternion.Euler(0, facing_right ? 270 : 90, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, torotation, rotate_speed * Time.deltaTime);

    }

    public void ChangeSpeed(bool ispulling)
    {
        max_speed = ispulling ? 2f : 6.5f;
    }

}
