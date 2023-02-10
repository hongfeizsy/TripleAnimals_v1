using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float timeToWait;
    int currentSceneIndex;

    public void ExitGame() {
        Application.Quit();
    }

    public void WaitAndLoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(DelayedLoadScene(currentSceneIndex + 1));
    }

    private IEnumerator DelayedLoadScene(int sceneIndex)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(sceneIndex);
    }

    public void WaitAndLoadStartScene() {
        StartCoroutine(DelayedLoadScene(1));
    }

    public void LoadNextScene() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void WaitAndLoadCurrentScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(DelayLoadCurrentScene());
    }

    private IEnumerator DelayLoadCurrentScene() {
        yield return new WaitForSeconds(1f);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
