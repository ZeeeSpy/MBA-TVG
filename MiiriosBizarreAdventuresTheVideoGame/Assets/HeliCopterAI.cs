using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeliCopterAI : MonoBehaviour, Shootable
{
    private int HP = 177;
    public Slider BossHPSlider;
    private AudioSource AS;
    private bool IntroDone = false;

    public AudioClip JaakieStartSoundClip;
    public AudioClip AnimeMusic;

    public AudioClip evi1;
    public AudioClip evi2;
    public AudioClip evi3;
    public AudioClip evi4;
    public AudioClip evi5;

    public GameObject eviobj1;


    private Transform player;
    private Vector3 playerlocation;
    private bool evidence1 = false;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        StartCoroutine("JaakieStart");
        player = GameObject.FindWithTag("Player").transform;
        StartCoroutine(ShootEvidence(eviobj1));
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
                AS.PlayOneShot(evi1);
                StartCoroutine(ShootEvidence(eviobj1));
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
        GameObject CurrentAttack = Instantiate(evidence, transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(0,0,0));
        CurrentAttack.GetComponent<Rigidbody>().AddForce((playerlocation - transform.position + new Vector3(0,2,0)) * 5);
        yield return new WaitForSeconds(20);
        Destroy(CurrentAttack);
    }

    void Update()
    {
        playerlocation = player.position;
    }
}
