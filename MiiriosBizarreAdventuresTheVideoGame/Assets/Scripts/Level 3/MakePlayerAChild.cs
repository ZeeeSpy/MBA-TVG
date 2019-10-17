using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlayerAChild : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player.gameObject.transform.SetParent(transform);
    }
}
