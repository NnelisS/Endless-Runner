using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrail : MonoBehaviour
{
    #region Wind Variables
    // Speed of the wind.
    [SerializeField]
    private float wind_speed;

    [SerializeField]
    private float wind_time;
    #endregion  
    // Timer to calculate lifetime.
    private float death_timer;

    private bool moving = true;

   private void Start()
    {
        death_timer = 0f;
    }

    void Update()
    {
        // Bullet is moved every frame
        if (moving)
        {
            transform.Translate(Vector3.left * Time.deltaTime * wind_speed);
        }

        // Calculates if lifetime of the bullet is reached and if true return to the pool.
        death_timer += Time.deltaTime;
        if (death_timer >= wind_time)
        {
            death_timer = 0;
            moving = false;
            StartCoroutine(DestroyObject());
        }
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }


}
