using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Linq;



public class Manager : MonoBehaviour
{
    public GameObject playerPrefab;

    [SerializeField] public GameObject lastBall;
    private GameObject firstBall;
    //public TextMeshProUGUI text;
    public List<Transform> balls = new List<Transform>();
    float distance;
    public static int sayac;
    //public static Manager instance;
    public static bool kontrol = true;
    private void Awake()
    {
        sayac = 1;
        firstBall = lastBall;
        //if (instance==null)
        //{
        //    instance = this;
        //}

    }
    private void Start()
    {
        balls.Add(gameObject.transform.GetChild(0));
    }
    
    public void SpawnPlayer(int playerCount)
    {
        for (int i = 0; i < playerCount; i++)
        {
            GameObject bals = Instantiate(playerPrefab, this.gameObject.transform.GetChild(0).transform.position, this.gameObject.transform.GetChild(0).transform.rotation);
            bals.transform.parent = this.gameObject.transform.GetChild(0).transform;
            bals.GetComponent<Rigidbody>().isKinematic = true;
            bals.GetComponent<Rigidbody>().velocity = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity;
            balls.Add(bals.transform);
            sayac++;
            Debug.Log("sayac:" + sayac);
            //bals.GetComponent<karakterhareket>().line.enabled = false;
            //PlayPos();
        }
        
     
    }

    public int DeletePlayers(int deleteCount)
    {
        int lastIndex = transform.GetChild(0).childCount-1;

        for (int i = transform.GetChild(0).childCount -1; i > transform.GetChild(0).childCount - deleteCount-1 ; i--)
        {
            
            Destroy(transform.GetChild(0).transform.GetChild(i).gameObject);
            
            lastIndex--;
            balls.RemoveAt(i);


            sayac--;
            Debug.Log("sayac:" + sayac);
        }
        
        return lastIndex - 1;
        

    }

    public Vector3 PlayPos()  // topun  daýre olmasý
    {
        //Vector3 pos = Random.insideUnitSphere * 0.3f;
        //Vector3 newPos = firstBall.transform.position + pos;
        //return newPos;

        Vector3 pos = Random.insideUnitSphere * 0.3f;
        Vector3 newPos = this.transform.GetChild(0).transform.GetChild(0).transform.position + pos;
        return newPos;

    }
    public void Update()
    {
        //text.text=transform.childCount.ToString();
        //if (balls.Count > 1)
        //{
        //    for (int i = 1; i < balls.Count; i++)
        //    {
        //        var firstBall = balls.ElementAt(i - 1);
        //        var secBall = balls.ElementAt(i);
        //        var desireDistance = Vector3.Distance(secBall.position, firstBall.position);
        //        if (desireDistance <= distance)
        //        {
        //            secBall.position = new Vector3(Mathf.Lerp(secBall.position.x, firstBall.position.x, 5), secBall.position.y, Mathf.Lerp(secBall.position.z, firstBall.position.z + 0.5f, 5));
        //        }
        //    }
        //}
        //if (balls.Count>1)
        //{
        if (kontrol)
        {
            for (int i = 1; i < balls.Count; i++)
            {
                //var firstBall = balls.ElementAt(i - 1);
                //var secBall = balls.ElementAt(i);
                //var desireDistance = Vector3.Distance(secBall.position, firstBall.position);
                //if (desireDistance <= distance)
                //{
                //    secBall.position = new Vector3(Mathf.Lerp(secBall.position.x, firstBall.position.x, 5), secBall.position.y, Mathf.Lerp(secBall.position.z, firstBall.position.z, 5));
                //}

                // balls[i].transform.position = new Vector3(this.transform.GetChild(0).transform.position.x,
                //this.transform.GetChild(0).transform.position.y, this.transform.GetChild(0).transform.position.z + i / 10f);
                // PlayPos();
                //Vector3 pos = Random.insideUnitSphere *i/sayac;
                //Vector3 newPos = this.transform.GetChild(0).transform.position + pos;
                //balls[i].transform.position =new Vector3(newPos.x,this.transform.GetChild(0).transform.position.y,newPos.z);
                //balls[i].transform.Rotate(0, 0, 0);
                float mesafe = Vector3.Distance(this.transform.GetChild(0).transform.position, balls[i].position);
                //if (mesafe>=0&&mesafe<2)
                //{
                if (i >= 1 && i < 16)
                {
                    balls[i].transform.position = balls[i].transform.position = new Vector3(this.transform.GetChild(0).transform.position.x + Mathf.Cos(i) / 5,
                    this.transform.GetChild(0).transform.position.y, this.transform.GetChild(0).transform.position.z + Mathf.Sin(i) / 5);
                }
                else if (i >= 16 && i < 32)
                {
                    balls[i].transform.position = balls[i].transform.position = new Vector3(this.transform.GetChild(0).transform.position.x + Mathf.Cos(i) * 2 / 5,
                 this.transform.GetChild(0).transform.position.y, this.transform.GetChild(0).transform.position.z + Mathf.Sin(i) * 2 / 8);
                }
                else if (i >= 32 && i < 64)
                {
                    balls[i].transform.position = balls[i].transform.position = new Vector3(this.transform.GetChild(0).transform.position.x + Mathf.Cos(i) * 3 / 5,
                    this.transform.GetChild(0).transform.position.y, this.transform.GetChild(0).transform.position.z + Mathf.Sin(i) * 3 / 5);
                }
                else if (i >= 64 && i < 128)
                {
                    balls[i].transform.position = balls[i].transform.position = new Vector3(this.transform.GetChild(0).transform.position.x + Mathf.Cos(i) * 4 / 5,
                 this.transform.GetChild(0).transform.position.y, this.transform.GetChild(0).transform.position.z + Mathf.Sin(i) * 4 / 5);
                }
                else if (i >= 128 && i < 256)
                {
                    balls[i].transform.position = balls[i].transform.position = new Vector3(this.transform.GetChild(0).transform.position.x + Mathf.Cos(i) * 5 / 5,
                 this.transform.GetChild(0).transform.position.y, this.transform.GetChild(0).transform.position.z + Mathf.Sin(i) * 5 / 5);
                }
                //}




            }
        }
            
       // }
        

    }
}

