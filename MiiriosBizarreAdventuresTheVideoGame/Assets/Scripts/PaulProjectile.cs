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
            Vector3 projectiledirect = transform.forward;
            impact = transform.forward * 50;
            Debug.Log(impact);
        }
    }

    void Update()
    {
        if (impact.magnitude > 0) player.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 0.2f* Time.deltaTime);
    }
}