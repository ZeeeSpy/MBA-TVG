using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    private readonly int speed = 20;
    private readonly float leftmostlimit = 4.3f;
    private readonly float rightmostlismit = -4.3f;
    private readonly float turnspeed = 0.4f;

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(0,0,1);


        if (Input.GetAxis("Horizontal") > 0)
        {
            if (!(transform.position.x < rightmostlismit))
            {
                direction = new Vector3(direction.x - turnspeed, direction.y, direction.z);
            }
        }

        if (Input.GetAxis("Horizontal") < 0) //Go left relative to looking back
        {
            if (!(transform.position.x > leftmostlimit))
            {
                direction = new Vector3(direction.x + turnspeed, direction.y, direction.z);
            }
        }


        transform.Translate(direction * speed * Time.deltaTime);
    }
}
