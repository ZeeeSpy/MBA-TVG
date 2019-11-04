/*
 *  Script used to controll cop cars during level 3 boss fight
 *  
 *  Cop car spawns in, moves towards player, once its close enough it stops and starts shooting
 *  when it dies it informs the cop car spawner that its position is free and another cop car may be spawned
 *  the stopping distance is randomised to remove unifomity in the cop car placements.
 *  
 *  May have an ongoing issue with shooting at the player. not easily replicable but I think it's fixed
 */

using System.Collections;
using UnityEngine;

public class CopCarScript : MonoBehaviour, Shootable
{
    bool caughtup = false;
    private Transform player;
    private int range;
    private int HP = 10;
    private int position;
    private CopCarSpawner spawner;
    public GameObject attack;
    private readonly int force = 75;
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

            if (HP <= 5)
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
                CurrentAttack.GetComponent<Rigidbody>().AddForce((player.position - transform.position) * force);
            }
        }
    }

}
