using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenManager : MonoBehaviour
{
    public static bool isFireBallFlag;
    public static bool isIceFlag;
    public static bool isLunchBoxFlag;
    public static bool isSpearFlag;
    public static bool isTalkFlag;
    public static bool isHiddenCheck = false;

    public static int[] fireBall = new int[4];
    public static int[] ice = new int[4];
    public static int[] spear = new int[3];
    public static int[] lunchBox = new int[4];
    public static int[] talk = new int[5];

    bool isCreateFlag;

    public AudioClip[] invenSounds;
    AudioSource invenSE;

    public GameObject createMagicPanel;

    private void OnEnable()
    {
        invenSE = this.GetComponent<AudioSource>();

        invenSE.clip = invenSounds[1];
        invenSE.Play();
    }

    void Start()
    {
        isCreateFlag = true;
        createMagicPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && isCreateFlag == true) // 마법 조합창 on/off
        {
            createMagicPanel.SetActive(true);
            isCreateFlag = false;
        }
        else if(Input.GetKeyDown(KeyCode.C) && isCreateFlag == false)
        {
            createMagicPanel.SetActive(false);
            isCreateFlag = true;
        }

        if (isFireBallFlag && isIceFlag && isLunchBoxFlag && isSpearFlag && isTalkFlag == true) // 모든 마법 배웠을시 히든 맵 조건 체크
            isHiddenCheck = true;

        // 인벤토리에 각 마법 재료 오브젝트의 이름을 부여
        for (int i = 1; i < 4; i++)
            GameObject.Find("FireBall0" + i).GetComponent<Text>().text = fireBall[i].ToString();

        for (int i = 1; i < 4; i++)
            GameObject.Find("Ice0" + i).GetComponent<Text>().text = ice[i].ToString();

        for (int i = 1; i < 3; i++)
            GameObject.Find("Spear0" + i).GetComponent<Text>().text = spear[i].ToString();

        for (int i = 1; i < 4; i++)
            GameObject.Find("LunchBox0" + i).GetComponent<Text>().text = lunchBox[i].ToString();

        for (int i = 1; i < 5; i++)
            GameObject.Find("Talk0" + i).GetComponent<Text>().text = talk[i].ToString();
    }
}
