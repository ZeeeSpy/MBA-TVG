using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JerseyCount : MonoBehaviour
{
    private Text thistext;
    private string denominator = "/10";
    private int currentcount = 0;

    private void Awake()
    {
        thistext = GetComponent<Text>();
        UpdateDisplay();
    }
    public void AddShirt()
    {
        currentcount++;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        thistext.text = (currentcount.ToString() + denominator);
    }

    public int GetCount()
    {
        return currentcount;
    }
}
