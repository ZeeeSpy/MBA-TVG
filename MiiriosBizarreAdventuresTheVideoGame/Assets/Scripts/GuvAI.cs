using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GuvAI : MonoBehaviour, Shootable
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

    //Cache
    private Vector3 playerlocation;

    void Start()
    {
        thisAudioSource = gameObject.GetComponent<AudioSource>();
        ThisGuv = gameObject.GetComponent<NavMeshAgent>();


        playerlocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        ThisGuv.SetDestination(playerlocation);
        StartCoroutine("B1");

        ThisGuv.updateRotation = false;

        //audio
        AttackSFX = Resources.LoadAll<AudioClip>("Guv/Attack");
        DeadSFX = Resources.LoadAll<AudioClip>("Guv/Dead");
        HurtSFX = Resources.LoadAll<AudioClip>("Guv/Hurt");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead)
        {
            playerlocation = GameObject.FindGameObjectWithTag("Player").transform.position;
            ThisGuv.SetDestination(playerlocation);
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
        Debug.Log("This Guv Got Hit");
        HP--;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (HP <= 0)
        {
            Debug.Log("GuvDied");
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
            transform.position = new Vector3(transform.position.x, 0.51f, transform.position.z);
            thisAudioSource.PlayOneShot(DeadSFX[Random.Range(0, DeadSFX.Length)]);
            transform.Rotate(0, 0, 90);
            FallOver = true;
            StopCoroutine("B1");
        }
    }

    IEnumerator B1() {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(B1Attack());
                yield return new WaitForSeconds(0.2f);
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
}