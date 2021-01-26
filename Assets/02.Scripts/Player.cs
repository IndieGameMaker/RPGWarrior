using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //전역 변수
    public Transform tr;
    public float speed = 0.05f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tr.position += new Vector3(0.0f, 0.0f, speed);
    }
}
