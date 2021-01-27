using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject slime1;
    public GameObject slime2;

    public List<GameObject> npc = new List<GameObject>();
    public Transform[] points;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
