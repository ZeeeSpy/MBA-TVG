using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4BossAnswerScript : MonoBehaviour, Shootable
{
    public int correct = 1;
    private KingScript TheKingScript;
    public QuestionParentScript TPS;

    void Start()
    {
        TheKingScript = FindObjectOfType<KingScript>();
    }

    public void GetShot()
    {
        TheKingScript.SelectAnswer(correct);
        TPS.DisableColliders();
    }

}
