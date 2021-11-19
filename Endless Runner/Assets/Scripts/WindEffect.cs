using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Vector3 start_pos;
    [SerializeField]
    private Vector2 random_pos;
    [SerializeField]
    private Vector2 random_time;

    [SerializeField]
    private GameObject wind_prefab;

    void Start()
    {
        StartCoroutine(SpawnTrails());
    }

    IEnumerator SpawnTrails()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(random_time.x, random_time.y));
            SpawnTrail();
        }
    }

    private void SpawnTrail()
    {
        Vector3 spawn_point = new Vector3(start_pos.x, Random.Range(random_pos.x,random_pos.y), start_pos.z);
        Instantiate(wind_prefab, spawn_point, Quaternion.identity);
    }
}
