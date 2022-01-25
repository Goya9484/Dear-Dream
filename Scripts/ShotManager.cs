using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    GameObject targets;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.Find("Targets");
    }

    void OnParticleCollision(GameObject other)
    {
        for (i = 1; i < 3; i++)
            if (other.name == targets.transform.Find("Target0" + i).gameObject.name)
                targets.transform.Find("Target0" + (i + 1)).gameObject.SetActive(true);

        if (other.name == targets.transform.Find("Target03").gameObject.name)
        {
            targets.transform.Find("Target04").gameObject.SetActive(true);
            targets.transform.Find("Soil").gameObject.SetActive(true);
        }
        else if (other.name == targets.transform.Find("Target04").gameObject.name)
        {
            targets.transform.Find("Stairs").gameObject.SetActive(true);
            for (i = 1; i < 5; i++)
                targets.transform.Find("Target0" + i).gameObject.SetActive(false);
        }
    }
}
