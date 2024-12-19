using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject chapter;
    public GameObject setting;
    Data data;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("DataManager").GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        chapter.SetActive(data.chapter_switch);
        setting.SetActive(data.setting_switch);
    }

    public void GameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Open_chapter()
    {
        data.chapter_switch = true;
    }

    public void Open_Setting()
    {
        //setting.SetActive(true);
        data.setting_switch = true;
    }

    public void Back_title()
    {
        data.chapter_switch = false;
        data.setting_switch = false;
    }

    public void Chapter0()
    {
        data.chapter = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void Chapter1()
    {
        data.chapter = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void Chapter2()
    {
        data.chapter = 2;
        SceneManager.LoadScene("SampleScene");
    }

    public void Memorial()
    {
        SceneManager.LoadScene("Memorial");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
}
