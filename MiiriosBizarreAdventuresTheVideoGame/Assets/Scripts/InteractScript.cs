using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    private bool caninteract = false;
    public Level1TextStuff UIText;
    public Image interacticon;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(transform.position, transform.forward * 10f, out hit))
        {
            Interactable ObjectThatWasInteractedWith = hit.collider.GetComponent<Interactable>();
            if (ObjectThatWasInteractedWith != null)
            {
                caninteract = true;
                interacticon.enabled = true;
                if (Input.GetButtonDown("Interact") && caninteract)
                {
                    Interact(hit);
                }
            } else
            {
                caninteract = false;
                interacticon.enabled = false;
            } 
            
        }
    }

    private void Interact(RaycastHit hit)
    {
        UIText.showtext(hit.collider.GetComponent<Interactable>().InteractWithObject());
    }
}
