using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastTalk : MonoBehaviour
{
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    public GameObject txt4;
    public GameObject txt5;
    public GameObject txt6;
    public GameObject txt7;

    private void Start()
    {
        txt2.SetActive(false);
        txt3.SetActive(false);
        txt4.SetActive(false);
        txt5.SetActive(false);
        txt6.SetActive(false);
        txt7.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (txt1.activeSelf == true)
            {
                txt2.SetActive(true);
                txt1.SetActive(false);
            }
            else if (txt2.activeSelf == true)
            {
                txt3.SetActive(true);
                txt2.SetActive(false);
            }
            else if (txt3.activeSelf == true)
            {
                txt4.SetActive(true);
                txt3.SetActive(false);
            }
            else if (txt4.activeSelf == true)
            {
                txt5.SetActive(true);
                txt4.SetActive(false);
            }
            else if (txt5.activeSelf == true)
            {
                txt6.SetActive(true);
                txt5.SetActive(false);
            }
            else if (txt6.activeSelf == true)
            {
                txt7.SetActive(true);
                txt6.SetActive(false);
            }
            else if (txt7.activeSelf == true)
            {
                if (StageSelect.hiddenKey == false)
                    StageSelect.hiddenKey = true;

                SceneManager.LoadScene("StageSelect");
            }
        }
    }
}
