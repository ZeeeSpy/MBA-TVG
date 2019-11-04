/*
 *  Script that gradually incrases the volume of a audio source
 *  
 *  used to make it sound like police cars are pulling in from a distance
 */

using UnityEngine;

public class AudioLoudener : MonoBehaviour
{
    private float t = 0;
    private float timeToReachTarget = 10f;
    private void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        GetComponent<AudioSource>().volume = Mathf.Lerp(0f, 0.25f, t);
    }
}
