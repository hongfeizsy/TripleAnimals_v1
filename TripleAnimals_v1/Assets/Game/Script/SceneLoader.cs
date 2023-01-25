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
        StartCoroutine(DelayedLoadScene(0));
    }

}
