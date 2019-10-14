using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnYAxis : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(Time.deltaTime * 0f, 5f, 0f));
    }
}
