using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmesh : MonoBehaviour
{
    public Transform[] hedef;
    //NavMeshAgent agent;
    public static bool kontrol = false;
    private Manager manager;
    public Transform finish;
    float m = 0.05f;
    int sayac = 0;
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        kontrol = false;
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (kontrol)
        {
            sayac = 0;
            for (int i = 0; i < manager.balls.Count; i++)
            {
                //int t = Random.Range(0, hedef.Length);
                manager.balls[i].transform.position = Vector3.MoveTowards(manager.balls[i].transform.position, hedef[sayac].position, m);
                manager.balls[i].transform.parent = finish.transform;
                sayac++;
                if (hedef.Length==sayac)
                {
                    sayac = 0;
                    
                }
            }
           

            
                /*Vector3 pos = transform.position;
                pos.y = 0;
                transform.position = Vector3.MoveTowards(transform.position, hedef[t].position, m);
                transform.parent = finish.transform;*/
           
            //Invoke("s", 1);
           
                
            

        }
    }
    void s()
    {
        kontrol = false;
    }
}
