using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject slime1;
    public GameObject slime2;

    void Start()
    {
        slime1 = Resources.Load<GameObject>("Slime");  
        slime2 = Resources.Load<GameObject>("Turtle");      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
