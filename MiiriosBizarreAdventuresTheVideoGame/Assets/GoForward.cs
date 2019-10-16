using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    private readonly int speed = 20;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
