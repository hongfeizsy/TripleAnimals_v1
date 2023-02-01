using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingImage : MonoBehaviour
{
    float currentTime;

    private void Start() {
        currentTime = 0f;
    }

    private void Update() {
        if (currentTime >= 3f) {
            GetComponent<Animator>().SetTrigger("BlockIn");
        }
        currentTime += Time.deltaTime;
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
