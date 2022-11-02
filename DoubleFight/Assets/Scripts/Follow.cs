using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private GameObject obje;
    void Start()
    {
        //obje = GameObject.Find("Ball");  
        obje = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        transform.position = obje.transform.position;

        transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
    }
}
