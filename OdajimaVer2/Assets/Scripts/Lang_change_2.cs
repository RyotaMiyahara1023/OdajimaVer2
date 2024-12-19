using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lang_change_2 : MonoBehaviour
{
    Image image;
    public Data data;
    [SerializeField] Sprite[] _sprite = new Sprite[2];
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        data = GameObject.Find("DataManager").GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = _sprite[data.lang];
    }
}
