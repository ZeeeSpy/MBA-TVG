/*
 * Switch level on trigger enter. Level dictated by public variable set in editor.
 * 
 * Needs a loading screen so the game doesn't just hang for a few seconds on enter
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public string nextscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextscene);
        }
    }
}
