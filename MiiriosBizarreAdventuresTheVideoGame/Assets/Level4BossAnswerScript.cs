using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4BossAnswerScript : MonoBehaviour, Shootable
{
    public bool correct = true;
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
