using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class TMMAI : MonoBehaviour, Shootable
{
    //State 
    private int HP = 200;
    private NavMeshAgent TMM;
    private bool Dead;
    private bool FallOver = false;
    private AudioSource thisAudioSource;
    public Slider Hpbar;
    private int currentposition = 0;

    private Vector3 [] potentialpositions = new Vector3[5];

    //Projectile 
    public GameObject ConeAttack;
    public GameObject ConeAttackB;

    //Audio
    public AudioClip Masku;
    public AudioClip VryVry;

    //Cache
    private Vector3 playerlocation;

    void Start()
    {
        potentialpositions[0] = new Vector3 (-33.68f, 5.38f, -26.8f);
        potentialpositions[1] = new Vector3(-35.33f, 5.38f, 27.59f);
        potentialpositions[2] = new Vector3(9.66f, 5.38f, -28.272f);
        potentialpositions[3] = new Vector3(11.02f, 5.38f, 26.35f);
        potentialpositions[4] = new Vector3(-12.28f, 5.38f, 0f);

        thisAudioSource = gameObject.GetComponent<AudioSource>();
        TMM = gameObject.GetComponent<NavMeshAgent>();

        playerlocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        StartCoroutine("Wander");
        StartCoroutine("Attack");

        TMM.updateRotation = false;

        //audio
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (!Dead)
        {
            playerlocation = GameObject.FindGameObjectWithTag("Player").transform.position;
            transform.LookAt(playerlocation);
        }
    }

    public void GetShot() {
        HP--;
        Hpbar.value = HP;
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (HP <= 0)
        {
            Dead = true;
            TMM.enabled = false;
            Die();
        } else
        {
            //thisAudioSource.PlayOneShot(HurtSFX[Random.Range(0, HurtSFX.Length)]);
        }
    }

    private void Die()
    {
        if (!FallOver)
        {
            FallOver = true;
        }
    }

    IEnumerator Attack() {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int AttackNumb = Random.Range(1, 3);
            if (AttackNumb == 1)
            {
                StartCoroutine("Attack0");
                yield return new WaitForSeconds(4f);
            } else if (AttackNumb == 2)
            {
                StartCoroutine("Attack1");
                yield return new WaitForSeconds(4.4f);
            }
        } 
    }

    IEnumerator Attack0()
    {
        thisAudioSource.PlayOneShot(Masku);
        yield return new WaitForSeconds(1f);
        GameObject CurrentAttack = Instantiate(ConeAttack, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        yield return new WaitForSeconds(2.5f);
        Destroy(CurrentAttack);
    }


    IEnumerator Attack1()
    {
        thisAudioSource.PlayOneShot(VryVry);
        yield return new WaitForSeconds(1.4f);
        GameObject CurrentAttack = Instantiate(ConeAttackB, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        yield return new WaitForSeconds(2.5f);
        Destroy(CurrentAttack);
    }



    IEnumerator Wander()
    {
        while (true)
        {
            TMM.destination = RandomFivePostion();
            yield return new WaitForSeconds(5f);
        }
    }

    public Vector3 RandomFivePostion()
    {
        int newposition = Random.Range(0, 4);
        if (currentposition == newposition)
        {
            currentposition--;
            if (currentposition < 0)
            {
                currentposition = 0;
            }
        } else
        {
            currentposition = newposition;
        }
        
        return potentialpositions[currentposition];
    }
}