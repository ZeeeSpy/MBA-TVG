using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    private bool sway = false;
    //sway false = left relative to helicopter
    public HeliCopterSway thissway;

    void Start()
    {
        StartCoroutine("GoLeftRight");
    }

    IEnumerator GoLeftRight()
    {
        while (true)
        {
            float range = Random.Range(1f, 3.6f);
            //Sway to one direction distance X
            //Sway back distance X * 2 to mirror the sway
            //Sway back distance x to get back to center
            //repeat

            sway = !sway;
            thissway.toggledirection();
            yield return new WaitForSeconds(range);

            sway = !sway;
            thissway.toggledirection();
            yield return new WaitForSeconds(range*2);

            sway = !sway;
            thissway.toggledirection();
            yield return new WaitForSeconds(range);
        }
    }

    void FixedUpdate()
    {
        if (sway)
        {
            transform.Translate(new Vector3(1, 0, 0) * 5 * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(-1, 0, 0) * 5 * Time.deltaTime);
        }
    }
}
