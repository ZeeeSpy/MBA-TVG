using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectsOnTrigger : MonoBehaviour
{
    public GameObject ThingToActivateOnTrigger;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThingToActivateOnTrigger.SetActive(true);
        }
    }
}
