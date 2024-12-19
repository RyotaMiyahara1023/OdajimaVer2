using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    public Setting setting;
    public int lang = 0;
    public int volume = 70;
    public int chapter;
    public bool subtitle = true;
    public bool chapter_switch = false;
    public bool setting_switch = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 24;
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {
        if(setting != null){
            if (SceneManager.GetActiveScene().name == "Title" && setting.set){
                lang = setting.lang;
                volume = (int)(setting._volume);
                subtitle = setting.subtitle;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Title") setting = GameObject.Find("SettingManager").GetComponent<Setting>();
    }
}
