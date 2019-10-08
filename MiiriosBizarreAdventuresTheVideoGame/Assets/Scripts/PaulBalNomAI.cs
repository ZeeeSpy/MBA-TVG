using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PaulBalNomAI : MonoBehaviour, Shootable
{
    //State 
    private int HP = 10;
    private NavMeshAgent ThisPaulBalNom;
    private bool Dead;
    private bool FallOver = false;
    private AudioSource thisAudioSource;
    
    //Projectile 
    private int force = 150;
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
        ThisPaulBalNom = gameObject.GetComponent<NavMeshAgent>();

        colliders = GetComponentsInChildren<BoxCollider>();
        playerlocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        ThisPaulBalNom.SetDestination(playerlocation);
        StartCoroutine("DeathFist");

        ThisPaulBalNom.updateRotation = false;

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
            ThisPaulBalNom.SetDestination(playerlocation);
        }
        Ray ray = new Ray(transform.position, playerlocation - transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 50f))
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
            ThisPaulBalNom.enabled = false;
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
            StopCoroutine("DeathFist");
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator DeathFist() {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f,2.5f));
                if (haslos)
                {
                    yield return new WaitForSeconds(0.2f);
                    GameObject CurrnetAttack = Instantiate(attack, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
                    CurrnetAttack.GetComponent<Rigidbody>().AddForce((playerlocation - transform.position) * force);
                    thisAudioSource.PlayOneShot(AttackSFX[Random.Range(0, AttackSFX.Length)]);
                    yield return new WaitForSeconds(2);
                    Destroy(CurrnetAttack);
                }
            }
        } 
}