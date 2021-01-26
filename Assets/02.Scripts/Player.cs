using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //전역 변수
    public Transform tr;
    public float speed = 2.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical"); //Up, Down/ W, S  : (-1.0f ~ 0.0f ~ +1.0f)
        Debug.Log($"v={v}");

        tr.Translate(Vector3.forward * Time.deltaTime * speed); //Vector3(0, 0, 1) * speed
    }
}
