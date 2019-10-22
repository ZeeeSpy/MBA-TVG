using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeliCopterAI : MonoBehaviour, Shootable
{
    private int HP = 200;
    public Slider BossHPSlider;
    private AudioSource AS;


    public AudioClip JaakieStartSoundClip;
    public AudioClip AnimeMusic;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        StartCoroutine("JaakieStart");
    }


    void Shootable.GetShot()
    {
        HP--;
        UpdateHP();
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
    }
}
