using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBGMManager : MonoBehaviour
{
    GameObject TitleBgm;

    private void Awake()
    {
        TitleBgm = GameObject.Find("TitleBGM");
        DontDestroyOnLoad(TitleBgm);
    }
}
