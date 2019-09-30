using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private int HP = 92; //Size of rank array * 2 (it's close it 100 so w/e)
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
        UpdateRank();
    }

    private void UpdateRank()
    {
        RankUIImage.sprite = RankArray[(HP/2)-1];
    }
}
