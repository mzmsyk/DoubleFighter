using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yuklemeekrani : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider bar;
    public int level;
    void Load()
    {

    }
    void Start()
    {
        level = PlayerPrefs.GetInt("kayit");
        StartCoroutine(SkillsTimer(level));

    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator SkillsTimer(int level)
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation asyn = SceneManager.LoadSceneAsync(level);
        while (!asyn.isDone)
        {
            bar.value = asyn.progress;
            yield return null;


        }
    }
}
