using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScrollScript : MonoBehaviour
{
    private void Start()
    {
        TextAsset mytxtData = (TextAsset)Resources.Load("CreditsText");
        GetComponent<Text>().text = mytxtData.text;
    }
    void Update()
    {
        transform.Translate(0, 1, 0);  
    }
}
