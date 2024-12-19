using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lang_change_Volume : MonoBehaviour
{
    Image image;
    public Data data;
    [SerializeField] Sprite[] _sprite = new Sprite[2];
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        data = GameObject.Find("DataManager").GetComponent<Data>();
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = _sprite[data.lang];
        if(data.lang == 0) rectTransform.sizeDelta = new Vector2(975, 300);
        else rectTransform.sizeDelta = new Vector2(650, 200);
    }
}
