using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThisIsThePolice : MonoBehaviour
{
    public AudioClip PoliceClip;
    public AudioClip PhoneCall;
    private InteractScript scripttodisplaytext;
    public GameObject Guv;
    public AudioSource playeraudio;
    private JerseyCount count;
    public GameObject GetAwayStuff;

    private int guvspawnrate = 5;

    //Bools
    private bool phonecalldone = false;
    private bool getawaystarted = false;

    // Start is called before the first frame update
    void Start()
    {
        scripttodisplaytext = (InteractScript)FindObjectOfType(typeof(InteractScript));
        count = (JerseyCount)FindObjectOfType(typeof(JerseyCount));
        StartCoroutine("Police");
    }

    IEnumerator Police() {
        yield return new WaitForSeconds(15f);
        GetComponent<AudioSource>().PlayOneShot(PoliceClip);
        scripttodisplaytext.DiplayText("Oh shit, cops are already here. I need my getaway team");
        StartCoroutine("SpawnGuvs");
        yield return new WaitForSeconds(2f);
        playeraudio.PlayOneShot(PhoneCall);
        yield return new WaitForSeconds(7.5f);
        phonecalldone = true;
        scripttodisplaytext.DiplayText("My getaway team will only come if I get 10 Jerseys");
    }

    IEnumerator SpawnGuvs() {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, guvspawnrate));
            int spawnpos = Random.Range(0, 2);
            if (spawnpos == 0)
            {
                Instantiate(Guv, transform.position + new Vector3(-53, 0, -15), transform.rotation);
            } else
            {
                Instantiate(Guv, transform.position + new Vector3(0, 0, 15), transform.rotation);
            }
        }
    }

    IEnumerator GetAwayCountDown()
    {
        scripttodisplaytext.DiplayText("Got 10, let's call the Getaway driver");
        playeraudio.PlayOneShot(PhoneCall);
        yield return new WaitForSeconds(7.5f); 
        scripttodisplaytext.DiplayText("It'll take them a minuite to get here. Gotta hold out until then");
        yield return new WaitForSeconds(30f);
        GetAwayArrived();
    }

    private void GetAwayArrived()
    {
        GetAwayStuff.SetActive(true);
        scripttodisplaytext.DiplayText("I think I heard my getaway pull up just now. Lets get out of here");
    }

    private void Update()
    {
        if (phonecalldone && count.GetCount() >= 10)
        {
            if (!getawaystarted)
            {
                StartCoroutine("GetAwayCountDown");
                guvspawnrate = 3;
                getawaystarted = true;
            }
        }
    }

}
