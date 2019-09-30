using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private int HP = 100;

    public void Damage(int d)
    {
        HP = HP - d;
        Debug.Log(HP);
    }
}
