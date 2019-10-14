using System.Collections;
using System.Collections.Generic;
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
