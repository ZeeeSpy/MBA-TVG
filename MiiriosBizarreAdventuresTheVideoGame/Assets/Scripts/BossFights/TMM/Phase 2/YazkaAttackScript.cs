using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YazkaAttackScript : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(transform.forward * 50 * Time.deltaTime);

        if (transform.position.z > 70)
        {
            Destroy(gameObject);
        }
    }
}
