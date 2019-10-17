using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawningScript : MonoBehaviour
{
    public Transform player;
    public GameObject road;
    private int roadnumb = 0;
    private readonly int roadspawnlimit = 10;
    private GameObject[] currentroads = new GameObject[10];
    public GameObject startingroad;

    private void Start()
    {
        StartCoroutine("DestroyRoads");
    }

    void Update()
    {
        if (player.position.z > (roadnumb * 100))
        {
            roadnumb++;
            if (currentroads[roadnumb % roadspawnlimit] != null)
            {
                Destroy(currentroads[roadnumb % roadspawnlimit]);
            }
            currentroads[roadnumb % roadspawnlimit] = Instantiate(road, transform.position + new Vector3(0, 0, ((100 * roadnumb)+400)), transform.rotation);
        }
    }

    IEnumerator DestroyRoads()
    {
        yield return new WaitForSeconds(1f);
        Destroy(startingroad);
    }
}
