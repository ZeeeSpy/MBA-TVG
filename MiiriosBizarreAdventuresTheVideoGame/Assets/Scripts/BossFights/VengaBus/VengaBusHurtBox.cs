/*
 * Script that attacked to the front and sides of the venga bus, so when the player gets hit
 * they take damage and are sent into the air
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengaBusHurtBox : MonoBehaviour
{
    Vector3 impact = Vector3.zero;
    CharacterController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().Damage(10);
            player = other.GetComponent<CharacterController>();
            impact = ((other.transform.up+(-1*other.transform.forward)) * 50);
            }
    }

    void Update()
    {
        if (impact.magnitude > 0.2) player.Move(impact * Time.deltaTime);
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
}
