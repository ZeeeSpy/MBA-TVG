using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCopterSway : MonoBehaviour
{
    
    private readonly float smooth = 1f;
    Quaternion maxy = Quaternion.Euler(0, 220f, 22);
    Quaternion miny = Quaternion.Euler(0, 150f, -22);
    bool swaydirection = false;
    //false = sway left relative to helicopter;

    private void FixedUpdate()
    {
        if (swaydirection)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, maxy, (smooth * Time.deltaTime) * 3);
        } else
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, miny, (smooth * Time.deltaTime) * 3);
        }
    }

    public void toggledirection()
    {
        swaydirection = !swaydirection;
    }

    public void toggledirection(bool direction)
    {
        swaydirection = direction;
    }
}
