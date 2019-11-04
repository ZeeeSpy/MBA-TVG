/*
 *  Script that each possible answer has. used so that game knows what answer the player selected
 */
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
