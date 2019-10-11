using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

//Day Directional light FFF2A0
//Day Ambient light FFFFFF

//Night Directional light 460003
//Night Ambient light 898989


public class TMMAI : MonoBehaviour, Shootable
{
    //State 
    private int HP = 200;
    private NavMeshAgent TMM;
    private bool Dead;
    public AudioSource thisAudioSource;
    public AudioSource music;
    public Slider Hpbar;
    private int currentposition = 0;

    private Vector3[] potentialpositions = new Vector3[5];

    //Projectile 
    public GameObject ConeAttack;
    public GameObject ConeAttackB;
    public GameObject BurstAttack;
    public GameObject Hellsweep;
    public GameObject UksaMAttack;

    //Audio
    public AudioClip Masku;
    public AudioClip VryVry;
    public AudioClip MiirioKid;
    public AudioClip hellsweepsound;
    public AudioClip UksaM;
    public AudioClip Bye;

    public AudioClip ClericBeastMusic;
    private readonly float ProjectileLife = 1.3f;
    //Cache
    private Vector3 playerlocation;
    private bool inphase2 = false;

    //Phase 2 stuff
    public Material bloodskybox;
    public Light directionallight;

    void Start()
    {
        potentialpositions[0] = new Vector3(-33.68f, 5.38f, -26.8f);
        potentialpositions[1] = new Vector3(-35.33f, 5.38f, 27.59f);
        potentialpositions[2] = new Vector3(9.66f, 5.38f, -28.272f);
        potentialpositions[3] = new Vector3(11.02f, 5.38f, 26.35f);
        potentialpositions[4] = new Vector3(-12.28f, 5.38f, 0f);

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

    public void GetShot()
    {
        HP--;
        Hpbar.value = HP;
        CheckIfDead();

        if (HP < 100)
        {
            if (!inphase2)
            {
                StopCoroutine("Attack");
                StartCoroutine("AttackPhase2");
                StartCoroutine("Hellsweepcoroutine");
                RenderSettings.skybox = bloodskybox;
                inphase2 = true;
                directionallight.color = new Color(70,0,3);
                RenderSettings.ambientLight = new Color(137,137,137);
                music.clip = ClericBeastMusic;
                music.volume = 0.6f;
                music.Play();
            }
        }
    }

    private void CheckIfDead()
    {
        if (HP <= 0)
        {
            Dead = true;
            TMM.enabled = false;
            StopCoroutine("AttackPhase2");
            StopCoroutine("Hellsweepcoroutine");
            StopCoroutine("Wander");
            music.Stop();
            thisAudioSource.Stop();
            StartCoroutine("DieCoroutine");
        }
        else
        {
            //thisAudioSource.PlayOneShot(HurtSFX[Random.Range(0, HurtSFX.Length)]);
        }
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(1f);
        thisAudioSource.PlayOneShot(Bye);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }


    // Phase 1 Attacks

    IEnumerator Attack()
    {
        while (true)
        {
            int AttackNumb = Random.Range(1, 4);

            if (AttackNumb == 1)
            {
                StartCoroutine("Attack0");
                yield return new WaitForSeconds(3.5f);
            }
            else if (AttackNumb == 2)
            {
                StartCoroutine("Attack1");
                yield return new WaitForSeconds(3.9f);
            }
            else if (AttackNumb == 3)
            {
                StartCoroutine("Attack2");
                yield return new WaitForSeconds(3f);
            }
        }
    }

    IEnumerator Attack0()
    {
        thisAudioSource.PlayOneShot(Masku);
        yield return new WaitForSeconds(1f);
        GameObject CurrentAttack = Instantiate(ConeAttack, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }


    IEnumerator Attack1()
    {
        thisAudioSource.PlayOneShot(VryVry);
        yield return new WaitForSeconds(1.4f);
        GameObject CurrentAttack = Instantiate(ConeAttackB, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }

    IEnumerator Attack2()
    {
        thisAudioSource.PlayOneShot(MiirioKid);
        yield return new WaitForSeconds(0.9f);
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine("Attack2B");
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Attack2B()
    {
        GameObject CurrentAttack = Instantiate(BurstAttack, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }

    //
    //
    //Phase 2 Attack Coroutine
    //
    //

    IEnumerator AttackPhase2()
    {
        while (true)
        {
            int AttackNumb = Random.Range(1, 4);

            if (AttackNumb == 1)
            {
                StartCoroutine("P2Attack0");
                yield return new WaitForSeconds(2.5f);
            } else if (AttackNumb == 2)
            {
                StartCoroutine("Attack1");
                yield return new WaitForSeconds(3.5f);
            } else if (AttackNumb == 3)
            {
                StartCoroutine("uksaM");
                yield return new WaitForSeconds(3.5f);
            }
        }
    }

    IEnumerator uksaM()
    {
        thisAudioSource.PlayOneShot(UksaM);
        yield return new WaitForSeconds(0.9f);
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine("uksaMLaunch");
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator uksaMLaunch()
    {
        GameObject CurrentAttack = Instantiate(UksaMAttack, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }



    IEnumerator P2Attack0()
    {
        thisAudioSource.PlayOneShot(Masku);
        yield return new WaitForSeconds(0.9f);
        for (int i = 0; i < 5; i++)
        {
            StartCoroutine("P2AttackB");
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator P2AttackB()
    {
        GameObject CurrentAttack = Instantiate(ConeAttack, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }


    IEnumerator Hellsweepcoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            StartCoroutine("HellSweep");
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator HellSweep()
    {
        thisAudioSource.PlayOneShot(hellsweepsound);
        GameObject CurrentAttack = Instantiate(Hellsweep, transform.position + new Vector3(0, -9f, 0), transform.rotation);
        yield return new WaitForSeconds(ProjectileLife);
        Destroy(CurrentAttack);
    }




    //Walk around script
    IEnumerator Wander()
    {
        while (true)
        {
            TMM.destination = RandomFivePostion();
            yield return new WaitForSeconds(2.5f);
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
        }
        else
        {
            currentposition = newposition;
        }

        return potentialpositions[currentposition];
    }


}