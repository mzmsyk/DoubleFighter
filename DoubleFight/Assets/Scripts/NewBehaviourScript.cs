using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    float xRot, yRot = 0;
    public Rigidbody balll;
    public float rotationSpeed = 5f;
    public float shootPower = 30f;



    void Update()
    {
        transform.position = balll.position;
        if (Input.GetMouseButton(0))
        {

            xRot += Input.GetAxis("Mouse X")*rotationSpeed;
            yRot += Input.GetAxis("Mouse Y")*rotationSpeed;
            transform.rotation = Quaternion.Euler(yRot, xRot, 0);

        }
        if (Input.GetMouseButtonUp(0))
        {

            balll.velocity = transform.forward*shootPower;

        }

    }

   
}
