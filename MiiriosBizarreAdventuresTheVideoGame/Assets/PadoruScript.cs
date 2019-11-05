using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadoruScript : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    private Vector3 start;
    private Vector3 dest;
    public AudioSource worldmusic;
    public AudioClip padoruclip;

    bool complete = false;

    private readonly float speed = .25f;
    private float fraction = 0;
    private float fraction2 = 0;

    private void Start()
    {
        worldmusic.Stop();
        worldmusic.clip = padoruclip;
        worldmusic.Play();

        start = new Vector3(pos1.position.x, pos1.position.y, pos1.position.z);
        dest = new Vector3(pos2.position.x, pos2.position.y, pos2.position.z);
    }

    void Update()
    {
        if (fraction < 1)
        {
            fraction += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(start, dest, fraction);
        } else
        {
            complete = true;
        }

        if (complete && fraction2 <= 1)
        {
            fraction2 += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(dest, start, fraction2);
        }

        if (complete && fraction2 > 1)
        {
            fraction = 0;
            fraction2 = 0;
            complete = false;
        }
    }
}

//127.47 , 0.323 , 75.83. rotat y -90