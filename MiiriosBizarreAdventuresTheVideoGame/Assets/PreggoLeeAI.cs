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
    public GameObject Spinner;


    private readonly float ProjectileLife = 5f;

    //projectiles and sounds
    public GameObject D3Projectile;
    public GameObject B2Projectile;
    private AudioSource AS;
    public AudioClip Music;
    public AudioClip B2Sound;


    //player stuff
    private GameObject player;
    private Vector3 playerlocation;

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
        Spinner.SetActive(true);
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
        Spinner.SetActive(true);
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
            yield return new WaitForSeconds(Random.Range(1, 5));
            selectorint = Random.Range(1,3);
            switch (selectorint)
            {
                case 1:
                    StartCoroutine("B2Loop");
                    yield return new WaitForSeconds(1.5f);
                    break;
                case 2:
                    StartCoroutine("D3");
                    yield return new WaitForSeconds(0.5f);
                    break;
            }   
        }
    }

    IEnumerator B2Loop()
    {

        for (int i = 0; i < 3; i++)
        {
            AS.PlayOneShot(B2Sound);
            StartCoroutine("B2");
            yield return new WaitForSeconds(0.5f);
        } //1.5 seconds total
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
