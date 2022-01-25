using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMaterial : MonoBehaviour
{
    public GameObject selectPanel;
    public GameObject createPanel;

    public GameObject selectSprite;
    public Sprite materialSprite;

    public AudioClip[] createSound;
    AudioSource createSE;

    void Start()
    {
        createSE = this.GetComponent<AudioSource>();
    }

    public void MaterialSelect()
    {
        selectPanel.SetActive(true);
        createPanel.transform.localPosition = new Vector3(-1100, 0, 0);
    }

    public void FireBall01()
    {
        if (InvenManager.fireBall[1] > 0)
        {
            InvenManager.fireBall[1] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.fireBall[1] == 0)
        {
            createSE.clip = createSound[0];
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.Play();
        }
        selectPanel.SetActive(false);
    }
    public void FireBall02()
    {
        if (InvenManager.fireBall[2] > 0)
        {
            InvenManager.fireBall[2] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.fireBall[2] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }
        selectPanel.SetActive(false);
    }
    public void FireBall03()
    {
        if (InvenManager.fireBall[3] > 0)
        {
            InvenManager.fireBall[3] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.fireBall[3] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Ice01()
    {
        if (InvenManager.ice[1] > 0)
        {
            InvenManager.ice[1] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.ice[1] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Ice02()
    {
        if (InvenManager.ice[2] > 0)
        {
            InvenManager.ice[2] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.ice[2] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Ice03()
    {
        if (InvenManager.ice[3] > 0)
        {
            InvenManager.ice[3] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.ice[3] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void LunchBox01()
    {
        if (InvenManager.lunchBox[1] > 0)
        {
            InvenManager.lunchBox[1] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.lunchBox[1] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void LunchBox02()
    {
        if (InvenManager.lunchBox[2] > 0)
        {
            InvenManager.lunchBox[2] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.lunchBox[2] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void LunchBox03()
    {
        if (InvenManager.lunchBox[3] > 0)
        {
            InvenManager.lunchBox[3] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.lunchBox[3] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Spear01()
    {
        if (InvenManager.spear[1] > 0)
        {
            InvenManager.spear[1] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.spear[1] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Spear02()
    {
        if (InvenManager.spear[2] > 0)
        {
            InvenManager.spear[2] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.spear[2] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Talk01()
    {
        if (InvenManager.talk[1] > 0)
        {
            InvenManager.talk[1] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.talk[1] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Talk02()
    {
        if (InvenManager.talk[2] > 0)
        {
            InvenManager.talk[2] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.talk[2] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Talk03()
    {
        if (InvenManager.talk[3] > 0)
        {
            InvenManager.talk[3] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.talk[3] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
    public void Talk04()
    {
        if (InvenManager.talk[4] > 0)
        {
            InvenManager.talk[4] -= 1;
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            selectSprite.GetComponent<Image>().sprite = materialSprite;
        }
        else if (InvenManager.talk[4] == 0)
        {
            createPanel.transform.localPosition = new Vector3(0, 0, 0);
            createSE.clip = createSound[0];
            createSE.Play();
        }

        selectPanel.SetActive(false);
    }
}
