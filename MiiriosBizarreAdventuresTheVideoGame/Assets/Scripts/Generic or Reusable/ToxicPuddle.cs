/*
 * Genetic script that gives a box collider a "floor is lava" property. 
 */

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
