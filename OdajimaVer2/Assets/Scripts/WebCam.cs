using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Android;

public class WebCam : MonoBehaviour
{
    public RawImage RawImage;
    WebCamTexture webCam;
    int selectCamera = 0;
    public Text camera_num;
    public bool pause = false;
    public Quaternion baseRotation;

    IEnumerator Start()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;

            for (var i = 0; i < devices.Length; i++){
                if(devices[i].isFrontFacing == false || ((devices[i].name).ToString()).Equals("背面カメラ")) {
                    selectCamera = i;
                    break;
                }
            }
            
           webCam = new WebCamTexture(devices[selectCamera].name);

            RawImage.texture = webCam;
        
            webCam.Play();
        }
    }

    void Camera_Pause()
    {
        webCam.Pause();
        pause = true;
    }

    void Camera_Restart()
    {
        webCam.Play();
        pause = false;
    }

    public void ChangeCamera()
    {
        // カメラの取得
        //WebCamDevice[] webCamDevice = WebCamTexture.devices;
        WebCamDevice[] devices = WebCamTexture.devices;

        // カメラが1個の時は無処理
        if (devices.Length <= 1) {
            //camera_num.text = "カメラが一つしかありません。\n" + devices[selectCamera].name;
            return;
        }

        // カメラの切り替え
        selectCamera++;
        if (selectCamera >= devices.Length) selectCamera = 0;
        webCam.Stop();
        webCam = new WebCamTexture(devices[selectCamera].name);
        RawImage.texture = webCam;
        webCam.Play();
        //camera_num.text = Array.IndexOf(devices, selectCamera).ToString() + "," + devices.Length.ToString() + "\n" + devices[selectCamera].name + "\n" + devices[selectCamera].isFrontFacing;
    }
}