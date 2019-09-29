using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Animator gunanimator;
    public GameObject bullet;
    public int force;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            gunanimator.Play("Shoot");
            Debug.Log("Bang");
            StartCoroutine(BulletScript());
            BulletScript();
            

        }
    }

    IEnumerator BulletScript()
    {
        GameObject Currentbullet = Instantiate(bullet, transform.position, transform.rotation);
        Currentbullet.GetComponent<Rigidbody>().AddForce((transform.forward *force));

        yield return new WaitForSeconds(2);
        Destroy(Currentbullet);
    }
}
