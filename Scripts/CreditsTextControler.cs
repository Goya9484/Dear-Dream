using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTextControler : MonoBehaviour
{//ũ���� ���� �ؽ�Ʈ �ڵ� ��ũ�� ȿ�� ��ũ��Ʈ

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
