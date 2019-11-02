using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingScript : MonoBehaviour, Shootable
{
    public AudioClip[] Music = new AudioClip[6];
    public AudioClip[] TTS = new AudioClip[15];

    public AudioSource MusicSource;
    public AudioSource Speech;

    private int TTSCOUNT = 0;
    private int currentquestion = 0;

    bool ReadyStart = false;
    bool hasbeenshot = false;
    bool threehead = false;

    bool timeout = false;



    public GameObject question1;
    public GameObject question2;
    public GameObject question3;
    public GameObject question4;
    public GameObject question5;
    public GameObject question6;
    public GameObject question7;
    public GameObject question8;
    public GameObject question9;
    public GameObject question10;

    public void Awake()
    {
        StartCoroutine("Intro");
    }

    IEnumerator Intro()
    {
        Speech.PlayOneShot(TTS[TTSCOUNT]);
        yield return new WaitForSeconds(TTS[TTSCOUNT].length);
        TTSCOUNT++;
        Speech.PlayOneShot(TTS[TTSCOUNT]);
        yield return new WaitForSeconds(TTS[TTSCOUNT].length);
        TTSCOUNT++;
        ReadyStart = true;
    }

    public void GetShot()
    {
        if (ReadyStart)
        {
            if (!hasbeenshot)
            {
                hasbeenshot = true;
                StartCoroutine(TTSQuestionRoutine(0));
                return;
            }

            if (hasbeenshot && !timeout && !threehead)
            {
                threehead = true;
                Speech.PlayOneShot(TTS[2]);
            }
        }
    }

    IEnumerator TTSQuestionRoutine(int rightwrong)
    {
        if (currentquestion == 0)
        {
            yield return new WaitForSeconds(3);
            timeout = true;
            TTSCOUNT = 3;
            Speech.Stop();
            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;
            MusicSource.Stop();
            MusicSource.PlayOneShot(Music[2]);
            yield return new WaitForSeconds(3);
            MusicSource.PlayOneShot(Music[3]);
            Speech.PlayOneShot(TTS[TTSCOUNT]);
            question1.SetActive(true);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;
        }

        else if (currentquestion == 1)
        {
            question1.SetActive(false);
            yield return new WaitForSeconds(4);
            if (rightwrong == 1)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[4]);
                Speech.PlayOneShot(TTS[5]);
                yield return new WaitForSeconds(TTS[5].length);
            }
            else
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[4]);
                Speech.PlayOneShot(TTS[6]);
                yield return new WaitForSeconds(TTS[6].length);
            }
            TTSCOUNT = 7;

            MusicSource.Stop();
            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;

            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;

            MusicSource.PlayOneShot(Music[2]);
            yield return new WaitForSeconds(3);
            MusicSource.PlayOneShot(Music[3]);
            Speech.PlayOneShot(TTS[TTSCOUNT]);
            TTSCOUNT++;
            question2.SetActive(true);
            yield return new WaitForSeconds(7);
            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
        }

        else if (currentquestion == 2)
        {
            question2.SetActive(false);
            yield return new WaitForSeconds(4);
            if (rightwrong == 1)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[11]);
                yield return new WaitForSeconds(TTS[11].length);
            }
            else
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[12]);
                yield return new WaitForSeconds(TTS[12].length);
            }
            TTSCOUNT = 13;

            //Ready up question into question music
            MusicSource.PlayOneShot(Music[2]);
            yield return new WaitForSeconds(3);
            MusicSource.PlayOneShot(Music[3]);
            question3.SetActive(true);

            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;

            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;

            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;
        }

        else if (currentquestion == 3)
        {
            question3.SetActive(false);
            yield return new WaitForSeconds(4);
            if (rightwrong == 1)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[4]);
                Speech.PlayOneShot(TTS[16]);
                yield return new WaitForSeconds(TTS[16].length);
            } else if (rightwrong == 2)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[17]);
                yield return new WaitForSeconds(TTS[17].length);
            } else if (rightwrong == 3)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[18]);
                yield return new WaitForSeconds(TTS[18].length);
            } else if (rightwrong == 4)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[19]);
                yield return new WaitForSeconds(TTS[19].length);
            }
            TTSCOUNT = 20;
            MusicSource.Stop();

            //Ready up question into question music
            MusicSource.PlayOneShot(Music[2]);
            yield return new WaitForSeconds(3);
            MusicSource.PlayOneShot(Music[3]);
            question4.SetActive(true);

            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT = 14;
            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;
            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
        }

        else if (currentquestion == 4)
        {
            question4.SetActive(false);
            yield return new WaitForSeconds(4);
            if (rightwrong == 1)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[21]);
                yield return new WaitForSeconds(TTS[21].length);
            }
            else if (rightwrong == 2)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[22]);
                yield return new WaitForSeconds(TTS[22].length);
            }
            else if (rightwrong == 3)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[23]);
                yield return new WaitForSeconds(TTS[23].length);
            }
            else if (rightwrong == 4)
            {
                MusicSource.Stop();
                MusicSource.PlayOneShot(Music[5]);
                Speech.PlayOneShot(TTS[24]);
                yield return new WaitForSeconds(TTS[24].length);
            }
            MusicSource.Stop();

            //Ready up question into question music
            MusicSource.PlayOneShot(Music[2]);
            yield return new WaitForSeconds(3);
            MusicSource.PlayOneShot(Music[3]);

            //SET NEXT QUESTION 
            question5.SetActive(true);
            TTSCOUNT = 25;
            Speech.PlayOneShot(TTS[TTSCOUNT]);
            yield return new WaitForSeconds(TTS[TTSCOUNT].length);
            TTSCOUNT++;

        }
    }

    public void SelectAnswer(int incanswer)
    {
        StopCoroutine(TTSQuestionRoutine(-1));
        Speech.Stop();
        MusicSource.Stop();
        MusicSource.PlayOneShot(Music[1]);
        currentquestion++;
        StartCoroutine(TTSQuestionRoutine(incanswer));
    }
}
//5 is correct 4 is wrong