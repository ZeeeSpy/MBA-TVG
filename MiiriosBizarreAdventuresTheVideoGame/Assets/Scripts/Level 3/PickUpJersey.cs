/*
 *  Script that picks up Jersey in level 3. increases Jersey count and destroys the Jersey 
 */

using System.Collections;
using UnityEngine;

public class PickUpJersey : MonoBehaviour
{
    private AudioSource thisaudio;
    private JerseyCount globalcounter;
    private void Awake()
    {
        globalcounter = (JerseyCount)FindObjectOfType(typeof(JerseyCount));
        thisaudio = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("TakeAndDestroy");
        }
    }

    IEnumerator TakeAndDestroy()
    {
        thisaudio.Play();
        yield return new WaitForSeconds(0.2f);
        globalcounter.AddShirt();
        Destroy(gameObject);
    }
}
