using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    public Level1TextStuff UIText;
    public Text interacticon;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1f))
        {
            interacticon.enabled = true;
            Interactable InteractedObject = hit.collider.GetComponent<Interactable>();
            if (InteractedObject != null)
            {
                if (Input.GetButtonDown("Interact"))
                {
                    Interact(hit);
                }
            } else
            {
                interacticon.enabled = false;
            }
        } else
        {
            interacticon.enabled = false;
        }
        

    }

    private void Interact(RaycastHit hit)
    {
        UIText.showtext(hit.collider.GetComponent<Interactable>().InteractWithObject());
    }

    public void DiplayText(string textodisp)
    {
        UIText.showtext(textodisp);
    }
}
