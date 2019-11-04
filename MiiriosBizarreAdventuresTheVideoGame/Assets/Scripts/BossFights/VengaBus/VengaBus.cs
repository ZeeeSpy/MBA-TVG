/*
 * Script that controls the venga buses behaviour. 
 * 
 * Behaviour is simple, bus stops, looks at player, stops, charges and then repeats 
 * 
 * when the bus gets below 50% hp the bus becomes faster and activates anti side step barriers.
 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class VengaBus : MonoBehaviour, Shootable
{
    public Transform player;
    private Rigidbody thisbus;
    private bool FindingPlayer = false;
    private int force = 9000;
    private int HP = 200;
    //private readonly int MaxHp = 200;
    //Max Hp 200
    private int phase = 1;
    private float phasewait = 3f;
    public Slider Hpbar;
    bool charging = false;
    public BoxCollider hurtbox;
    public GameObject demotebars;
    private AudioSource music;

    public GameObject deathparticles;

    public AudioClip DeathSound;
    public AudioClip Phase1Music;
    public AudioClip Phase2Music;
    private bool inphase2 = false;
    private bool died = false;
    public GameObject pepes;

    public BoxCollider nextLevel;

    private void Start()
    {
        thisbus = gameObject.GetComponent<Rigidbody>();
        StartCoroutine("BossLoop");
        music = gameObject.GetComponent<AudioSource>();
        music.clip = Phase1Music;
        music.Play();
    }

    void Update()
    {
        if (FindingPlayer)
        {
            Vector3 targetPostition = new Vector3(player.position.x, this.transform.position.y, player.position.z);
            Vector3 relativePos = targetPostition - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 5 * Time.deltaTime);
        }
    }

    IEnumerator BossLoop()
    {
        while (true)
        {
            FindingPlayer = true;
            yield return new WaitForSeconds(phasewait);
            FindingPlayer = false;
            charge();
            yield return new WaitForSeconds(phasewait);
            charging = false;
            hurtbox.enabled = false;
            thisbus.AddForce(transform.up * -1000);
        }
    }

    private void charge() //Needed othwerwise the coroutine breaks and it charges multiple times per charge
    {
        if (!charging)
        {
            thisbus.AddForce(transform.forward * force * phase);
            charging = true;
            hurtbox.enabled = true;
        }
    }

    private void Phase2()
    {
        if (!inphase2)
        {
            phase = 2;
            phasewait = 1.5f;
            Debug.Log("Phase 2");
            demotebars.SetActive(true);
            music.clip = Phase2Music;
            music.Play();
            inphase2 = true;
        }
    }

    public void GetShot()
    {
        HP = HP - 1;
        Hpbar.value = HP;
        if (HP < 100)
        {
            Phase2();
        }

        if (HP <= 0)
        {
            BossDead();
        }
    }

    private void BossDead()
    {
        if (!died)
        {
            music.Stop();
            StopCoroutine("BossLoop");
            Debug.Log("Boss Defeated");
            music.PlayOneShot(DeathSound);
            deathparticles.SetActive(true);
            demotebars.SetActive(false);
            hurtbox.enabled = false;
            died = true;
            pepes.SetActive(false);
            FindingPlayer = false;
            nextLevel.enabled = true;
        }
    }
}

