using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //전역 변수
    public Transform tr;
    public float speed = 2.0f;
    public float turnSpeed = 50.0f;    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical"); //Up, Down/ W, S  : (-1.0f ~ 0.0f ~ +1.0f)
        float h = Input.GetAxis("Horizontal"); //Left, Right Arrow / A, D

        tr.Translate(Vector3.forward * v * Time.deltaTime * speed); //Vector3(0, 0, 1) * speed
        tr.Rotate(Vector3.up * h * Time.deltaTime * turnSpeed);

        /* 정규화 벡터(Normalized Vector), 단위벡터(Unit Vector)
            Vector3.forward = Vector3(0, 0, 1)
            Vector3.up      = Vector3(0, 1, 0)
            Vector3.right   = Vector3(1, 0, 0)

            Vector3.one     = Vector3(1, 1, 1)
            Vector3.zero    = Vecotr3(0, 0, 0)
        */
    }
}
