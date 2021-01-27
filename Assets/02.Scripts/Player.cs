using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //클래스의 선언부
    //전역 변수
    public Transform tr = null;
    public float speed = 2.0f;
    public float turnSpeed = 50.0f;  

    //Field
    private int initHp = 100;
    private int currHp = 100;

    //Property 
    public int Damage
    {
        get {return currHp;}
        set {
            currHp -= value;
            Debug.Log($"currHp = {currHp}, Time = {Time.time}");
            if (currHp <= 0)
            {
                MummyDie();
            }
        }
    }

    void MummyDie()
    {
        //Debug.Log("Mummy Die!!!");
        //GameObject.Find("GameMgr").GetComponent<GameManager>().IsGameOver = true;
        GameManager.instance.IsGameOver = true;

        OnPlayerDie();

        //Tag NPC 객체를 모두 배열에 추가
        // GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");
        // foreach (var enemy in enemies)
        // {
        //     enemy.SendMessage("YouWin", SendMessageOptions.DontRequireReceiver);
        // }
    }

    //델리게이트 (Delgate) : 함수를 저장할 수 있는 데이터의 타입 
    int sum = 0;

    void Sum(int a, int b)
    {
        sum = a + b;
    }

    //delegate {함수의 형태}
    delegate void SumHandler(int a, int b);
    //델리게이트 타입의 변수를 선언
    SumHandler sumHandler;

    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;


    void Start()
    {
        //델리게이트 타입으로 선언된 변수에 함수를 저장
        //sumHandler = Sum;

        //무명 메소드 방식
        sumHandler += delegate (int a, int b) 
        {
            sum = a + b;
            Debug.Log($"{a} + {b} = {sum}");
        };

        //람다식
        sumHandler += (int a, int b) => Debug.Log($"{a} * {b} = {a*b}");

        sumHandler(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"Take damaged hp ={currHp}, {(float)currHp / (float)initHp}");
        //지역변수는 반드시 초깃값을 지정
        //float r = 3.0f;

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
