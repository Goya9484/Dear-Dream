using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public GameObject player;
    public GameObject look;

    float distance;

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= 3.0f)
            look.SetActive(true);
        else
            look.SetActive(false);

    }
}
