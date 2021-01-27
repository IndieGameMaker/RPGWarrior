using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject slime1;
    public GameObject slime2;

    public List<GameObject> npc = new List<GameObject>();
    public Transform[] points;

    public float createTime = 3.0f;

    public bool IsGameOver = false;

    void Start()
    {
        slime1 = Resources.Load<GameObject>("NPC/Slime");  
        slime2 = Resources.Load<GameObject>("NPC/Turtle");   

        npc.AddRange(Resources.LoadAll<GameObject>("NPC"));

        //SpawnPointGroup 게임오브젝트를 검색
        GameObject group = GameObject.Find("SpawnPointGroup");
        if (group != null)
        {
            points = group.GetComponentsInChildren<Transform>();
        }

        //InvokeRepeating("CreateSlime", 2.0f, createTime);
    }

    IEnumerator CreateSlime()
    {
        yield return new WaitForSeconds(2.0f);
        
        while (IsGameOver == false)
        {
            int npcIdx = Random.Range(0, npc.Count); // (0, 2)  => 0, 1
            int pointIdx = Random.Range(1, points.Length); // (1, 24) => 1,2,3,...,23

            Instantiate(npc[npcIdx], points[pointIdx].position, Quaternion.identity);
            yield return new WaitForSeconds(createTime);
        }
    }

}
