using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    private bool sway = false;
    //sway false = left relative to helicopter
    private bool pause = false;
    public HeliCopterSway thissway;

    void Start()
    {
        StartCoroutine("GoLeftRight");
    }

    IEnumerator GoLeftRight()
    {
        while (true)
        {
            if (transform.position.x > 16) //Gone too far right
            {
                sway = false;
                thissway.toggledirection(false);
            }
            else if (transform.position.x < -16)
            {
                sway = false;
                thissway.toggledirection(false);
            }
            else
            {
                sway = !sway;
                thissway.toggledirection();
            }

            yield return new WaitForSeconds(Random.Range(1, 6));
        }
    }

    void FixedUpdate()
    {
        if (sway)
        {
            transform.Translate(new Vector3(1,0,0) * 5 * Time.deltaTime);
        } else
        {
            transform.Translate(new Vector3(-1, 0, 0) * 5 * Time.deltaTime);
        }
    }
}
