using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceProjectile : MonoBehaviour
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
            Debug.Log("HitPlayer");
            other.GetComponent<PlayerScript>().Damage(ProjectileDamage);
            Destroy(gameObject);
        }
    }
}
