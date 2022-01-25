using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public GameObject Stage02Button;
    public GameObject Stage03Button;
    public GameObject sealButton;
    public GameObject hiddenStageButton;
    public GameObject inven;

    bool isInvenFlag;

    public static List<int> keyCount = new List<int>();
    public static bool hiddenKey = false;

    // Start is called before the first frame update
    void Start()
    {
        isInvenFlag = false;
        Cursor.lockState = CursorLockMode.None;

        //테스트용
        //keyCount.Add(1);
        //keyCount.Add(2);
        //keyCount.Add(3);
        //hiddenKey = true;
        //InvenManager.isHiddenCheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (InvenManager.isHiddenCheck)
            hiddenStageButton.SetActive(true);

        if (keyCount.Contains(1))
            Stage02Button.SetActive(true);

        if (keyCount.Contains(2))
            Stage03Button.SetActive(true);

        if (keyCount.Contains(1) && keyCount.Contains(2) && keyCount.Contains(3))
            sealButton.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
            if(isInvenFlag == false)
            {
                GameObject.Find("StageSelectBGM").GetComponent<AudioSource>().Pause();
                inven.SetActive(true);
                isInvenFlag = true;
            }
            else if(isInvenFlag == true)
            {
                GameObject.Find("StageSelectBGM").GetComponent<AudioSource>().Play();
                inven.SetActive(false);
                isInvenFlag = false;
            }

    }
}
