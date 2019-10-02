using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int HP = 45;
    public Image RankUIImage;
    private Sprite[] RankArray;

    private void Awake()
    {
        RankArray = Resources.LoadAll<Sprite>("Ranks/Ranks");
        UpdateRank();
    }

    public void Damage(int d)
    {
        HP = HP - d;
        
        if (HP <= 0)
        {
            Debug.Log("You Died");
        } else
        {
            UpdateRank();
        }
    }

    private void UpdateRank()
    {
        RankUIImage.sprite = RankArray[HP];
    }
}
