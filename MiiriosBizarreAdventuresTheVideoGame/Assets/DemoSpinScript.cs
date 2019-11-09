using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSpinScript : MonoBehaviour
{
    public float spinval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Rotate(new Vector3(Time.deltaTime * 0f, spinval, 0f));

    }
}
