using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float sensivity = 1f;
    [SerializeField] private LineRenderer lr;
    private void Awake()
    {
        lr = FindObjectOfType<LineRenderer>();
    }

    [System.Obsolete]
    private void Update()
    {
        if(Input.touchCount < 1) return;
        Touch touch = Input.GetTouch(0);

        
        if(touch.phase == TouchPhase.Ended)
            Shoot();

        else
            lr.transform.RotateAround(Vector3.up, touch.deltaPosition.y * sensivity);
    }

    void Shoot()
    {
        rb.transform.LookAt(lr.GetPosition(0) + lr.GetPosition(1));
        rb.AddForce(rb.transform.forward * 30);
        rb.gameObject.GetComponent<Movement>().enabled = true;
        this.enabled = false;
    }

}
