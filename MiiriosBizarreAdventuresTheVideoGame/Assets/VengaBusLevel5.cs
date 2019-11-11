using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VengaBusLevel5 : MonoBehaviour
{
    public GameObject particles;
    public GameObject Wall;
    
    // Start is called before the first frame update
    void Start()
    {
        Wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 5.17)
        {
            transform.Translate(transform.forward * -30 * Time.deltaTime);
        }
    }
}
