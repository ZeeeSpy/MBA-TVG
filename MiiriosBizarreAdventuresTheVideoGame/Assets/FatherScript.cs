using System.Collections;
using UnityEngine;

public class FatherScript : MonoBehaviour
{
    public GameObject player;
    public GameObject PreggoLee;

    private Vector3 MidPosition;

    private bool gotthere = false;

    public PlayerScript playerscript;

    private AudioSource AS;
    public AudioClip[] Voicelines = new AudioClip[2];


    // Start is called before the first frame update
    void Start()
    {
        //calculate position between player and lee
        MidPosition = new Vector3((player.transform.position.x+PreggoLee.transform.position.x)/2, 1.3f, (player.transform.position.z + PreggoLee.transform.position.z) / 2);

        AS = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if (!gotthere)
        {
            float step = 50 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, MidPosition, step);
            if (Vector3.Distance(transform.position, MidPosition) < 0.001f)
            {
                gotthere = true;
                StartCoroutine(FatherSpeech());
            }
        }
    }

    IEnumerator FatherSpeech()
    {
        int counter = 0;
        AS.PlayOneShot(Voicelines[counter]);
        yield return new WaitForSeconds(Voicelines[counter].length);
        counter++;
        playerscript.FullHeal();
        AS.PlayOneShot(Voicelines[counter]);
        yield return new WaitForSeconds(Voicelines[counter].length);
        Destroy(gameObject);
    }
}
