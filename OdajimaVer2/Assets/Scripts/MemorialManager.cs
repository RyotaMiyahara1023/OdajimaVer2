using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorialManager : MonoBehaviour
{
    [SerializeField] WebCam webcam;
    [SerializeField] public GameObject FrontUI;
    [SerializeField] public GameObject HowToUse;
    [SerializeField] GameObject[] _button = new GameObject[2];
    float time;
    bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(webcam.pause){
            time += Time.deltaTime;
            _button[0].SetActive(false);
            _button[1].SetActive(true);
            if(!a){
                FrontUI.SetActive(false);
                a = true;
            }
        }
        else{
            time = 0.0f;
            _button[0].SetActive(true);
            _button[1].SetActive(false);
            a = false;
        }
    }

    public void UI_SetActive()
    {
        if(webcam.pause) FrontUI.SetActive(!FrontUI.activeSelf);
    }

    public void HowToUse_Open()
    {
        HowToUse.SetActive(true);
    }

    public void HowToUse_Close()
    {
        HowToUse.SetActive(false);
    }
}
