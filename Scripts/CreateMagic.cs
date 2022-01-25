using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMagic : MonoBehaviour
{
    public AudioClip[] createrMagicSounds;
    AudioSource createrMagicSE;
    public GameObject txtBox;

    int i;

    void Start()
    {
        createrMagicSE = this.GetComponent<AudioSource>();
    }

    public void MagicCheck()
    {//마법 조합 기능
        //각 마법 재료가 알맞게 들어왔는지 체크
        if(GameObject.Find("Material01Image").GetComponent<Image>().sprite.name == "Fire_Ball_001"
            && GameObject.Find("Material02Image").GetComponent<Image>().sprite.name == "Fire_Ball_002"
            && GameObject.Find("Material03Image").GetComponent<Image>().sprite.name == "Fire_Ball_003")
        {
            InvenManager.isFireBallFlag = true;//파이어 볼 마법 플래그 on
            createrMagicSE.clip = createrMagicSounds[0];//마법 조합 성공 Sound Effect 오디오 클립
            createrMagicSE.Play();
            txtBox.SetActive(true);//텍스트 박스 활성화
            GameObject.Find("MessageBoxText").GetComponent<Text>().text =
                "「파이어 볼」이 완성됐습니다";//텍스트 박스 내용
            for(i = 1; i <= 4; i++)//재료 선택화면 초기화
                GameObject.Find("Material0" + i + "Image").GetComponent<Image>().sprite = null;
            
        }
        else if(GameObject.Find("Material01Image").GetComponent<Image>().sprite.name == "Ice_001"
            && GameObject.Find("Material02Image").GetComponent<Image>().sprite.name == "Ice_002"
            && GameObject.Find("Material03Image").GetComponent<Image>().sprite.name == "Ice_003")
        {
            InvenManager.isIceFlag = true;
            createrMagicSE.clip = createrMagicSounds[0];
            createrMagicSE.Play();
            txtBox.SetActive(true);
            GameObject.Find("MessageBoxText").GetComponent<Text>().text =
                "「아이스」가 완성됐습니다";
            for (i = 1; i <= 4; i++)
                GameObject.Find("Material0" + i + "Image").GetComponent<Image>().sprite = null;
        }
        else if (GameObject.Find("Material01Image").GetComponent<Image>().sprite.name == "Lunch_Box_001"
            && GameObject.Find("Material02Image").GetComponent<Image>().sprite.name == "Lunch_Box_002"
            && GameObject.Find("Material03Image").GetComponent<Image>().sprite.name == "Lunch_Box_003")
        {
            InvenManager.isLunchBoxFlag = true;
            createrMagicSE.clip = createrMagicSounds[0];
            createrMagicSE.Play();
            txtBox.SetActive(true);
            GameObject.Find("MessageBoxText").GetComponent<Text>().text =
                "「도시락 창조」가 완성됐습니다";
            for (i = 1; i <= 4; i++)
                GameObject.Find("Material0" + i + "Image").GetComponent<Image>().sprite = null;
        }
        else if (GameObject.Find("Material01Image").GetComponent<Image>().sprite.name == "Spear_001"
            && GameObject.Find("Material02Image").GetComponent<Image>().sprite.name == "Spear_002")
        {
            InvenManager.isSpearFlag = true;
            createrMagicSE.clip = createrMagicSounds[0];
            createrMagicSE.Play();
            txtBox.SetActive(true);
            GameObject.Find("MessageBoxText").GetComponent<Text>().text =
                "「스피어」가 완성됐습니다";
            for (i = 1; i <= 4; i++)
                GameObject.Find("Material0" + i + "Image").GetComponent<Image>().sprite = null;
        }
        else if (GameObject.Find("Material01Image").GetComponent<Image>().sprite.name == "Talk_001"
            && GameObject.Find("Material02Image").GetComponent<Image>().sprite.name == "Talk_002"
            && GameObject.Find("Material03Image").GetComponent<Image>().sprite.name == "Talk_003"
            && GameObject.Find("Material04Image").GetComponent<Image>().sprite.name == "Talk_004")
        {
            InvenManager.isTalkFlag = true;
            createrMagicSE.clip = createrMagicSounds[0];
            createrMagicSE.Play();
            txtBox.SetActive(true);
            GameObject.Find("MessageBoxText").GetComponent<Text>().text =
                "「생물 & 무생물과 대화」가 완성됐습니다";
            for (i = 1; i <= 4; i++)
                GameObject.Find("Material0" + i + "Image").GetComponent<Image>().sprite = null;
        }
        else
        {//알맞지 않은 조합 방법으로 조합시 실패 구현
            createrMagicSE.clip = createrMagicSounds[1];
            createrMagicSE.Play();
            txtBox.SetActive(true);
            GameObject.Find("MessageBoxText").GetComponent<Text>().text =
                "조합에 실패 했습니다";
            for (i = 1; i <= 4; i++)
                GameObject.Find("Material0" + i + "Image").GetComponent<Image>().sprite = null;
        }
    }
}
