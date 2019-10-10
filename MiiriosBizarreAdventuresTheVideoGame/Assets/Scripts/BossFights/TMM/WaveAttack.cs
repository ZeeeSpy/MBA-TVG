using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly int force = 50;
    private readonly Vector3 lowcorrection = new Vector3 (0f, 0.5f, 0f);

    void Awake()
    {
        GameObject Playerlocation = GameObject.FindGameObjectWithTag("Player");
        Rigidbody[] children;
        children = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody item in children)
        {
            item.AddForce((Playerlocation.transform.position - transform.position + lowcorrection)*force);
        }
    }
    
}
