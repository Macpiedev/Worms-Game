using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Transform mainCamera;
    Transform unit;
    public Transform canva;

    public Vector3 offset;

    void Start()
    {
        unit = transform.parent;

        transform.SetParent(canva);
    }


    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
        transform.position = unit.position + offset;
    }
}
