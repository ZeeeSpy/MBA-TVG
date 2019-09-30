using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GuvAI : MonoBehaviour, Shootable
{
    private int HP = 3;
    private NavMeshAgent ThisGuv;
    private bool Dead;
    private bool FallOver = false;

    void Start()
    {
        ThisGuv = gameObject.GetComponent<NavMeshAgent>();
        ThisGuv.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        ThisGuv.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dead)
        {
            ThisGuv.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        } if (Dead)
        {
            
        }
    }

    private void LateUpdate()
    {
        if (!Dead)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
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
        }
    }

    private void Die()
    {
        if (!FallOver)
        {
            transform.position = new Vector3(transform.position.x, 0.51f, transform.position.z);
            transform.Rotate(0, 0, 90);
            FallOver = true;
        }
    }

}

//y 0.51
//rotation z 90