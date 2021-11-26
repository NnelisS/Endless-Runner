using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxReset : MonoBehaviour
{
    public GameObject boxPosition;

    private void OnTriggerEnter(Collider other)
    {
        // if box falls off island it resets to it's first position

        if (other.gameObject.CompareTag("Death"))
        {
            transform.position = boxPosition.transform.position;
        }
    }
}
