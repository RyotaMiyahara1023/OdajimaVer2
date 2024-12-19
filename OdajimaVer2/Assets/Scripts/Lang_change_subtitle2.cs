using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lang_change_subtitle_2 : MonoBehaviour
{
    Image image;
    public Data data;
    [SerializeField] Sprite[] _sprite = new Sprite[4];
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        data = GameObject.Find("DataManager").GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        if(data.subtitle == true) image.sprite = _sprite[data.lang*2];
        else image.sprite = _sprite[data.lang*2 + 1];
    }
}
