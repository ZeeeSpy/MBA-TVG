using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScrollScript : MonoBehaviour
{
    private void Start()
    {
        TextAsset mytxtData = (TextAsset)Resources.Load("CreditsText");
        GetComponent<Text>().text = mytxtData.text;
        PlayerPrefs.SetInt("gamebeatenplayerprof", 1);
    }

    void Update()
    {
        transform.Translate(0, 1, 0);  

        if (transform.position.y > 5500)
        {
           SceneManager.LoadScene("MainMenu");
        }
    }
}
