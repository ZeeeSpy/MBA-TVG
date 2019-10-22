using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceProjectile : MonoBehaviour
{
    [SerializeField]
    private int ProjectileDamage = 1;

    private void Start()
    {
        StartCoroutine("DestroySelf");
    }

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

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
