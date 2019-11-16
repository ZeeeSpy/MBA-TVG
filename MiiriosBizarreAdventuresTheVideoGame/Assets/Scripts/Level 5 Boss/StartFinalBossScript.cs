using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFinalBossScript : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Walkwavy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("FinalBossCutScene");
        }
    }

    IEnumerator FinalBossCutScene()
    {
        Walkwavy.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        Boss.SetActive(true);
    }
}
