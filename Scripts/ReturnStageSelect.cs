using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnStageSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (tag == "Stage01Key")
            if (StageSelect.keyCount.Contains(1) == false)
            {
                StageSelect.keyCount.Add(1);
                Debug.Log(StageSelect.keyCount);
            }
                


        if (tag == "Stage02Key")
            if (StageSelect.keyCount.Contains(2) == false)
                StageSelect.keyCount.Add(2);

        if (tag == "Stage03Key")
            if (StageSelect.keyCount.Contains(3) == false)
                StageSelect.keyCount.Add(3);

        SceneManager.LoadScene("StageSelect");
    }
}
