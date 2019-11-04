/*
 * Genetic script that increases the volume of a auido source when a collider is triggered
 */

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
