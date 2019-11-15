using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreggoLeeAI : MonoBehaviour, Shootable
{
    public Level1TextStuff texttoscreen;
    public Sprite PreggoLeeSprite;

    public GameObject Gun;
    public GameObject Crosshair;
    public GameObject BulletSpawner;

    public GameObject LowSpinner;
    public GameObject WallSpinner;
    public GameObject FatherObj;

    public GameObject sliderobj;
    public Slider HPSlider;

    private int HP = 200;

    private readonly float ProjectileLife = 2.5f;

    //projectiles and sounds
    public GameObject D3Projectile;
    public GameObject B2Projectile;
    public GameObject TrackingProjectile;

    private AudioSource AS;
    public AudioClip Music;
    public AudioClip phase2Music;
    public AudioClip B2Sound;
    public AudioClip TrackingSound;
    public AudioClip Final;

    bool phase2 = false;
    bool phase3 = false;
    bool finalphase = false;
    bool finalphasestarted = false;

    //player stuff
    private GameObject player;
    private Vector3 playerlocation;

    Coroutine currentattack = null; //This is so that we can easily stop the coroutine

    // Start is called before the first frame update
    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (PlayerPrefs.HasKey("LeeDone"))
        {
            QuickStart();
        } else
        {
            StartCoroutine("LeeIntroMonologue");
        }
    }

    private void Update()
    {
        playerlocation = player.transform.position;

        if (finalphase && !finalphasestarted)
        {
            StartCoroutine(FinalPhase());
            finalphasestarted = true;
        }
    }

    public void ToggleFinalPhase()
    {
        finalphase = true;
    }

    IEnumerator LeeIntroMonologue()
    {
        yield return new WaitForSeconds(0);
        texttoscreen.showtext("Been waiting long?");

        yield return new WaitForSeconds(2);
        texttoscreen.showtext("Why do you hate me?");

        yield return new WaitForSeconds(2);
        texttoscreen.showtext("Why do you pick me if you hate me?");

        yield return new WaitForSeconds(3);
        texttoscreen.showtext("Even when we win you tell me to shut up");

        yield return new WaitForSeconds(4);
        texttoscreen.showtext("Worse still, you defiled me. You turned me into THIS. I won't give you a chance, prepare to die");

        Gun.SetActive(false);
        Crosshair.SetActive(false);
        BulletSpawner.SetActive(false);

        yield return new WaitForSeconds(5);
        texttoscreen.showtext("");
        GetComponent<SpriteRenderer>().sprite = PreggoLeeSprite;
        transform.localScale = new Vector3(10, 10, 1);
        yield return new WaitForSeconds(2);
        LowSpinner.SetActive(true);
        WallSpinner.SetActive(true);
        AS.Stop();
        AS.loop = true;
        AS.clip = Music;
        AS.Play();
        PlayerPrefs.SetInt("LeeDone", 1);
        StartCoroutine("Survive");
    }

    private void QuickStart()
    {
        AS.Stop();
        Gun.SetActive(false);
        Crosshair.SetActive(false);
        BulletSpawner.SetActive(false);
        texttoscreen.showtext("");
        GetComponent<SpriteRenderer>().sprite = PreggoLeeSprite;
        transform.localScale = new Vector3(10, 10, 1);
        LowSpinner.SetActive(true);
        WallSpinner.SetActive(true);
        AS.Stop();
        AS.loop = true;
        AS.clip = Music;
        AS.Play();
        StartCoroutine("Survive");
    }

    IEnumerator Survive()
    {
        StartCoroutine(Phase1Timer());
        int selectorint = 0;
        while (true)
        {
            if (phase2)
            {
                StopAllCoroutines();
                StartCoroutine("SurvivePhase2");
            }
            yield return new WaitForSeconds(Random.Range(1, 3));
            selectorint = Random.Range(1,4);
           
            switch (selectorint)
            {
                case 1:
                    int numbofloops = Random.Range(1, 8);
                    currentattack = StartCoroutine(B2Loop(numbofloops));
                    yield return new WaitForSeconds(numbofloops*0.5f);
                    break;
                case 2:
                    currentattack = StartCoroutine("D3");
                    yield return new WaitForSeconds(0.5f);
                    break;
                case 3:
                    currentattack = StartCoroutine("Tracking");
                    yield return new WaitForSeconds(0.5f);
                    break;
            }   
        }
    }

    IEnumerator SurvivePhase2()
    {
        StartCoroutine(Phase2Timer());
        int selectorint = 0;
        AS.Stop();
        AS.clip = phase2Music;
        AS.Play();
        while (true)
        {
            if (phase3)
            {
                StopAllCoroutines();
                Father();
                AS.volume = 0.1f;
            }
            yield return new WaitForSeconds(0.25f);
            selectorint = Random.Range(1, 4);
            switch (selectorint)
            {
                case 1:
                    int numbofloops = Random.Range(1, 8);
                    currentattack = StartCoroutine(B2Loop(numbofloops));
                    yield return new WaitForSeconds((numbofloops * 0.5f));
                    break;
                case 2:
                    currentattack = StartCoroutine("D3");
                    yield return new WaitForSeconds(0.25f);
                    break;
                case 3:
                    currentattack = StartCoroutine("Tracking");
                    yield return new WaitForSeconds(0.25f);
                    break;
            }
        }
    }

    IEnumerator FinalPhase()
    {
        sliderobj.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;

        LowSpinner.SetActive(true);
        WallSpinner.SetActive(true);

        int selectorint = 0;
        AS.volume = 0.2f;
        AS.loop = true;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            selectorint = Random.Range(1, 4);
            switch (selectorint)
            {
                case 1:
                    int numbofloops = Random.Range(1, 8);
                    currentattack = StartCoroutine(B2Loop(numbofloops));
                    yield return new WaitForSeconds((numbofloops * 0.5f));
                    break;
                case 2:
                    currentattack = StartCoroutine("D3");
                    yield return new WaitForSeconds(0.25f);
                    break;
                case 3:
                    currentattack = StartCoroutine("Tracking");
                    yield return new WaitForSeconds(0.25f);
                    break;
            }
        }
    }

    IEnumerator Phase1Timer()
    {
        yield return new WaitForSeconds(60);
        phase2 = true;
        Debug.Log("TimesUp");
    }

    IEnumerator Phase2Timer()
    {
        yield return new WaitForSeconds(60);
        phase3 = true;
        Debug.Log("TimesUp");
    }

    IEnumerator B2Loop(int numberofloops)
    {
        for (int i = 0; i < numberofloops; i++)
        {
            AS.PlayOneShot(B2Sound);
            StartCoroutine("B2");
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator B2()
    {
        GameObject CurrentAttack = Instantiate(B2Projectile, transform.position, transform.rotation);
        CurrentAttack.GetComponent<Rigidbody>().AddForce((playerlocation - transform.position) * 100);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }

    IEnumerator D3()
    {
        GameObject CurrentAttack = Instantiate(D3Projectile, transform.position + new Vector3(0, -3, 0), transform.rotation);
        Vector3 vec = ((playerlocation - transform.position) * 50);
        Vector3 force = new Vector3(vec.x, 0, vec.z);
        CurrentAttack.GetComponent<Rigidbody>().AddForce(force);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }

    IEnumerator Tracking()
    {
        AS.PlayOneShot(TrackingSound);
        GameObject CurrentAttack = Instantiate(TrackingProjectile, transform.position , transform.rotation);
        CurrentAttack.GetComponent<Rigidbody>().AddForce(((playerlocation - transform.position) *100));
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }

    private void Father()
    {
        LowSpinner.SetActive(false);
        WallSpinner.SetActive(false);
        FatherObj.SetActive(true);
    }

    public void GetShot()
    {
        HP--;
        HPSlider.value = HP;

        if (HP <= 0)
        {
            Debug.Log("Boss Killed");
            LowSpinner.SetActive(false);
            WallSpinner.SetActive(false);
            sliderobj.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
            StopAllCoroutines();
            StartCoroutine("MiirioLine");
        }
    }

    IEnumerator MiirioLine()
    {
        AS.Stop();
        AS.volume = 0.5f;
        AS.PlayOneShot(Final);
        yield return new WaitForSeconds(Final.length);
        Destroy(gameObject);
        SceneManager.LoadScene("Credits");
    }
}
