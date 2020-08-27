using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{
    private AsyncOperation sceneAsync;

    public void GoToScene(string sceneName, List<GameObject> objectToMove)
    {
        StartCoroutine(LoadScene(sceneName, objectToMove));
    }

    private IEnumerator LoadScene(string sceneName, List<GameObject> objectToMove)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        SceneManager.sceneLoaded += (newScene, mode) => { SceneManager.SetActiveScene(newScene); };



        Scene sceneToLoad = SceneManager.GetSceneByName(sceneName);
        foreach (GameObject obj in objectToMove) { SceneManager.MoveGameObjectToScene(obj, sceneToLoad); }
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}

