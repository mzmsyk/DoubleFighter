using MoreMountains.NiceVibrations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterhareket : MonoBehaviour
{
    public float hiz;
    Rigidbody fizik;
    float rotY;
    float rotX;
    public float donmeHiz;
    public bool kontrol = false;
    [SerializeField] private Camera mainCamera;
    public LineRenderer line;
    Vector3 ilkRot;
    Vector3 ilkPos;
    public float kirilmaUzunlugu;
    public static bool kontrolTitresim;
    public HapticTypes hapticTypes1 = HapticTypes.RigidImpact;
    [Header("SES")]
    public AudioSource sesDogru;
    public AudioSource sesYanlis;
    public AudioSource sesKazanma;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();

    }


    void Update()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            sesDogru.mute = true;
            sesKazanma.mute = true;
            sesYanlis.mute = true;
        }
        if (PlayerPrefs.GetInt("sesDurum") == 0)
        {
            sesDogru.mute = false;
            sesKazanma.mute = false;
            sesYanlis.mute = false;
        }
        if (PlayerPrefs.GetInt("titresimDurum") == 1)
        {
            kontrolTitresim = false;
        }
        if (PlayerPrefs.GetInt("titresimDurum") == 0)
        {
            kontrolTitresim = true;
        }


        if (kontrol)
        {
            if (Input.touchCount > 0)
            {
                Touch parmak = Input.GetTouch(0);
                Ray ray = mainCamera.ScreenPointToRay(parmak.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    if (parmak.phase == TouchPhase.Moved)
                    {
                        //Vector3 pos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        transform.Rotate(0, -(parmak.deltaPosition.x + Time.deltaTime), 0);
                        //transform.LookAt(parmak.position);
                        line.gameObject.SetActive(true);
                        Vector3 _point = hit.point;
                        Vector3 kirilma = Vector3.Reflect(_point, -hit.transform.forward ) * kirilmaUzunlugu;
                        line.SetPosition(0, transform.position);
                        line.SetPosition(1, transform.position + transform.forward * 10);
                        line.SetPosition(2, hit.point);
                        line.SetPosition(3, hit.point + kirilma);
                        

                    }
                    else if (parmak.phase == TouchPhase.Ended)
                    {
                        kontrol = false;
                        fizik.AddForce(transform.forward * hiz, ForceMode.Impulse);
                        line.gameObject.SetActive(false);
                        transform.Rotate(360, 0, 0);
                        //transform.eulerAngles = ilkRot;
                        //transform.Rotate(0, 0, 0);
                        

                    }

                    Debug.DrawLine(ray.origin, hit.transform.forward, Color.red);






                }

            }
        }
        


        if (fizik.velocity.magnitude<=0)
        {
            transform.Rotate(0, 0, 0);
            kontrol = true;
        }




    }
    public void d()
    {
        fizik.velocity = Vector3.zero;

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="titresim")
        {
            if (kontrolTitresim == true)
            {
                MMVibrationManager.Haptic(hapticTypes1, false, true, this);
            }
        }
    }
}
