using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider loadingBar;
    public GameObject closeScene;

    public float timer = 2.0f;

    public float scale;

    private void Update()
    {
        Time.timeScale = scale;
    }

    public void PlayGame(int levelIndex)
    {
        WaitForSceneSwitch(levelIndex);  
    }

    public void WaitForSceneSwitch(int levelIndex)
    {
        closeScene.SetActive(true);
 /*        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("YourAnimationName"))
         {

         }*/
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return null;
        }

    }
}
