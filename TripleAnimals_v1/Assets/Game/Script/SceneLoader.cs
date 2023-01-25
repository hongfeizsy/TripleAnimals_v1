using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float timeToWait;
    int currentSceneIndex;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void LoadStartScreen() {
        SceneManager.LoadScene("StartScreen");
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

}
