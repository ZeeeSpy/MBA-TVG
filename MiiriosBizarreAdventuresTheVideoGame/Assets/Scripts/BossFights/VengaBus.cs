using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VengaBus : MonoBehaviour, Shootable
{
    public Transform player;
    private Rigidbody thisbus;
    private bool FindingPlayer = false;
    private int force = 9000;
    private int HP = 200;
    //Max Hp 200
    private int phase = 1;
    private float phasewait = 3f;
    public Slider Hpbar;
    bool charging = false;
    public BoxCollider hurtbox;

    private void Start()
    {
        thisbus = gameObject.GetComponent<Rigidbody>();
        StartCoroutine("BossLoop");
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
        phase = 2;
        phasewait = 1.5f;
        Debug.Log("Phase 2");
        //Add saws?
    }

    public void GetShot()
    {
        HP = HP - 1;
        Hpbar.value = HP;

        if (HP < 150)
        {
            Phase2();
        }

        if (HP <= 0)
        {
            StopCoroutine("BossLoop");
            Debug.Log("Boss Defeated");
        }
    }
}

