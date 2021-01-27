using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject slime1;
    public GameObject slime2;

    public List<GameObject> npc = new List<GameObject>();

    void Start()
    {
        slime1 = Resources.Load<GameObject>("NPC/Slime");  
        slime2 = Resources.Load<GameObject>("NPC/Turtle");   

        npc.AddRange(Resources.LoadAll<GameObject>("NPC"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
