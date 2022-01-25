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
    {//플레이어와의 거리를 계산하여 distance 변수에 저장
        distance = Vector3.Distance(transform.position, player.transform.position);


        //각 1/3인칭 시점별로 ?표시가 카메라를 자연스레 바라보는 기능
        if (CocoMove.isViewFlag)
            look.transform.LookAt(GameObject.Find("Main Camera").GetComponent<Camera>().transform);
        else
            look.transform.LookAt(GameObject.Find("Head").GetComponent<Camera>().transform);

        //플레이어와 마법 재료 오브젝트와의 거리가 5이하일때 ?표시 활성화
        if (distance <= 5.0f)
            look.SetActive(true);
        else
            look.SetActive(false);

    }

    void OnMouseDown()
    {//마법 재료 클릭시 이벤트 발생
        panel.SetActive(true);//어떤 마법 재료를 획득했는지 보여주는 패널 활성화

        //각 오브젝트의 수량은 InvenManager스크립트내의 있는 배열에서 관리
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

        successSE.Play();//획득 성공 Sound Effect 재생
        StartCoroutine(PanelDisappear());//패널을 2초뒤에 비활성화 시키는 Coroutine
    }

    IEnumerator PanelDisappear()
    {
        yield return new WaitForSeconds(2);
        panel.SetActive(false);
    }
}
