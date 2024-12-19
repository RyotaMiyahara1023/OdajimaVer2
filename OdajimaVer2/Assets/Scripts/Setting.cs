using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public int lang = 0;
    public GameObject Volume;
    public int _volume;
    string str;
    public Text Volume_text;
    public bool subtitle;
    Data data;
    public bool set = false;
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("DataManager").GetComponent<Data>();
        lang = data.lang;
        Volume.GetComponent<Slider>().value = (int)(data.volume);
        subtitle = data.subtitle;
        set = true;
    }

    // Update is called once per frame
    void Update()
    {
        _volume = (int)(Volume.GetComponent<Slider>().value);
        str = _volume.ToString();
        Volume_text.text = str;
    }

    public void lang_setting()
    {
        if(lang == 0) lang = 1;
        else lang = 0;
    }

    public void subtitle_setting(){
        subtitle = !subtitle;
    }
}
