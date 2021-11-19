using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{

    [SerializeField]
    private float distance = 1f;
    [SerializeField]
    private Vector3 offset;

    public LayerMask box_mask;

    private PlayerMovement movement_script;

    private Rigidbody rb;

    private GameObject box;

    private bool is_pulling;

    // Start is called before the first frame update
    void Start()
    {
        movement_script = gameObject.GetComponent<PlayerMovement>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        bool is_hit = Physics.Raycast(transform.position, Vector3.right * movement_script.x_dir, out hit, distance, box_mask);
        Debug.Log(is_hit);
        if (is_pulling)
        {
            if (box != null) 
            {
                box.transform.position = new Vector3(transform.position.x + (movement_script.facing_right ? -offset.x : offset.x), 0, 0);
            }

        }

        if(is_hit && Input.GetKeyDown(KeyCode.LeftShift))
        {

            box = hit.collider.gameObject;
            
            SwitchPushPullState();
        }else if(is_pulling && Input.GetKeyUp(KeyCode.LeftShift))
        {
            SwitchPushPullState();
            box = null;
        }
    }

    void SwitchPushPullState()
    {
        movement_script.can_rotate = !movement_script.can_rotate;
        movement_script.can_jump = !movement_script.can_jump;

        is_pulling = !is_pulling;
        movement_script.ChangeSpeed(is_pulling);

    }


}
