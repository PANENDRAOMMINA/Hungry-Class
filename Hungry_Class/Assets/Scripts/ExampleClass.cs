using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExampleClass : MonoBehaviour
{
    public Transform target;
    public Vector3 screenPos;
    public Vector3 Targetposition;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
         screenPos = cam.WorldToScreenPoint(target.position);
         Targetposition=target.position;
    }
}
