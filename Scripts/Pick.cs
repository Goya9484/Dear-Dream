using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pick : MonoBehaviour
{
    public GameObject player;
    public GameObject look;
    public GameObject panel;
    public Sprite material;

    AudioSource successSE;

    float distance;
    int i;

    void Start()
    {
        successSE = GetComponent<AudioSource>();

    }

    void Update()
    {//�÷��̾���� �Ÿ��� ����Ͽ� distance ������ ����
        distance = Vector3.Distance(transform.position, player.transform.position);


        //�� 1/3��Ī �������� ?ǥ�ð� ī�޶� �ڿ����� �ٶ󺸴� ���
        if (CocoMove.isViewFlag)
            look.transform.LookAt(GameObject.Find("Main Camera").GetComponent<Camera>().transform);
        else
            look.transform.LookAt(GameObject.Find("Head").GetComponent<Camera>().transform);

        //�÷��̾�� ���� ��� ������Ʈ���� �Ÿ��� 5�����϶� ?ǥ�� Ȱ��ȭ
        if (distance <= 5.0f)
            look.SetActive(true);
        else
            look.SetActive(false);

    }

    void OnMouseDown()
    {//���� ��� Ŭ���� �̺�Ʈ �߻�
        panel.SetActive(true);//� ���� ��Ḧ ȹ���ߴ��� �����ִ� �г� Ȱ��ȭ

        //�� ������Ʈ�� ������ InvenManager��ũ��Ʈ���� �ִ� �迭���� ����
        for (i = 1; i < 4; i++)
            if (material.name == "Fire_Ball_00" + i)
                InvenManager.fireBall[i] += 1;

        for (i = 1; i < 4; i++)
            if (material.name == "Ice_00" + i)
                InvenManager.ice[i] += 1;

        for (i = 1; i < 4; i++)
            if (material.name == "Lunch_Box_00" + i)
                InvenManager.lunchBox[i] += 1;

        for (i = 1; i < 3; i++)
            if (material.name == "Spear_00" + i)
                InvenManager.spear[i] += 1;

        for (i = 1; i < 5; i++)
            if (material.name == "Talk_00" + i)
                InvenManager.talk[i] += 1;

        successSE.Play();//ȹ�� ���� Sound Effect ���
        StartCoroutine(PanelDisappear());//�г��� 2�ʵڿ� ��Ȱ��ȭ ��Ű�� Coroutine
    }

    IEnumerator PanelDisappear()
    {
        yield return new WaitForSeconds(2);
        panel.SetActive(false);
    }
}
