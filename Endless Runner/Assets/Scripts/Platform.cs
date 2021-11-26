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
        if (boxCol.enabled == false)
        {
            player.transform.parent = null;
            box.transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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
