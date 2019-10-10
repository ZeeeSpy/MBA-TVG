using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellSweep : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly int force = 75;

    void Awake()
    {
        GameObject Playerlocation = GameObject.FindGameObjectWithTag("Player");
        Rigidbody[] children;
        children = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody item in children)
        {
            Vector3 Temp = (Playerlocation.transform.position - transform.position);
            Vector3 Target = new Vector3(Temp.x, 0f, Temp.z);
            item.AddForce(Target*force);
        }
    }
    
}
