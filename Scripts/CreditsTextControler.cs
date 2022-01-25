using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTextControler : MonoBehaviour
{//크레딧 씬의 텍스트 자동 스크롤 효과 스크립트

    public GameObject sceneButton;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 2050)
            transform.Translate(Vector2.up * 1);
        if (transform.position.y >= 2050)
            sceneButton.SetActive(true);
    }
}
