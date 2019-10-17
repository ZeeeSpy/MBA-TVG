using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCopterSway : MonoBehaviour
{
    
    private readonly float smooth = 1f;
    Quaternion maxy = Quaternion.Euler(0, 220f, 0);
    Quaternion miny = Quaternion.Euler(0, 150f, 0);
    bool swaymax = true;

    private void Start()
    {
        StartCoroutine("PanLeftRight");
    }

    IEnumerator PanLeftRight()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            swaymax = !swaymax;
        }
    }

    private void FixedUpdate()
    {
        if (swaymax)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, maxy, (smooth * Time.deltaTime) * 3);
        } else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, miny, (smooth * Time.deltaTime) * 3);
        }
    }
}
