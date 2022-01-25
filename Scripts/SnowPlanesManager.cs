using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPlanesManager : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(DestroyPlanes());
    }

    IEnumerator DestroyPlanes()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

}
