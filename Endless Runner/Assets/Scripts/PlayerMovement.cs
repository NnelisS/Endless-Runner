using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float move_speed;

    private Rigidbody rb;

    private float x_dir;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        x_dir = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        Debug.Log(x_dir);
        rb.AddForce(x_dir * move_speed,0,0);
        
    }
}
