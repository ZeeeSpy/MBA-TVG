using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisIsThePolice : MonoBehaviour
{
    public AudioClip PoliceClip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Police");

    }

    IEnumerator Police() {
        yield return new WaitForSeconds(15f);
        GetComponent<AudioSource>().PlayOneShot(PoliceClip);
    }
}
