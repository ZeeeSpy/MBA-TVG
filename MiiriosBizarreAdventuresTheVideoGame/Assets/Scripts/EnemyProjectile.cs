using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    private int ProjectileDamage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("World"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().Damage(ProjectileDamage);
            Destroy(gameObject);
        }    
    } 
}
