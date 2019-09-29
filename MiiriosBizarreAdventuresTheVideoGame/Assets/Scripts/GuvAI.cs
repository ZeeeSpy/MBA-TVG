using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GuvAI : MonoBehaviour
{
    private NavMeshAgent ThisGuv;

    void Start()
    {
        ThisGuv = gameObject.GetComponent<NavMeshAgent>();
        ThisGuv.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        ThisGuv.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        ThisGuv.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(ThisGuv.velocity.normalized);
    }
}

