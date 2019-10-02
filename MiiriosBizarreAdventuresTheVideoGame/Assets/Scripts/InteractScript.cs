using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    private Interactable cachedinteractabe;
    private bool caninteract = false;
    public Level1TextStuff UIText;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * 3, out hit))
        {
            Interactable ObjectThatWasInteractedWith = hit.collider.GetComponent<Interactable>();
            if (ObjectThatWasInteractedWith != null)
            {
                cachedinteractabe = ObjectThatWasInteractedWith;
                caninteract = true;
            } else
            {
                caninteract = false;
                cachedinteractabe = null;
            } 
            
        }


        if (Input.GetButtonDown("Interact") && caninteract)
        {
            Interact();
        }
    }

    private void Interact()
    {
        UIText.showtext(cachedinteractabe.InteractWithObject());
    }
}
