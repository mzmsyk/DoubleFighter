using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject parent;

    public GameObject ball;
    float xSpeed = 1;
    float zSpeed = 3;

    private void Start()
    {
        parent = GameObject.Find("Parent");
    }
    private void Update()
    {
        //xSpeed = GameObject.Find("Ball").GetComponent<Movement>().xSpeed;
        //zSpeed = GameObject.Find("Ball").GetComponent<Movement>().speed;


    }

    public List<GameObject> balls = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Multiply>().multiply == true)
        {
            for (int i = 1; i < other.gameObject.GetComponent<Multiply>().count * parent.transform.childCount; i++)
            {
                Debug.Log(i);
                GameObject temp = Instantiate(ball, transform.position, Quaternion.identity);
                temp.transform.parent = parent.transform;
                temp.GetComponent<Movement>().speed = zSpeed;
            }
        }
    }
}



