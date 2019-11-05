using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipSong : MonoBehaviour, Shootable
{
    public GameObject todisable;
    public AudioSource globalmusic;
    public AudioClip musictoplay;
    public GameObject padoruHPbar;
    private bool activated = false;

    public void GetShot()
    {
        todisable.SetActive(false);
        padoruHPbar.SetActive(false);
        if (!activated)
        {
            globalmusic.Stop();
            globalmusic.clip = musictoplay;
            globalmusic.Play();
            activated = true;
        }
    }
}
