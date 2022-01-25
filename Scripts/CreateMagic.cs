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
    {//���� ���� ���
        //�� ���� ��ᰡ �˸°� ���Դ��� üũ
        if(GameObject.Find("Material01Image").GetComponent<Image>().sprite.name == "Fire_Ball_001"
            && GameObject.Find("Material02Image").GetComponent<Image>().sprite.name == "Fire_Ball_002"
            && GameObject.Find("Material03Image").GetComponent<Image>().sprite.name == "Fire_Ball_003")
        {
            InvenManager.isFireBallFlag = true;//���̾� �� ���� �÷��� on
            createrMagicSE.clip = createrMagicSounds[0];//���� ���� ���� Sound Effect ����� Ŭ��
            createrMagicSE.Play();
            txtBox.SetActive(true);//�ؽ�Ʈ �ڽ� Ȱ��ȭ
            GameObject.Find("MessageBoxText").GetComponent<Text>().text =
                "�����̾� ������ �ϼ��ƽ��ϴ�";//�ؽ�Ʈ �ڽ� ����
            for(i = 1; i <= 4; i++)//��� ����ȭ�� �ʱ�ȭ
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
                "�����̽����� �ϼ��ƽ��ϴ�";
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
                "�����ö� â������ �ϼ��ƽ��ϴ�";
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
                "�����Ǿ�� �ϼ��ƽ��ϴ�";
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
                "������ & �������� ��ȭ���� �ϼ��ƽ��ϴ�";
            for (i = 1; i <= 4; i++)
                GameObject.Find("Material0" + i + "Image").GetComponent<Image>().sprite = null;
        }
        else
        {//�˸��� ���� ���� ������� ���ս� ���� ����
            createrMagicSE.clip = createrMagicSounds[1];
            createrMagicSE.Play();
            txtBox.SetActive(true);
            GameObject.Find("MessageBoxText").GetComponent<Text>().text =
                "���տ� ���� �߽��ϴ�";
            for (i = 1; i <= 4; i++)
                GameObject.Find("Material0" + i + "Image").GetComponent<Image>().sprite = null;
        }
    }
}
