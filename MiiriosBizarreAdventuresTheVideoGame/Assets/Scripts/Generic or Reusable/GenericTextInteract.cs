/*
 * When interacted returns a string to the players interact text script which allows text to be 
 * displayed on screen
 */

using UnityEngine;

public class GenericTextInteract : MonoBehaviour, Interactable
{
    [TextArea(15, 20)]
    public string stringtoret;


    public string InteractWithObject()
    {
        return stringtoret;
    }
}
