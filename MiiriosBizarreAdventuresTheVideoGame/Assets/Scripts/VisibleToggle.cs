using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleToggle : MonoBehaviour
{
    Renderer m_Renderer;
    public GameObject thingtoactivate;

    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (m_Renderer.isVisible)
        {
            thingtoactivate.SetActive(true);
        }
    }
   
}
