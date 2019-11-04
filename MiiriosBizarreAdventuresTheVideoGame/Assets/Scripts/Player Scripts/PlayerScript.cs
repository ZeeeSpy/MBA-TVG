/*
 *  Script that controls player health, as well as updating UI elementes regarding player health
 *  
 *  also in charge of killing player if they get below 0 hp
 */

using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private int HP = 45;
    //Max Hp 45
    public Image RankUIImage;
    private Sprite[] RankArray;
    public Transform camerapos;
    private AudioSource[] allAudioSources;
    private bool Died = false;
    public AudioSource GameOverAudio;
    public Image gameover;
    public AudioClip Oof;

    private void Awake()
    {
        RankArray = Resources.LoadAll<Sprite>("Ranks/Ranks");
        UpdateRank();
    }

    public void Damage(int d)
    {
        HP = HP - d;
        GameOverAudio.PlayOneShot(Oof); 
        if (HP <= 0)
        {
            RankUIImage.sprite = RankArray[0];
            PlayerDead();
        } else
        {
            UpdateRank();
        }
    }

    private void UpdateRank()
    {
        RankUIImage.sprite = RankArray[HP];
    }

    private void PlayerDead()
    {
        if (!Died)
        {
            GetComponent<FirstPersonController>().enabled = false;
            camerapos.Rotate(0, 0, 90);
            StopAllAudio();
            GameOverAudio.Play();
            gameover.enabled = true;
            Died = true;
        }
    }

    void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }

    private void Update()
    {
        if (Died)
        {
            if (Input.GetButtonDown("Submit"))
            {
                string currentscene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentscene);
            }
        }
    }
}
