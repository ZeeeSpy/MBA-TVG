using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreggoLeeAI : MonoBehaviour
{
    public Level1TextStuff texttoscreen;
    public Sprite PreggoLeeSprite;

    public GameObject Gun;
    public GameObject Crosshair;
    public GameObject BulletSpawner;
    public GameObject Spinner;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LeeIntroMonologue");
    }


    IEnumerator LeeIntroMonologue()
    {
        yield return new WaitForSeconds(0);
        texttoscreen.showtext("Been waiting long?");

        yield return new WaitForSeconds(2);
        texttoscreen.showtext("Why do you hate me?");

        yield return new WaitForSeconds(2);
        texttoscreen.showtext("Why do you pick me if you hate me?");

        yield return new WaitForSeconds(3);
        texttoscreen.showtext("Even when we win you tell me to shut up");

        yield return new WaitForSeconds(4);
        texttoscreen.showtext("Worse still, you defiled me. You turned me into THIS. I won't give you a chance, prepare to die");

        Gun.SetActive(false);
        Crosshair.SetActive(false);
        BulletSpawner.SetActive(false);

        yield return new WaitForSeconds(5);
        texttoscreen.showtext("");
        GetComponent<SpriteRenderer>().sprite = PreggoLeeSprite;
        transform.localScale = new Vector3(10, 10, 1);
        yield return new WaitForSeconds(2);
        Spinner.SetActive(true);
        StartCoroutine("Survive");
    }

    IEnumerator SurviveTimer()
    {
    yield return new WaitForSeconds(60);
    }

    IEnumerator Survive()
    {
        Coroutine timer = StartCoroutine(SurviveTimer());
        while (true)
        {
            //survive loop
        }
    }
}
