using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellSweepProjectile : MonoBehaviour
{
    [SerializeField]
    private int ProjectileDamage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().Damage(ProjectileDamage);
            Destroy(gameObject);
        }    
    } 
}
