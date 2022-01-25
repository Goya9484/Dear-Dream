using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTalk : MonoBehaviour
{//���� ������������ npc�� ��ȭ�� ��ũ��Ʈ

    public GameObject player;
    public GameObject look;
    public GameObject panel;

    float distance;

    // Update is called once per frame
    void Update()
    {
        //�÷��̾�� npc ������ �Ÿ��� ����ϴ� �Լ�
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 5.0f)
            look.SetActive(true);
        else
            look.SetActive(false);
    }

    public void OnMouseDown()
    {//��ȭ �г� on
        panel.SetActive(true);
    }
}
