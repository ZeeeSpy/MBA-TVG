/*
 *  DEPRECIATED
 *  
 *  originally the player could control the ambulance making it go left and right
 *  but this was changed in favor of allowing the player to move ontop of the ambulance
 */


using UnityEngine;

public class GoForward : MonoBehaviour
{
    private readonly int speed = 20;
    private readonly float leftmostlimit = 8.3f;
    private readonly float rightmostlismit = -8.3f;
    private readonly float turnspeed = 0.4f;
    public AudioSource AS;

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(0,0,1);
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (!(transform.position.x < rightmostlismit))
            {
                if (!AS.isPlaying)
                {
                    AS.Play();
                }
                direction = new Vector3(direction.x - turnspeed, direction.y, direction.z);
            }
        }

        if (Input.GetAxis("Horizontal") < 0) //Go left relative to looking back
        {
            if (!(transform.position.x > leftmostlimit))
            {
                if (!AS.isPlaying)
                {
                    AS.Play();
                }
                direction = new Vector3(direction.x + turnspeed, direction.y, direction.z);
            }
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            AS.Stop();
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
