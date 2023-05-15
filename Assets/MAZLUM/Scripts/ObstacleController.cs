using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleController : MonoBehaviour
{
    private Manager playerManager;
   
    [SerializeField] private int TMPValue;
   
    [SerializeField] private GameObject TMP;
    private bool isTrigged = false;

    void Start()
    {
        playerManager = FindObjectOfType<Manager>();

        //rightTMP.GetComponent<TextMeshPro>().text = "+" + rightTMPValue.ToString();
        //leftTMP.GetComponent<TextMeshPro>().text = "+" +TMPValue.ToString();
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTrigged)

        {
            if (other.gameObject.tag == "Player")
            {
                //Debug.Log("Before: " + playerManager.transform.childCount);
                //Debug.Log(other.transform.position.x + " " + rightTMP.name + " " + leftTMP.name + " " + rightTMPValue + " " +TMPValue);
                isTrigged = true;
               

                      
               
                    if (TMP.name == "x")
                    {
                        playerManager.SpawnPlayer(TMPValue * playerManager.gameObject.transform.GetChild(0).childCount- playerManager.gameObject.transform.GetChild(0).childCount);

                        TMP.SetActive(false);
                    }
                    else if (TMP.name == "+")
                    {
                        playerManager.SpawnPlayer(TMPValue);
                        TMP.SetActive(false);
                    }

                    else if (TMP.name == "-")
                    {
                        //int lastIndex = playerManager.DeletePlayers(TMPValue);

                        //if (playerManager.transform.GetChild(0).childCount > 0)
                        //{
                        //playerManager.lastBall = playerManager.transform.GetChild(0).GetChild(lastIndex).gameObject;
                        //playerManager.balls.Remove(playerManager.transform.GetChild(0).GetChild(lastIndex));
                        playerManager.DeletePlayers(TMPValue);
                        //}

                        TMP.SetActive(false);
                    }

                    else if (TMP.name == "/")
                    {
                        if (TMPValue == 1) return;
                        int childCount = playerManager.transform.GetChild(0).childCount;
                        int lastIndex = playerManager.DeletePlayers(childCount - (childCount /TMPValue));
                        if (playerManager.transform.GetChild(0).childCount > 0)
                        {
                            playerManager.lastBall = playerManager.transform.GetChild(0).GetChild(lastIndex).gameObject;
                        }
                        TMP.SetActive(false);
                    }


                }
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                Debug.Log("After: " + playerManager.transform.GetChild(0).childCount);
            }
        }
    }

