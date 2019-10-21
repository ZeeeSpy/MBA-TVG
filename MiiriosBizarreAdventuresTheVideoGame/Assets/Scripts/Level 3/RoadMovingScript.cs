using System.Collections;
using System.Collections.Generic;
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
