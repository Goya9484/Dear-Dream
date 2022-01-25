using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTalk : MonoBehaviour
{//히든 스테이지에서 npc와 대화용 스크립트

    public GameObject player;
    public GameObject look;
    public GameObject panel;

    float distance;

    // Update is called once per frame
    void Update()
    {
        //플레이어와 npc 사이의 거리를 계산하는 함수
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 5.0f)
            look.SetActive(true);
        else
            look.SetActive(false);
    }

    public void OnMouseDown()
    {//대화 패널 on
        panel.SetActive(true);
    }
}
