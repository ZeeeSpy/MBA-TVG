using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreggoLeeAI : MonoBehaviour
{
    public Level1TextStuff texttoscreen;
    public Sprite PreggoLeeSprite;

    public GameObject Gun;
    public GameObject Crosshair;
    public GameObject BulletSpawner;

    public GameObject LowSpinner;
    public GameObject WallSpinner;


    private readonly float ProjectileLife = 2.5f;

    //projectiles and sounds
    public GameObject D3Projectile;
    public GameObject B2Projectile;
    private AudioSource AS;
    public AudioClip Music;
    public AudioClip B2Sound;


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
        QuickStart();
        //StartCoroutine("LeeIntroMonologue");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        playerlocation = player.transform.position;
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
        int selectorint = 0;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            selectorint = Random.Range(1,3);
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
                //TODO one more attack
            }   
        }
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
        GameObject CurrentAttack = Instantiate(B2Projectile, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        CurrentAttack.GetComponent<Rigidbody>().AddForce((playerlocation - transform.position) * 100);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }

    IEnumerator D3()
    {
        GameObject CurrentAttack = Instantiate(D3Projectile, transform.position + new Vector3(0, -1, 0), transform.rotation);
        CurrentAttack.GetComponent<Rigidbody>().AddForce(((playerlocation - transform.position) * 50));
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }
}
