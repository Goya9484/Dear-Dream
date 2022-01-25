using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxManager : MonoBehaviour
{
    public GameObject txtBox;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            txtBox.SetActive(false);
        }
    }
}
