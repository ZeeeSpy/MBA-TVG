/*
 * Lei AI. Just Guv Ai with different resources loaded.
 */

using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class LeiAI : MonoBehaviour, Shootable
{
    //State 
    private int HP = 3;
    private NavMeshAgent ThisGuv;
    private bool Dead;
    private bool FallOver = false;
    private AudioSource thisAudioSource;
    
    //Projectile 
    public int force = 100;
    public GameObject attack;

    //Audio
    private AudioClip[] AttackSFX;
    private AudioClip[] DeadSFX;
    private AudioClip[] HurtSFX;

    private BoxCollider[] colliders;
    //Cache
    private Vector3 playerlocation;

    private bool haslos = false;

    void Start()
    {
        thisAudioSource = gameObject.GetComponent<AudioSource>();
        ThisGuv = gameObject.GetComponent<NavMeshAgent>();

        colliders = GetComponentsInChildren<BoxCollider>();
        playerlocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        ThisGuv.SetDestination(playerlocation);
        StartCoroutine("B1");

        ThisGuv.updateRotation = false;

        //audio
        AttackSFX = Resources.LoadAll<AudioClip>("Lei/Attack");
        DeadSFX = Resources.LoadAll<AudioClip>("Lei/Dead");
        HurtSFX = Resources.LoadAll<AudioClip>("Lei/Hurt");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead)
        {
            playerlocation = GameObject.FindGameObjectWithTag("Player").transform.position;
            ThisGuv.SetDestination(playerlocation);
        }
        Ray ray = new Ray(transform.position, playerlocation - transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 30f))
        {
            if (hit.transform.tag == "Player")
            {
                haslos = true;
            }
            else
            {
                haslos = false;
            }
        } 
        
    }

    private void LateUpdate()
    {
        if (!Dead)
        {
            transform.LookAt(playerlocation);
        }
    }

    public void GetShot() {
        HP--;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (HP <= 0)
        {
            Dead = true;
            ThisGuv.enabled = false;
            Die();
        } else
        {
            thisAudioSource.PlayOneShot(HurtSFX[Random.Range(0, HurtSFX.Length)]);
        }
    }

    private void Die()
    {
        if (!FallOver)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y-0.51f, transform.position.z);
            thisAudioSource.PlayOneShot(DeadSFX[Random.Range(0, DeadSFX.Length)]);
            transform.Rotate(0, 0, 90);
            FallOver = true;
            StopCoroutine("B1");
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("SaveMemory");
        }
    }

    IEnumerator B1() {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f,2.5f));
            for (int i = 0; i < 3; i++)
            {
                if (haslos)
                {
                    StartCoroutine(B1Attack());
                    yield return new WaitForSeconds(0.2f);
                }
            }
        } 
    }

    IEnumerator B1Attack()
    {
        GameObject CurrnetAttack = Instantiate(attack, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        CurrnetAttack.GetComponent<Rigidbody>().AddForce((playerlocation-transform.position)*force);
        thisAudioSource.PlayOneShot(AttackSFX[Random.Range(0, AttackSFX.Length)]);
        yield return new WaitForSeconds(2);
        Destroy(CurrnetAttack);
    }

    IEnumerator SaveMemory()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}