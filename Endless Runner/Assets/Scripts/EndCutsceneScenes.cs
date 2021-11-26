using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutsceneScenes : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("First cutscene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
