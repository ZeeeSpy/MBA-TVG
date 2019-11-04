/*
 * Makes current game object face player. Used in many objects mostly AI scripts.
 */

using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    private Transform playerlocation;

    void Start()
    {
        playerlocation = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(playerlocation);
    }
    
}
