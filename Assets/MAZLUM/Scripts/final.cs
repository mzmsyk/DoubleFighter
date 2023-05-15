using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour
{
    private karakterhareket playerMovement;
    private Manager playerManager;
    private navmesh nav;
    bool kontrol = false;
    //Animator anim;
    GameObject finish;
    public Camera cam;
    public Transform _lookAt;
    int randomBayrak;
    public GameObject[] bayraklar;
    void Start()
    {
        //anim = GetComponent<Animator>();
        playerMovement = FindObjectOfType<karakterhareket>();
        playerManager = FindObjectOfType<Manager>();
        nav = FindObjectOfType<navmesh>();
        finish = GameObject.FindGameObjectWithTag("Finish");
        randomBayrak = Random.Range(0, 11);
        bayraklar[randomBayrak].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (kontrol)
        {
            Camera.main.GetComponent<CameraFollow>().enabled = false;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cam.transform.position, 0.03f);
            //Camera.main.transform.rotation = Quaternion.Euler(33.827f, 147.073f, -19.825f);
            Camera.main.transform.LookAt(_lookAt);
            
           

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            //playerMovement.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("sahneye girildi...");
            Manager.kontrol = false;
            kontrol = true;
            this.gameObject.GetComponent<BoxCollider>().enabled=false;
            navmesh.kontrol = true;
            Invoke("s", 2);
            
        }
    }
    void s()
    {
        //navmesh.kontrol = false;
        finish.GetComponent<Animator>().SetBool("final", true);
        Camera.main.gameObject.SetActive(false);
        cam.gameObject.SetActive(true);
        Invoke("k", 18);
    }
    void k()
    {
        oyunyoneticisi.kontrol = true;
    }
}
