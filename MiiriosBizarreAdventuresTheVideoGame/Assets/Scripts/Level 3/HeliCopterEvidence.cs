using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCopterEvidence : MonoBehaviour, Shootable
{
    [SerializeField]
    public int ProjectileDamage = 15;
    public GameObject HPBAR;
    private int HP = 15;

    void Start()
    {
        StartCoroutine("DestroySelf");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("World"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().Damage(ProjectileDamage);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }

    public void GetShot()
    {
        HP--;
        HPBAR.transform.localScale = new Vector3(HP*2, 1, 0.5f);
        if (HP < 0)
        {
            Destroy(gameObject);
        }
    }
}
