using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    public Transform target;
    private Transform tr;
    public float dist = 0;
    public float height = 3;
    public float width = -5;
    
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = target.position - (1 * Vector3.forward * dist) +
            (Vector3.up * height) + (Vector3.left * width);
        tr.LookAt(target);
    }


}
