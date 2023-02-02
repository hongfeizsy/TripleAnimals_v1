using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllipseFadeIn : MonoBehaviour
{
    [SerializeField] GameObject canvasObject;

    public void ActiveEllipseAnimation() {
        canvasObject.SetActive(true);
    }
}