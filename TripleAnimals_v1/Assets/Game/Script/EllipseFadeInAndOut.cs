using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseFadeInAndOut : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;

    public void TriggerEllipseFadeInAnimation() {
        GetComponent<Animator>().SetTrigger("FadeIn");
    }

    public void LoadNextScene() {
        sceneLoader.LoadNextScene();
    }
}
