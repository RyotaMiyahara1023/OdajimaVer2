using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lang_change_subtitle : MonoBehaviour
{
    Text text;
    Data data;
    [SerializeField] string[] _text = new string[4];
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        data = GameObject.Find("DataManager").GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        if(data.subtitle == true) text.text = _text[data.lang*2];
        else text.text = _text[data.lang*2 + 1];
    }
}
