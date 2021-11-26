using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject player;
    public GameObject box;

    private BoxCollider boxCol;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        // if the box collider is off it's stops getting stuck
        if (boxCol.enabled == false)
        {
            player.transform.parent = null;
            box.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // player is stuck to the moving platform
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }        
        if (other.gameObject == box)
        {
            box.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // player is no longer stuck to the moving platform
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }        
        if (other.gameObject == box)
        {
            box.transform.parent = null;
        }
    }
}
