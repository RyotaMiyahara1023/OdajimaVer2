using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lang_change : MonoBehaviour
{
    Text text;
    public Data data;
    [SerializeField] string[] _text = new string[2];
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        data = GameObject.Find("DataManager").GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = _text[data.lang];
    }
}
