﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopCarScript : MonoBehaviour, Shootable
{
    private readonly int speed = 20;
    bool caughtup = false;
    private Transform player;
    private int range;
    private int HP = 20;
    private int position;
    private CopCarSpawner spawner;
    public GameObject attack;
    private readonly int force = 50;
    private Vector3 playerlocation;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        range = Random.Range(15, 36);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!caughtup)
        {
            transform.Translate(transform.forward * 75 * Time.deltaTime);
            if ((player.position - transform.position).magnitude < range)
            {
                caughtup = true;
                StartCoroutine("Attack");
            }
        }
        else
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }

        playerlocation = player.position;
    }

    public void SetUpCar(int pos,CopCarSpawner incspawner)
    {
        position = pos;
        spawner = incspawner;
    }

    public void GetShot()
    {
        if (caughtup)
        {
            HP--;

            if (HP <= 0)
            {
                spawner.ReleasePosition(position);
                Destroy(transform.parent.gameObject);
            }
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
            {
                yield return new WaitForSeconds(0.2f);
                GameObject CurrentAttack = Instantiate(attack, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
                CurrentAttack.GetComponent<Rigidbody>().AddForce((playerlocation - transform.position + new Vector3(0,0,20)) * force);
                //Play audio?
                yield return new WaitForSeconds(2);
                Destroy(CurrentAttack);
            }
        }
    }

}
