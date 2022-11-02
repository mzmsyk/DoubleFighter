using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    bool kontrol = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // rb.velocity = rb.velocity.normalized * speed;
        if (Input.GetMouseButtonDown(0))
        {
            //kontrol = true;
            //Touch parmak = Input.GetTouch(0);
            //Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //float yatay = Input.GetAxis("Horizontal");
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + vec.y, transform.eulerAngles.z);
        }
        if (kontrol)
        {
            Vector3 okPoz = transform.position;
            Vector3 mousePoz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePoz - okPoz;
            transform.right = direction;
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.right.x, transform.right.y, transform.right.z);
        }
        
    }
    private void OnMouseDown()
    {
        kontrol = true;
    }
}