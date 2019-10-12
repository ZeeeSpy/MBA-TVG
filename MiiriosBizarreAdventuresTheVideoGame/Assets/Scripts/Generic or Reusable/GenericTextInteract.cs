using System.Collections;
using System.Collections.Generic;
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
