using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject sceneButton;

    void Update()
    {
        if(transform.position.y < 610)
            transform.Translate(Vector2.up * 1);
        if (transform.position.y >= 610)
            sceneButton.SetActive(true);
    }
}
