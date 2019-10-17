using System.Collections;
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
            }
        }
        else
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
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
}
