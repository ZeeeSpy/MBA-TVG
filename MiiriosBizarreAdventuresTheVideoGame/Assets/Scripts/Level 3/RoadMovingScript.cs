/*
 *  Script that moves road to give the illusion of player moving
 */

using System.Collections;
using UnityEngine;

public class RoadMovingScript : MonoBehaviour
{
    private Vector3 direction = new Vector3(0, 0, -1);


    void Start()
    {
        StartCoroutine("DestroySelf");
    }

    
    private void FixedUpdate()
    {
        transform.Translate(direction * 40 * Time.deltaTime);
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(30f);
        Destroy(gameObject);
    }
}
