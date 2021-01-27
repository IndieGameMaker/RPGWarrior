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

    private void Start()
    {
        tr = this.gameObject.GetComponent<Transform>();
        // CalExp(10);
        // CalExp(30.5f);
        CalExp<int>(10);
        CalExp<float>(35.7f);
        CalExp<double>(50.0d);
        CalExp<string>("aaaa");
    }

    // Update is called once per frame
    private void Update()
    {
        //두 벡터간의 거리를 계산
        var distance = Vector3.Distance(tr.position, targetTr.position);

        if (distance <= traceDist)
        {
            Debug.Log($"Closed Mummy !!! {distance}");
        }
    }

    void CalExp<T>(T exp)
    {
        Debug.Log($"{typeof(T)} exp = {exp}");
        // typeof(int), typeof(string)
    }

    // void CalExp(int exp)
    // {
    //     Debug.Log($"Integer exp = {exp}");
    // }

    // void CalExp(float exp)
    // {
    //     Debug.Log($"Float exp = {exp}");
    // }

}
