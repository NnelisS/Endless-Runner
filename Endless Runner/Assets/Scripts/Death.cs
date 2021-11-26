using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Death : MonoBehaviour
{
    public Animator death;
    public Animator closeScene;

    public AudioSource deathFall;

    private bool timerOn = false;
    private float spawnTimer = 1.0f;
    public GameObject player;

    public bool checkPointOneOn = true;
    public bool spawnOnCheckPoint = true;
    public GameObject checkPointOne;   
    
    public bool checkPointTwoOn = false;
    public bool spawnOnCheckPointTwo = false;
    public GameObject checkPointTwo;

    private void Update()
    {
        if (timerOn)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                timerOn = false;
                spawnTimer = 1.0f;

                /*death.Play("Undeath");*/
                closeScene.Play("OpenScene");

                if (spawnOnCheckPoint)
                {
                    player.transform.position = checkPointOne.transform.position;
                    player.transform.localRotation = Quaternion.Euler(transform.rotation.x, -90f, transform.rotation.z);

                }

                if (spawnOnCheckPointTwo)
                {
                    player.transform.position = checkPointTwo.transform.position;
                    player.transform.rotation = Quaternion.Euler(transform.rotation.x, -90f, transform.rotation.z);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            deathFall.Play(0);
            closeScene.Play("CloseScene");
            /*death.Play("Death");*/
            if (checkPointOneOn)
            {
                timerOn = true;
            }
            if (checkPointTwoOn)
            {
                timerOn = true;
            }
        }

        if (other.gameObject.CompareTag("CheckPointTwo"))
        {
            spawnOnCheckPoint = false;
            spawnOnCheckPointTwo = true;
            checkPointOneOn = false;
            checkPointTwoOn = true;
        }
    }
}
