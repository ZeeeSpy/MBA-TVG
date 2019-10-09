using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly int force = 50;

    void Awake()
    {
        GameObject Playerlocation = GameObject.FindGameObjectWithTag("Player");
        Rigidbody[] children;
        children = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody item in children)
        {
            //item.AddForce((Playerlocation.transform.position - transform.position) * force);
            item.AddForce((Playerlocation.transform.position - transform.position)*force);
        }
    }
    
}
