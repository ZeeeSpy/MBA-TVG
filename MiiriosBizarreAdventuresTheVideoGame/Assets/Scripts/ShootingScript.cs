using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    Animator gunanimator;

    private void Start()
    {
        gunanimator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            gunanimator.Play("Shoot");
            Debug.Log("Bang");
        }
    }
}
