using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class Movie : MonoBehaviour
{
    // VideoPlayerコンポーネント
    [SerializeField] private VideoPlayer _videoPlayer;

    // StreamingAssetsの動画ファイルへのパス
    [SerializeField] private string[] _streamingAssetsMoviePath = new string[3];
    public AudioClip[] movie_BGM = new AudioClip[3];
    public AudioSource audioSource;
    public Material[] back = new Material[4];
    [SerializeField] Data data;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject Button;
    [SerializeField] GameManager gamemanager;

    public void Set_Movie()
    {
        data = GameObject.Find("DataManager").GetComponent<Data>();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = (float)data.volume/100;

        _videoPlayer.playOnAwake = false;
        // URL指定
        _videoPlayer.source = VideoSource.Url;

        // StreamingAssetsフォルダ配下のパスの動画をURLとして指定する
        _videoPlayer.url = Path.Combine(Application.streamingAssetsPath, _streamingAssetsMoviePath[data.chapter]);

        //_videoPlayer.Pause();
        _videoPlayer.prepareCompleted += OnCompletePrepare;
        _videoPlayer.Prepare();
    }

    void OnCompletePrepare(VideoPlayer source)
    {
        _videoPlayer.prepareCompleted -= OnCompletePrepare;
        _videoPlayer.Play();
        _videoPlayer.playbackSpeed = 0f;
        Button.SetActive(true);
    }

    public void Play_Movie()
    {
        // 再生
        _videoPlayer.Play();
        audioSource.pitch = 1f;
        _videoPlayer.playbackSpeed = 1f;
    }

    public void Pause_Movie()
    {
        // 再生
        _videoPlayer.Pause();
        audioSource.pitch = 0f;
    }

    public void Change_Movie()
    {
        _videoPlayer.playOnAwake = false;
        _videoPlayer.url = Path.Combine(Application.streamingAssetsPath, _streamingAssetsMoviePath[data.chapter]);

        if(data.chapter == 1){
            RenderSettings.skybox.SetFloat("_Rotation", -(Camera.transform.localEulerAngles.y + 180f));
        }
        else RenderSettings.skybox.SetFloat("_Rotation", 0f);

        //_videoPlayer.Pause();
        _videoPlayer.prepareCompleted += OnCompletePrepare_2;
        _videoPlayer.Prepare();
    }
    
    void OnCompletePrepare_2(VideoPlayer source)
    {
        _videoPlayer.prepareCompleted -= OnCompletePrepare_2;
        _videoPlayer.Play();
        _videoPlayer.playbackSpeed = 0f;
        audioSource.pitch = 1f;
        gamemanager.Movie_3D[data.chapter].SetActive(true);
        gamemanager.Test();
    }

    public void Chapter_1_Set()
    {
        RenderSettings.skybox.SetFloat("_Rotation", -(Camera.transform.localEulerAngles.y + 180f));
    }
}
