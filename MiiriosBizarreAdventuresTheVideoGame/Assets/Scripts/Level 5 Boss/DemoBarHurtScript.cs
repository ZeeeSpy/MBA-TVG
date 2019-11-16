using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBarHurtScript : MonoBehaviour
{
    public int DamageVal = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().Damage(DamageVal);
        }
    }
}
