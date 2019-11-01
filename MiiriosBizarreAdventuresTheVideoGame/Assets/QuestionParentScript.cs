using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionParentScript : MonoBehaviour
{
    public void DisableColliders()
    {
        BoxCollider[] childcolliders = GetComponentsInChildren<BoxCollider>();
        for (int i = 0; i < childcolliders.Length; i++)
        {
            childcolliders[i].enabled = false;
        }
    }
}
