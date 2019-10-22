using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopCarScript : MonoBehaviour, Shootable
{
    bool caughtup = false;
    private Transform player;
    private int range;
    private int HP = 20;
    private int position;
    private CopCarSpawner spawner;
    public GameObject attack;
    private readonly int force = 50;
    private Vector3 playerlocation;
    public GameObject particles;

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
            transform.Translate(transform.forward * 50 * Time.deltaTime);
            if ((player.position - transform.position).magnitude < range)
            {
                caughtup = true;
                StartCoroutine("Attack");
            }
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

            if (HP <= 10)
            {
                particles.SetActive(true);
            }
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            {
                GameObject CurrentAttack = Instantiate(attack, transform.position + new Vector3(0, 1f, 0), transform.rotation);
                CurrentAttack.GetComponent<Rigidbody>().AddForce((playerlocation - transform.position) * force);
            }
        }
    }

}
