using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeliCopterAI : MonoBehaviour, Shootable
{
    private int HP = 150;
    public Slider BossHPSlider;
    private AudioSource AS;
    private bool IntroDone = false;

    public AudioClip JaakieStartSoundClip;
    public AudioClip AnimeMusic;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        StartCoroutine("JaakieStart");
    }


    void Shootable.GetShot()
    {
        if (IntroDone)
        {
            HP--;
            UpdateHP();
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
}
