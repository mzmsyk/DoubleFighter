using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class moneybar : MonoBehaviour
{

    public float hiz;
    bool kontrol = true;
    bool kontrol2 = false;
    bool kontrol3 = true;
    bool kontrol4 = true;
    bool kontrol5 = false;
    bool kontrol6 = false;
    bool kontrol7 = false;
    public Transform sol;
    public Transform sag;
    public Transform orta;
    public TextMeshProUGUI dolarText;
    int dolarKayit;
    public static bool reklamKontrol = false;
    public Transform _1;
    public Transform _2;
    public Transform _3;
    public Transform _4;
    public Transform _5;
    public Transform _6;

    int sayi;

    void Start()
    {
        dolarKayit = PlayerPrefs.GetInt("dolarKayit");
    }

    // Update is called once per frame
    void Update()
    {
        dolarKayit = PlayerPrefs.GetInt("dolarKayit");

        if (kontrol && kontrol3)
        {
            this.gameObject.GetComponent<RectTransform>().position = Vector3.MoveTowards(transform.position, sol.position, hiz);
            //this.gameObject.GetComponent<RectTransform>().rotation = sag.rotation;
        }
        if (this.gameObject.GetComponent<RectTransform>().position.x == 0)
        {
            //this.gameObject.GetComponent<RectTransform>().rotation = orta.rotation;
        }
        if (kontrol2 && kontrol4)
        {
            this.gameObject.GetComponent<RectTransform>().position = Vector3.MoveTowards(transform.position, sag.position, hiz);
            //this.gameObject.GetComponent<RectTransform>().rotation = sol.rotation;
        }
        if (this.gameObject.transform.position.x == sol.position.x)
        {
            kontrol = false;
            kontrol2 = true;
        }
        if (this.gameObject.transform.position.x == sag.position.x)
        {
            kontrol = true;
            kontrol2 = false;
        }


        if (this.gameObject.GetComponent<RectTransform>().position.x >= _1.position.x && this.gameObject.GetComponent<RectTransform>().position.x <= _2.position.x && kontrol5)
        {
            ads.instance.ShowRewarded2x();
            dolarText.text = (oyunyoneticisi.dolarKayit * 2).ToString();
            kontrol5 = false;
        }
        if (this.gameObject.GetComponent<RectTransform>().position.x >= _2.position.x && this.gameObject.GetComponent<RectTransform>().position.x <= _3.position.x && kontrol6)
        {
            ads.instance.ShowRewarded3x();
            dolarText.text = (oyunyoneticisi.dolarKayit * 3).ToString();
            kontrol6 = false;
        }
        if (this.gameObject.GetComponent<RectTransform>().position.x >= _3.position.x && this.gameObject.GetComponent<RectTransform>().position.x <= _4.position.x && kontrol7)
        {
            ads.instance.ShowRewarded5x();
            dolarText.text = (oyunyoneticisi.dolarKayit * 5).ToString();
            kontrol7 = false;
        }
        if (this.gameObject.GetComponent<RectTransform>().position.x >= _4.position.x && this.gameObject.GetComponent<RectTransform>().position.x <= _5.position.x && kontrol6)
        {
            ads.instance.ShowRewarded3x();
            dolarText.text = (oyunyoneticisi.dolarKayit * 3).ToString();
            kontrol6 = false;
        }
        if (this.gameObject.GetComponent<RectTransform>().position.x >= _5.position.x && this.gameObject.GetComponent<RectTransform>().position.x <= _6.position.x && kontrol5)
        {
            ads.instance.ShowRewarded2x();
            dolarText.text = (oyunyoneticisi.dolarKayit * 2).ToString();
            kontrol5 = false;
        }









    }
    public void MoneyBarReklam()
    {
        kontrol3 = false;
        kontrol4 = false;
        kontrol5 = true;
        kontrol6 = true;
        kontrol7 = true;
    }

    public void IkiX()
    {

        oyunyoneticisi.dolarKayit = dolarKayit * 2;
        Debug.Log("para: " + oyunyoneticisi.dolarKayit);
        //StartCoroutine(bekle());
        //SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);

    }
    public void UcX()
    {

        oyunyoneticisi.dolarKayit = dolarKayit * 3;
        Debug.Log("para: " + oyunyoneticisi.dolarKayit);
        //StartCoroutine(bekle());
        //SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);

    }
    public void BesX()
    {

        oyunyoneticisi.dolarKayit = dolarKayit * 5;
        Debug.Log("para: " + oyunyoneticisi.dolarKayit);
        //StartCoroutine(bekle());
        //SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);

    }
    IEnumerator bekle()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
    }
}
