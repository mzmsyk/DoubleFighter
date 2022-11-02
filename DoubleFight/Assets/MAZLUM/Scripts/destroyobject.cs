using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyobject : MonoBehaviour
{
    private Manager playerManager;
    public int sayac;
   
    void Start()
    {
        playerManager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ballkopya")
        {
            sayac=1;
            
                int lastIndex = playerManager.DeletePlayers(sayac);

                if (playerManager.transform.GetChild(0).childCount > 0)
                {  
                     playerManager.DeletePlayers(sayac);
                     
                }

                
            
        }
        //gameObject.GetComponent<BoxCollider>().isTrigger = true;
        //Debug.Log("After: " + playerManager.transform.GetChild(0).childCount);
    }
}

