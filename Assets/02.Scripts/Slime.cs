using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Slime : MonoBehaviour
{
    //슬라임 자신의 Transform
    [HideInInspector]
    public Transform tr;
    private Animator anim;

    //추적해야할 목표물의 Transform (Mummy's Transform)
    public Transform targetTr;

    public float moveSpeed = 1.5f;
    public float turnSpeed = 200.0f;
    public float traceDist = 5.0f;

    [Range(1.0f, 3.0f)]
    public float attackDist = 2.0f;

    //IsAttack 파라메터의 Hash 값을 미리 추출
    private readonly int hashAttack = Animator.StringToHash("IsAttack");

    public bool isAttack = false;
    public bool isAttackTaskRunning = false;

    private void Start()
    {
        tr = this.gameObject.GetComponent<Transform>();
        anim = GetComponent<Animator>();

        //Random 클래스
        moveSpeed = Random.Range(1.0f, 2.5f);  //1.0f ~ 2.5f (inclucive)
        
        CalExp<int>(10);
        CalExp<float>(35.7f);
        CalExp<double>(50.0d);
        CalExp<string>("aaaa");
    }

    // Update is called once per frame
    private void Update()
    {
        //두 벡터간의 거리를 계산
        var distance = (tr.position - targetTr.position).sqrMagnitude;

        // if (distance <= Mathf.Pow(traceDist, 2))
        if (distance <= attackDist * attackDist)
        {
            //공격 애니메이션 실행
            anim.SetBool(hashAttack, true);
            
            if (isAttackTaskRunning == false)
            {
                isAttack = true;
                StartCoroutine(Attack());
            }
        }
        else if (distance <= traceDist * traceDist)
        {
            isAttack = false;

            anim.SetBool(hashAttack, false);
            //Mummy를 향해서 회전처리
            tr.LookAt(targetTr);
            tr.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }

    IEnumerator Attack()
    {
        isAttackTaskRunning = true;

        while(isAttack == true)
        {
            Debug.Log($"Attack Mummy : {Time.time}");
            yield return new WaitForSeconds(2.0f);
        }

        isAttackTaskRunning = false;
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
