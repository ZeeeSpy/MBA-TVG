using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopCarSpawner : MonoBehaviour
{
    private Vector3[] carspawns = new Vector3[4];
    private bool[] spacetaken = new bool[4];
    public GameObject copcarobject;

    void Start()
    {
        for (int i = 0; i < spacetaken.Length; i++)
        {
            spacetaken[i] = false;
        }
        UpdateZLocation();

        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine("SpawnCopCar");
    }

    IEnumerator SpawnCopCar()
    {
        while (true)
        {
            int spawnloc = -1;

            for (int i = 0; i < spacetaken.Length; i++)
            {
                if (spacetaken[i] == false)
                {
                    spawnloc = i;
                    break;
                }
            }

            if (spawnloc != -1)
            {
                GameObject currentspawn = Instantiate(copcarobject, carspawns[spawnloc], transform.rotation);
                currentspawn.GetComponentInChildren<CopCarScript>().SetUpCar(spawnloc,this);
                spacetaken[spawnloc] = true;
            }
            yield return new WaitForSeconds(Random.Range(3, 9));
        }
    }

    private void UpdateZLocation()
    {
        float zposition = transform.position.z;
        carspawns[0] = new Vector3(2.45f, 0, zposition);
        carspawns[1] = new Vector3(9, 0, zposition);
        carspawns[2] = new Vector3(-5.25f, 0, zposition);
        carspawns[3] = new Vector3(-11.5f, 0, zposition);
    }

    public void ReleasePosition(int position)
    {
        spacetaken[position] = false;
    }

    public void StopCopCarSpawn()
    {
        StopCoroutine("SpawnCopCar");
    }
}
