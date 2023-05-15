using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    bool isTap = true;

    void Start()
    {
       
        GameObject.Find("Ball").GetComponent<Movement>().enabled = false;

    }
    private void Update()

    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTap == true)
            {
               
                GameObject.Find("Ball").GetComponent<Movement>().enabled = true;

                this.gameObject.SetActive(false);
                isTap = false;
            }

        }

    }
}