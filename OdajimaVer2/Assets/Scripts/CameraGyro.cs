using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using System.Reflection;
using System;

public class CameraGyro : MonoBehaviour
{
    //public GameObject gy;
    [SerializeField] Data data;
    Quaternion rot;
    //bool y_rot = false;
    public float y_r = 0;
    [SerializeField] GameManager gamemanager;

    void Start()
    {
        Time.timeScale = 1f;
        Input.gyro.enabled = true;
        data = GameObject.Find("DataManager").GetComponent<Data>();
        gamemanager.Load_Data();
    }

    private void Update()
    {
        var rotRH = Input.gyro.attitude;
        //var rot = new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w) * Quaternion.Euler(90f, 0f, 0f);
        //rot = (new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w)) * Quaternion.Euler(90f, 0f, 0f);

        if(data.chapter == 1) {
            /*if(!y_rot) {
                //y_r = transform.localRotation.y;
                //y_r = Mathf.Sin((transform.localRotation.x*Mathf.PI)/180f);
                y_r = -rotRH.z;
                Debug.Log("調整");
                y_rot = true;
            }*/
            rot = (new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w)) * Quaternion.Euler(90f, 0f, 0f);
            transform.localRotation = rot;
        }
        else {
            rot = (new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w)) * Quaternion.Euler(90f, 0f, 0f);
            transform.localRotation = rot;
        }

        

        //transform.localRotation = rot;

        //Text gy_text = gy.GetComponent<Text>();
        //gy_text.text = "x : " + (transform.localEulerAngles.x).ToString("f0") + "\ny : " + (transform.localEulerAngles.y).ToString("f0") + "\nz : " + (transform.localEulerAngles.z).ToString("f0");
        //gy_text.text = "x : " + (transform.localEulerAngles.x).ToString("f1") + " , " + (rot.x).ToString("f1") + "\ny : " + (transform.localEulerAngles.y).ToString("f0") + " , " + (rot.y).ToString("f0") + "\nz : " + (transform.localEulerAngles.z).ToString("f0") + " , " + (rot.z).ToString("f0") + "\ny_r : " + (y_r).ToString("f0");
        //Debug.Log("x : " + (transform.localEulerAngles.x).ToString("f1") + " , " + (rot.x).ToString("f1") + "\ny : " + (transform.localEulerAngles.y).ToString("f0") + " , " + (rot.y).ToString("f0") + "\nz : " + (transform.localEulerAngles.z).ToString("f0") + " , " + (rot.z).ToString("f0") + "\ny_r : " + (y_r).ToString("f0"));
    }
}