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

    private void Awake()
    {
        RankArray = Resources.LoadAll<Sprite>("Ranks/Ranks");
        UpdateRank();
    }

    public void Damage(int d)
    {
        HP = HP - d;
        
        if (HP <= 0)
        {
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
            if (Input.GetButtonDown("Fire1"))
            {
                string currentscene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentscene);
            }
        }
    }
}
