using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonationScript : MonoBehaviour
{
    public Text Subscriber;
    public Text DonationText;
    public GameObject DonationGameObject;

    public AudioClip donationmessage;

    private AudioSource AS;
    public AudioClip DonationClip;
    private const string SubTextA = "<b> <3 <3 <3 <color=#32C3A6>";
    private const string SubTextB= "</color> donated <color=#32C3A6> £";
    private const string SubTextC = "</color></b>";

    //Can't be bothered to read from a file 
    private string[] usernames = new string[] 
    { "ZeeeSpy","BujinFujin","2BarYoshiii","RealYatsu"};

    private const string MAINMAN_DONATION = "mainman_donation_happened";

    void Start()
    {
        AS = GetComponent<AudioSource>();
        Subscriber.text = "";
        DonationText.text = "";
        if (!PlayerPrefs.HasKey(MAINMAN_DONATION))
        {
            StartCoroutine("FirstDono");
        }
    }

    IEnumerator FirstDono()
    {
        PlayerPrefs.SetInt(MAINMAN_DONATION, 1);
        yield return new WaitForSeconds(Random.Range(15,25));
        Subscriber.text = SubTextA + "TheMainManSwe" + SubTextB + "7.50" + SubTextC;
        DonationText.text = "You didn't show up for your coaching session this week, here's your £75 back";
        DonationGameObject.SetActive(true);
        AS.PlayOneShot(DonationClip);
        yield return new WaitForSeconds(DonationClip.length);
        AS.PlayOneShot(donationmessage);
        yield return new WaitForSeconds(donationmessage.length + 1f);
        ClearText();
        DonationGameObject.SetActive(false);
    }

    IEnumerator DonationTest()
    {
        yield return new WaitForSeconds(2.5f);
        DonationGameObject.SetActive(true);
        GenerateText();
        yield return new WaitForSeconds(10);
        ClearText();
    }

    private void GenerateText()
    {
        Subscriber.text = SubTextA + "USERNAME" + SubTextB + "5.00" + SubTextC;
        DonationText.text = "This is a test donation";
        DonationGameObject.SetActive(true);
        AS.PlayOneShot(DonationClip);
    }

    private void ClearText()
    {
        Subscriber.text = "";
        DonationText.text = "";
        DonationGameObject.SetActive(false);
    }
}
