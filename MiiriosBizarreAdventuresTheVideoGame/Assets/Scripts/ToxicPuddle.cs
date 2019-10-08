using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicPuddle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().Damage(200);
        }
    }
}
