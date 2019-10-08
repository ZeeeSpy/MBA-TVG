using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulProjectile : MonoBehaviour
{
    Vector3 impact = Vector3.zero;
    CharacterController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("World"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<CharacterController>();
            Vector3 projectiledirect = other.transform.position - transform.position;
            impact = ((other.transform.up + (-2 * projectiledirect)) * 50);
        }
    }

    void Update()
    {
        if (impact.magnitude > 0.2) player.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
}