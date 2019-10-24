using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    private Transform playerlocation;

    void Start()
    {
        playerlocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(playerlocation);
    }
    
}
