using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingsSceneManager : MonoBehaviour
{
    public static LoadingsSceneManager instance;
    public GameObject loadingScreen;

    private void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive);
    }

    List<AsyncOperation> sceneLoading = new List<AsyncOperation>();

    public void LoadGame()
    {
        loadingScreen.gameObject.SetActive(true);

        // all scenes it needs to load or unload
        sceneLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.TITLE_SCREEN));
        sceneLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.MAP, LoadSceneMode.Additive));
        sceneLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.ENDCUTSCENE));

        StartCoroutine(GetSceneLoadProgress());
    }

    public IEnumerator GetSceneLoadProgress()
    {
        // scene changer with loading screen
        for (int i = 0; i < sceneLoading.Count; i++)
        {
            while (!sceneLoading[i].isDone)
            {
                yield return null;
            }
        }

        loadingScreen.gameObject.SetActive(false);
    }
}
