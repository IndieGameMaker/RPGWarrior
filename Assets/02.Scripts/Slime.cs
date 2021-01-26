using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    //슬라임 자신의 Transform
    [HideInInspector]
    public Transform tr;

    //추적해야할 목표물의 Transform (Mummy's Transform)
    public Transform targetTr;

    public float moveSpeed = 1.5f;
    public float turnSpeed = 200.0f;

    public float traceDist = 5.0f;

    void Start()
    {
        tr = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //두 벡터간의 거리를 계산
        float distance = Vector3.Distance(tr.position, targetTr.position);

        if (distance <= traceDist)
        {
            Debug.Log($"Closed Mummy !!! {distance}");
        }
    }
}
