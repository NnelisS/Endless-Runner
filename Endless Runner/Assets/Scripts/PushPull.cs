using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{

    [SerializeField]
    private float distance = 1f;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private LayerMask box_mask;

    private PlayerMovement movement_script;
    private Rigidbody rb;

    private GameObject box;
    private bool is_pulling;
    private bool can_push = false;

    public bool can_start_push = true;

    void Start()
    {
        movement_script = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit hit;

        bool is_hit = Physics.Raycast(transform.position, Vector3.right * (movement_script.facing_right ? -1 : 1), out hit, distance, box_mask);

        if (can_start_push)
        {
            if (is_pulling)
            {
                if (box != null)
                {
                    if (can_push == true)
                    {
                        movement_script.can_move = true;
                        box.transform.position = new Vector3(transform.position.x + (movement_script.facing_right ? -offset.x : offset.x), transform.position.y - offset.y, -238); ;
                    }
                    else
                    {
                        movement_script.can_move = false;
                        rb.MovePosition((new Vector3(box.transform.position.x - (movement_script.facing_right ? -offset.x : offset.x), transform.position.y, transform.position.z)));
                        if (transform.position.x == (box.transform.position.x - (movement_script.facing_right ? -offset.x : offset.x)))
                        {
                            can_push = true;
                        }
                    }

                }

            }

        }

        if(is_hit && Input.GetKeyDown(KeyCode.LeftShift))
        {
            box = hit.collider.gameObject;
            is_pulling = !is_pulling;
            SwitchPushPullState();
        }
        else if(is_pulling && Input.GetKeyUp(KeyCode.LeftShift))
        {
            is_pulling = !is_pulling;
            movement_script.can_move = true;
            can_push = false;
            SwitchPushPullState();
            box = null;
        }
    }

    void SwitchPushPullState()
    {
        movement_script.can_rotate = !movement_script.can_rotate;
        movement_script.can_jump = !movement_script.can_jump;
        movement_script.can_slide = !movement_script.can_slide;
        movement_script.ChangeSpeed(is_pulling);
    }


}
