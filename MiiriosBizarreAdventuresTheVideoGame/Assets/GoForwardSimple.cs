using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForwardSimple : MonoBehaviour
{
    private Vector3 direction = new Vector3(0, 0, 1);
    private void FixedUpdate()
    {
        transform.Translate(direction * 20 * Time.deltaTime);
    }
}
