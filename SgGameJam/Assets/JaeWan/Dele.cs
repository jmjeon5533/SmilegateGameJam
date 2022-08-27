using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dele : MonoBehaviour
{
    GameObject Manager = GameObject.FindWithTag("GameManager");
    private void Awake()
    {
      
    }
    void Start()
    {
        
    }

    void Update()
    {
        Destroy(Manager);
    }
}
