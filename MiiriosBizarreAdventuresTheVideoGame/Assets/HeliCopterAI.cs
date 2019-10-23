using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeliCopterAI : MonoBehaviour, Shootable
{
    private int HP = 200;
    public Slider BossHPSlider;
    public AudioSource AS;
    public AudioSource AS2;
    private bool IntroDone = false;

    public AudioClip JaakieStartSoundClip;
    public AudioClip AnimeMusic;

    public AudioClip evi1;
    public AudioClip evi2;
    public AudioClip evi3;
    public AudioClip evi4;
    public AudioClip evi5;

    public GameObject eviobj1;
    public GameObject eviobj2;
    public GameObject eviobj3;
    public GameObject eviobj4;
    public GameObject eviobj5;
    public GameObject eviobj6;


    private Transform player;
    private Vector3 playerlocation;

    private bool evidence1 = false;
    private bool evidence2 = false;
    private bool evidence3 = false;
    private bool evidence4 = false;
    private bool evidence5 = false;
    private bool evidence6 = false;

    void Start()
    {
        StartCoroutine("JaakieStart");
        player = GameObject.FindWithTag("Player").transform;
    }


    void Shootable.GetShot()
    {
        if (IntroDone)
        {
            HP--;
            UpdateHP();

            if (HP < 175 && !evidence1)
            {
                evidence1 = true;
                AS2.PlayOneShot(evi1);
                StartCoroutine(ShootEvidence(eviobj1));
            }

            if (HP < 125 && !evidence2)
            {
                evidence2 = true;
                AS2.PlayOneShot(evi2);
                StartCoroutine(ShootEvidence(eviobj2));
            }

            if (HP < 100 && !evidence3)
            {
                evidence3 = true;
                AS2.PlayOneShot(evi3);
                StartCoroutine(ShootEvidence(eviobj3));
            }

            if (HP < 75 && !evidence4)
            {
                evidence4 = true;
                AS2.PlayOneShot(evi4);
                StartCoroutine(ShootEvidence(eviobj4));
            }

            if (HP < 50 && !evidence5)
            {
                evidence5 = true;
                AS2.PlayOneShot(evi5);
                StartCoroutine(ShootEvidence(eviobj5));
            }
        }
    }

    private void UpdateHP()
    {
        BossHPSlider.value = HP;
    }

    IEnumerator JaakieStart()
    {
        AS.PlayOneShot(JaakieStartSoundClip);
        yield return new WaitForSeconds(13f);
        AS.clip = AnimeMusic;
        AS.Play();
        yield return new WaitForSeconds(2f);  
        BossHPSlider.gameObject.SetActive(true);
        IntroDone = true;
    }

    IEnumerator ShootEvidence(GameObject evidence)
    {
        GameObject CurrentAttack = Instantiate(evidence, transform.position, Quaternion.Euler(0,0,0));
        CurrentAttack.GetComponent<Rigidbody>().AddForce((playerlocation - transform.position + new Vector3(0,1,0)) * 10);
        yield return new WaitForSeconds(20);
        Destroy(CurrentAttack);
    }

    void Update()
    {
        playerlocation = player.position;
    }
}
