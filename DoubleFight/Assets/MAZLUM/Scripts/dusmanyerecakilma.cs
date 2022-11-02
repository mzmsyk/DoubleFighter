using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmanyerecakilma : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody fizik;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        fizik.velocity = Vector3.up * Time.deltaTime*2;
    }
}
