/*
 *  Script that spawns roads in Level 3 boss
 */

using System.Collections;
using UnityEngine;

public class RoadSpawningScript : MonoBehaviour
{
    public GameObject road;

    private void Start()
    {
        StartCoroutine("SpawnRoad");
    }


    IEnumerator SpawnRoad()
    {
        while (true)
        {
            GameObject SpawnedRoad = Instantiate(road, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
            yield return new WaitForSeconds(2.4f);
        }
    }
}
