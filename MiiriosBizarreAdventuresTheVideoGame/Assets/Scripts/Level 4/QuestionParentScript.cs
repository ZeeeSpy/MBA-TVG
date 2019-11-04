/*
 *  Script that disables colliders in children when one answer is selected.
 *  
 *  used in level 4 boss fight
 */

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
