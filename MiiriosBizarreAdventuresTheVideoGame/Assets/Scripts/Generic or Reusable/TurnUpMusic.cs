using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnUpMusic : MonoBehaviour
{
    public AudioSource audiototurnup;
    public int volume;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audiototurnup.maxDistance = volume;
        }
    }
}
